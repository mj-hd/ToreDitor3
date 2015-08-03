using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ToreDitorCore
{
    public class Highlighter
    {
        public Highlighter(ref Document doc, ref Buffer buf) {
            this._Document = doc;
            this._Buffer = buf;
        }

        public void RemarkAll() {
            this._Document.Marks.Clear();
            foreach (var keyword in this._Buffer.Aliases.Keys) {
                if (keyword.StartsWith("default")) {
                    continue;
                }
                Regex rg = new Regex(this._Buffer.Aliases[keyword].Pattern, RegexOptions.Singleline);
                MatchCollection mc = rg.Matches(this._Document.FlatText);
                
                foreach (Match m in mc) {
                    for (int i = 0; i < m.Length; i++) {
                        this._Document.Marks[m.Index+i] = this._Buffer.Aliases[keyword].Name;
                    }
                }
            }
 
        }

        private Document _Document;
        private Buffer _Buffer;
    }
}
