using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using System.Diagnostics;

namespace ToreDitorCore
{
    public class Buffer
    {

        public Buffer(Font font)
        {
            this.Clear();
            this.Font = font;
        }

        public Caret Caret
        {
            get { return this._Caret; }
            set { this._Caret = value;  }
        }

        public Highlights Aliases
        {
            get { return this._Highlights; }
            set { this._Highlights = value; }
        }

        public Font Font
        {
            get { return this._Font; }
            set 
            {
                this._Font = value;

                Font t20pxFont = new Font(FontFamily.GenericMonospace, 20.0f, GraphicsUnit.Pixel);
                int dpi = (int)Math.Round((72 * t20pxFont.Size) / t20pxFont.SizeInPoints);

                int height = (int)Math.Ceiling(this._Font.SizeInPoints * dpi /72);
                this._fontSize = new Size(
                    (int)height / 2,
                    height
                );
            }
        }

        public Size FontSize
        {
            get
            {
                return this._fontSize;
            }
        }

        public Encoding Encoding
        {
            get { return this._Encoding; }
            set { this._Encoding = value; }
        }

        public void Clear()
        {
            this._Caret = new Caret();
            this._Font = SystemFonts.DefaultFont;
            this._Encoding = Encoding.Default;
            this._Highlights = new Highlights();
            this._Highlights.Add(new Highlight("default"));
            this._Highlights.Add(new Highlight("defaultBack", "", new SolidBrush(ColorTranslator.FromHtml("#eee"))));
            this._Highlights.Add(new Highlight("defaultCaret"));
            this._Highlights.Add(new Highlight("defaultNumber", "", new SolidBrush(ColorTranslator.FromHtml("#ded"))));
            this._Highlights.Add(new Highlight("defaultNumberBack", "", new SolidBrush(ColorTranslator.FromHtml("#343"))));
        }

        public Boolean isEnabledNumber = true;

        private Caret _Caret;
        private Font _Font;
        private Size _fontSize;
        private Encoding _Encoding;
        private Highlights _Highlights;
    }
}
