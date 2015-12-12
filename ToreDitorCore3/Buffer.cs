using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using System.Diagnostics;

namespace ToreDitorCore
{
    public class Buffer
    {
        public Buffer()
        {
            this.Clear();
        }
        public Buffer(Document doc)
            : this()
        {
            this.Document = doc;
        }

        public bool IsEnabledNumber = true;

        public Document          Document;
        public List<List<Token>> Tokens = new List<List<Token>>();
        public string            Filename = "";
        public Lex Lex = Lexes.PlainLex;

        public Caret Caret
        {
            get { return this._Caret; }
            set { this._Caret = value;  }
        }

        public Encoding Encoding
        {
            get { return this._Encoding; }
            set { this._Encoding = value; }
        }

        public void Open(String fname)
        {
            var doc = this.Document;

            using (var sr = new StreamReader(fname, true))
            {
                doc.Set(sr.ReadToEnd());
            }

            this.Filename = fname;
            this.Lex = Scheme.GetInstance().Dynamic.Lexes.GetLexFor(this.Filename);

            // ToDo: docをイベント引数として渡す
            Dispatcher.GetInstance().Dispatch(OnEvents.OnLoad);
        }

        public void Save()
        {
            Dispatcher.GetInstance().Dispatch(OnEvents.OnSaving);
            throw new System.NotImplementedException();
            Dispatcher.GetInstance().Dispatch(OnEvents.OnSave);
        }

        public void ApplyEncoding()
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            this._Caret = new Caret();
            this.Document = new Document();
            this._Encoding = Encoding.Default;
        }

        public void SetFileType(string type)
        {
            var scheme = Scheme.GetInstance();

            if (!scheme.Dynamic.Lexes.ContainsKey(type))
            {
                this.Lex = Lexes.PlainLex;
                return;
            }

            this.Lex = Scheme.GetInstance().Dynamic.Lexes[type];
        }

        public void RemarkAll() {
            this.Tokens.Clear();

            var lex = new Stack<Lex>();
            lex.Push(this.Lex);

            var state = 1;
            for (var i = 0; i < this.Document.Text.Count; i++)
            {
                if (this.Tokens.Count <= i)
	            {
	                this.Tokens.Add(new List<Token>());
	            }

	            var tokens = this.Tokens[i];
	            tokens.Clear();

	            var line = this.Document.Text[i].ToString();

	            int offset = 0;

	            Syntax next  = null;
	            Match next_m = null;

	            int min;
                int max_length;
	            bool is_matched = true;
	            bool is_final = false;

	            while(is_matched)
	            {
	                min = line.Length;
                    max_length = 0;
	                is_matched = false;

	                if (is_final)
	                {
	                    break;
	                }

	                if (line.Length == 0)
	                {
	                    is_final = true;
	                }

	                foreach (var syn in lex.Peek().Values) {
	                    if ((syn.StateBit & (1 << state)) != 0)
	                    {
	                        var match = syn.Pattern.Match(line, offset);
	                        if (!match.Success)
	                        {
	                            continue;
	                        }

	                        if (match.Index > min)
	                        {
                                continue;
	                        } else if (match.Index == min)
                            {
                                if (match.Length <= max_length)
                                {
                                    continue;
                                }
                            }

                            min = match.Index;
                            max_length = match.Length;
                            next = syn;
                            next_m = match;

                            is_matched = true;
	                    }
	                }

	                if (is_matched)
	                {
                        var style = lex.Peek().DefaultStyles[state];

	                    if (next_m.Index != 0)
	                    {
	                        tokens.Add(new Token(this.Document.Text[i], offset, next_m.Index, style));
	                    }

	                    string dir;
	                    if (next.Style.Styles.TryGetValue(Syntax.Directive.Style.State, out dir))
	                    {
                            state = int.Parse(dir);
                            style = lex.Peek().DefaultStyles[state];
	                    }

	                    if (!is_final)
	                    {
	                        tokens.Add(new Token(this.Document.Text[i], next_m.Index, next_m.Index + next_m.Length, next.Style + style));

	                        offset = next_m.Index + next_m.Length;
	                    }

                        if (next.Style.Styles.TryGetValue(Syntax.Directive.Style.NextState, out dir))
                        {
                            state = int.Parse(dir);
                        }

                        if (next.Style.Styles.TryGetValue(Syntax.Directive.Style.Transit, out dir))
	                    {
                            var lexes = Scheme.GetInstance().Dynamic.Lexes;
                            if (!lexes.ContainsKey(dir))
                            {
                                if (dir != "*return*")
                                {
                                    throw new Exception($"字句解析器{dir}が存在しません。");
                                }

                                lex.Pop();
                            } else
                            {
                                lex.Push(lexes[dir]);
                            }
	                    }
	                }
	            }

	            if (line.Length - offset > 0)
	            {
	                tokens.Add(new Token(this.Document.Text[i], offset, line.Length, lex.Peek().DefaultStyles[state]));
	            }
            }
        }

        public class Token
        {
            public Token(StringBuilder buffer,  int start, int end, Syntax.Directive directive)
            {
                this.Start = start;
                this.End = end;
                this.Directive = directive;
                this._buffer = buffer;
            }

            public int Start;
            public int End;
            public Syntax.Directive Directive;

            public string Value {
                get
                {
                    var range = this.End - this.Start;

                    return this._buffer.ToString().Substring(this.Start, range);
                }
            } 

            private StringBuilder _buffer;
        }

        private Caret _Caret;
        private Encoding _Encoding;
    }
}
