using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ToreDitorCore
{
    public class Highlight
    {
        private string _name;
        private int _level;
        private string _pattern;
        private Brush _brush;

        public Highlight(string name)
            : this(name, "")
        {}
        public Highlight(string name, string pattern)
            : this(name, pattern, new SolidBrush(ColorTranslator.FromHtml("#000000")))
        {}
        public Highlight(string name, string pattern, Brush brush)
            : this(name, pattern, brush, 0)
        {}
        public Highlight(string name, string pattern, Brush brush, int level)
        {
            this.Name    = name;
            this.Pattern = pattern;
            this.Brush   = brush;
            this.Level   = level;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Pattern
        {
            get { return this._pattern; }
            set { this._pattern = value; }
        }

        public Brush Brush
        {
            get { return this._brush; }
            set { this._brush = value; }
        }

        public int Level
        {
            get { return this._level; }
            set { this._level = value; }
        }
    }
    public class Highlights : Dictionary<string, Highlight>
    {
        public void Add(Highlight highlight)
        {
            this.Add(highlight.Name, highlight);
        }
        public void Add(string name, string pattern, string color, int level)
        {
            this.Add(name, new Highlight(name, pattern, new SolidBrush(ColorTranslator.FromHtml(color)), level));
        }
    }
}
