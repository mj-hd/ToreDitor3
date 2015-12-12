using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ToreDitorCore
{
    public class Lexes : Dictionary<string, Lex>
    {
        public Lexes()
        {
        }

        public void Add(Lex lex)
        {
            this.Add(lex.Name, lex);
        }

        public Lex GetLexFor(string fname)
        {
            foreach (var lex in this)
            {
                if (lex.Value.ExtPattern.IsMatch(fname))
                {
                    return lex.Value;
                }
            }

            return PlainLex;
        }

        public static Lex PlainLex = new Lex("plain", ".");
    }

    public class Lex : Dictionary<string, Syntax>
    {
        public Lex()
        {
            for (var i = 0; i < 31; i++)
            {
                this.DefaultStyles.Add(new Syntax.Directive("exstyle:Default;"));
            }
        }
        public Lex(string name, string ext)
            : this(name, new Regex(ext))
        {
        }
        public Lex(string name, Regex ext)
            : this()
        {
            this.Name = name;
            this.ExtPattern = ext;
        }

        public string Name;
        public Regex  ExtPattern;

        public List<Syntax.Directive> DefaultStyles = new List<Syntax.Directive>();

        public void Add(Syntax syn)
        {
            this.Add(syn.Name, syn);
        }

        public void Add(string name, string pattern, string style)
        {
            this.Add(name, new Syntax(name, pattern, style));
        }

        public void DefaultStyle(int state, string directive)
        {
            this.DefaultStyles[state] = new Syntax.Directive(directive);
        }
    }

    public class Syntax
    {
        public Syntax(string name, string pattern, string style)
        {
            this.Name = name;
            this.Pattern = this._ParsePattern(pattern);
            this.Style = new Directive(style);
        }

        public string Name;
        public Regex Pattern;
        public Directive Style;
        public uint StateBit = 1;

        protected Regex _ParsePattern(string pattern)
        {
            var tokens = Regex.Split(pattern, "(?<!\\\\)/", RegexOptions.Singleline);

            if (tokens.Length != 3)
            {
                throw new ArgumentException("パターン文字列が不正です．");
            }

            var regexp = new Regex(tokens[1]);

            _parseStates(tokens[0]);

            return regexp;
        }

        private void _parseStates(string states)
        {
            if (states == "" || states == "0")
            {
                this.StateBit = unchecked((uint)-1);
                return;
            }

            var index = states.IndexOf(',');
            if (index == 0)
            {
                throw new ArgumentException("状態の指定が不正です．");
            } else if (index > 0)
            {
                var tokens = states.Split(',');

                foreach (var token in tokens)
                {
                    this._parseStates(token);
                }

                return;
            }

            index = states.IndexOf("..");
            if (index == 0)
            {
                throw new ArgumentException("状態の範囲の指定が不正です．");
            } else if (index > 0)
            {
                this._parseStateRange(states);
                return;
            }

            uint parsed = 0;
            if (uint.TryParse(states, out parsed))
            {
                if ((parsed < 1) || (parsed > 30))
                {
                    throw new ArgumentOutOfRangeException("状態の指定が範囲外です．");
                }

                this.StateBit |= (uint)(1 << (int)parsed);
                return;
            }

            throw new ArgumentException("状態の指定が不正です．");
        }

        private void _parseStateRange(string range)
        {
            var tokens = range.Split(new string[] { ".." }, StringSplitOptions.None);

            if (tokens.Length != 2)
            {
                throw new ArgumentException("状態の範囲の指定が不正です．");
            }

            uint left = 0;
            if (!uint.TryParse(tokens[0], out left))
            {
                throw new ArgumentException("状態の範囲の指定が不正です．");
            }

            uint right = 0;
            if (!uint.TryParse(tokens[1], out right))
            {
                throw new ArgumentException("状態の範囲の指定が不正です．");
            }

            if ((left < 1) || (right > 30))
            {
                throw new ArgumentOutOfRangeException("状態の範囲の指定が範囲外です．");
            }

            for (var i = left; i <= right; i++)
            {
                this.StateBit |= (uint)(1 << (int)i);
            }
        }

        // 名前が不適切
        public class Directive
        {
            public static Directive operator+ (Directive s1, Directive s2)
            {
                Directive result = new Directive("");

                foreach (var style in (Style[])Enum.GetValues(typeof(Style)))
                {
                    if (s1.Styles.ContainsKey(style))
                    {
                        result.Styles[style] = s1.Styles[style];
                        continue;
                    }
                    if (s2.Styles.ContainsKey(style))
                    {
                        result.Styles[style] = s2.Styles[style];
                        continue;
                    }
                }

                return result;
            }

            public Directive(string style)
            {
                this._parseStyle(style);
            }

            public Dictionary<Style, string> Styles = new Dictionary<Style, string>();

            public bool HasExStyle() => this.Styles.ContainsKey(Style.ExStyle);

            public Brush ForegroundBrush
            {
                get
                {
                    return new SolidBrush(this.Color);
                }
            }

            public Brush BackgroundBrush
            {
                get
                {
                    return new SolidBrush(this.BackgroundColor);
                }
            }

            public Color Color
            {
                get
                {
                    string color;

                    if (!this.Styles.TryGetValue(Style.Color, out color))
                    {
                        color = "#000000";
                    }

                    return ColorTranslator.FromHtml(color);
                }
            }

            public Color BackgroundColor
            {
                get
                {
                    string background;

                    if (!this.Styles.TryGetValue(Style.BackgroundColor, out background))
                    {
                        return Color.Transparent;
                    }

                    return ColorTranslator.FromHtml(background);
                }
            }

            public FontStyle FontStyle
            {
                get
                {
                    string style, decoration;
                    FontStyle result = FontStyle.Regular;

                    if (this.Styles.TryGetValue(Style.Font, out style))
                    {
                        switch (style)
                        {
                            case "bold":
                                result |= FontStyle.Bold;
                                break;
                            case "italic":
                                result |= FontStyle.Italic;
                                break;
                        }
                    }

                    if (this.Styles.TryGetValue(Style.Decoration, out decoration))
                    {
                        switch (decoration)
                        {
                            case "underline":
                                result |= FontStyle.Underline;
                                break;
                            case "upperline":
                                // TODO: 上付き線を実装
                                break;
                            case "strikethrough":
                                result |= FontStyle.Strikeout;
                                break;
                            case "none":
                                break;
                        }
                    }

                    return result;
                }
            }

            public Directive ApplyExStyle(Dictionary<string, Directive> exstyles)
            {
                if (!this.HasExStyle())
                {
                    return this;
                }

                var exstyle = exstyles[this.Styles[Style.ExStyle]];

                return this + exstyle;
            }

            private void _parseStyle(string style)
            {
                var directives = Regex.Replace(style, @"\s+", "").Split(';');

                foreach (var directive in directives)
                {
                    var tokens = directive.Split(':');

                    if (tokens.Length == 1 && tokens[0] == "")
                    {
                        continue;
                    }

                    if (tokens[0] == "no-style")
                    {
                        this.Styles[StyleExt.ToStyle(tokens[0])] = "";
                        continue;
                    }

                    if (tokens.Length != 2)
                    {
                        throw new ArgumentException("指定子の指定が不正です．");
                    }

                    var type = StyleExt.ToStyle(tokens[0]);
                    if (type == Style.Unknown)
                    {
                        throw new ArgumentException("存在しない指示子です．");
                    }

                    this.Styles[type] = tokens[1];
                }
            }

            public enum Style
            {
                Unknown = -1,
                Color,
                BackgroundColor,
                Decoration,
                Font,
                Transit,
                State,
                NextState,
                NoStyle,
                ExStyle
            }

            public static class StyleExt
            {
                public static string ToString(Style style)
                {
                    return StyleExt._table[(int)style];
                }

                public static Style ToStyle(string style)
                {
                    return (Style)Array.IndexOf(StyleExt._table, style);
                }

                private static string[] _table = {
                    "color",
                    "background-color",
                    "decoration",
                    "font",
                    "transit",
                    "state",
                    "next-state",
                    "no-style",
                    "exstyle"
                };
            }
        }
    }
}
