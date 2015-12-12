using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToreDitorCore.Schemes
{
    [Serializable]
    public class Dynamic
    {
        public Dynamic()
        {
        }

        public Theme CurrentTheme;
        public Dictionary<string, Syntax.Directive> CurrentStyle;
        public Lexes Lexes = new Lexes();
    }
}
