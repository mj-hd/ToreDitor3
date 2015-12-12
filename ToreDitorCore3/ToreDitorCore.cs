using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using HyperTomlProcessor;
using static System.Math;

namespace ToreDitorCore
{
    public partial class ToreDitorCore : UserControl
    {
        public ToreDitorCore()
			: this("." + Path.DirectorySeparatorChar)
        {}
        public ToreDitorCore(string runtime)
        {
            InitializeComponent();

            this.Buffers.Add(new Buffer());
            this.CurrentBuffer = this.Buffers[0];

            var dispatcher = Dispatcher.GetInstance();
            var scheme = Scheme.GetInstance();

            dispatcher.Regist(new Runtimes.TypeScript(this));
            dispatcher.Regist(new Runtimes.Ruby(this));

			scheme.Themes.ImportFromDirectory(Path.Combine(runtime, "themes" + Path.DirectorySeparatorChar));
			dispatcher.ImportDirectory(Path.Combine(runtime, "scripts" + Path.DirectorySeparatorChar));

			if (File.Exists(Path.Combine(runtime, ".tore")))
            {
				using (var sr = new StreamReader(Path.Combine(runtime, ".tore")))
                {
                    scheme.Static = DynamicToml.Parse(Toml.V04, sr.ReadToEnd());
                }
            }

            dispatcher.Dispatch(OnEvents.OnInitProp);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);

            this._CaretTimer = new Timer();
            this._CaretTimer.Interval = 500;
            this._CaretTimer.Tick += new System.EventHandler(this.OnCaretTimer);
            this._CaretTimer.Enabled = true;

            dispatcher.Dispatch(OnEvents.OnInitApp);
        }

        public List<Buffer> Buffers = new List<Buffer>();

        protected Buffer _CurrentBuffer;
        public Buffer CurrentBuffer
        {
            get
            {
                return this._CurrentBuffer;
            }
            set
            {
                this._CurrentBuffer = value;

                this.Invalidate();
            }
        }

        public Buffer Create()
        {
            var buf = new Buffer();

            this.Buffers.Add(buf);

            this.CurrentBuffer = buf;

            return buf;
        }

        public Buffer Open(string fname)
        {
            var buf = this.Create();
            buf.Open(fname);

            return buf;
        }

        public void Save()
        {
            this.CurrentBuffer.Save();
        }

        private int? _numberWidth;
        protected int _NumberWidth
        {
            get
            {
                this._numberWidth = this._numberWidth ?? TextRenderer.MeasureText("0000", this.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding).Width;
                return this._numberWidth.Value;
            }
        }

        private Boolean _IsSystemKeyPressed = false;
        private void _CaretCorrection()
        {
            if (this.CurrentBuffer.Caret.X > this._CurrentLine.Length)
            {
                this.CurrentBuffer.Caret.X = this._CurrentLine.Length;
            }
            if (this.CurrentBuffer.Caret.X < 0)
            {
                this.CurrentBuffer.Caret.X = this._CurrentLine.Length;
            }
            if (this.CurrentBuffer.Caret.Y > this.CurrentBuffer.Document.Text.Count - 1)
            {
                this.CurrentBuffer.Caret.Y = this.CurrentBuffer.Document.Text.Count - 1;
            }
            if (this.CurrentBuffer.Caret.Y < 0)
            {
                this.CurrentBuffer.Caret.Y = this.CurrentBuffer.Document.Text.Count - 1;
            }
        }
        private StringBuilder _CurrentLine
        {
            get {
                return this.CurrentBuffer.Document.Text[this.CurrentBuffer.Caret.Y];
            }
        }

        private float _getTextWidth(Graphics g, string value)
        {
            return TextRenderer.MeasureText(g, value, this.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding).Width;
        }

#region オーバーライド

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            this.CurrentBuffer.RemarkAll();
            this.Invalidate();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            var g = e.Graphics;

            var scheme = Scheme.GetInstance();
            var currentStyle = scheme.Dynamic.CurrentStyle;

            var maxLine = e.ClipRectangle.Height / this.FontHeight;

            int marginTop = 0;
            int marginLeft = 0;

            g.FillRectangle(currentStyle["Default"].BackgroundBrush, e.ClipRectangle);

            if (this.CurrentBuffer.IsEnabledNumber) {
                marginLeft += this._NumberWidth;
            }

            for (var y = 0; y < Min(this.CurrentBuffer.Tokens.Count, maxLine); y++)
            {
                if (y == this.CurrentBuffer.Caret.Y)
                {
                    
                    g.FillRectangle(currentStyle["CursorLine"].BackgroundBrush, new Rectangle(0, marginTop + y * this.FontHeight, e.ClipRectangle.Width, this.FontHeight));
                }

                int x = 0;
                foreach (var token in this.CurrentBuffer.Tokens[y])
                {
                    var value = token.Value;
                    var width = (int)this._getTextWidth(g, value);
                    Brush brush;

                    // ToDo: もっといい方法がある？GetBrush(Styles)とか
                    if (token.Directive.HasExStyle())
                    {
                        var exstyle = token.Directive.Styles[Syntax.Directive.Style.ExStyle];

                        if (exstyle == "Default")
                        {
                            brush = Brushes.Transparent;
                        }
                        else
                        {
                            brush = (token.Directive.ApplyExStyle(currentStyle)).BackgroundBrush;
                        }
                    } else
                    {
                        brush = token.Directive.BackgroundBrush;
                    }

                    g.FillRectangle(
                        brush,
                        new Rectangle(
                            marginLeft + TextRenderer.MeasureText(this.CurrentBuffer.Document.Text[y].ToString().Substring(0, x), this.Font).Width,
                            marginTop + y * this.FontHeight,
                            width,
                            this.FontHeight
                        )
                    );

                    x += value.Length;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            var scheme = Scheme.GetInstance();
            var currentStyle = scheme.Dynamic.CurrentStyle;

            var maxLine = e.ClipRectangle.Height / this.FontHeight;

            int marginTop  = 0;
            int marginLeft = 0;

            if (this.CurrentBuffer.IsEnabledNumber) {
                marginLeft += this._NumberWidth;
                g.DrawLine(new Pen(currentStyle["LineNumber"].Color), this._NumberWidth-1, 0, this._NumberWidth-1, e.ClipRectangle.Bottom);
            }

            for (var y = 0; y < Min(this.CurrentBuffer.Tokens.Count, maxLine); y++)
        	{
      	        if (this.CurrentBuffer.IsEnabledNumber) {
                    var number = (y+1).ToString();

                    var width = (int)this._getTextWidth(g, number);
                    TextRenderer.DrawText(
                        g,
                        number,
                        this.Font,
                        new Point(
                            this._NumberWidth - width - 2,
                            y *this.FontHeight
                        ),
                        currentStyle["LineNumber"].Color,
                        TextFormatFlags.NoPadding
                    );
                }

                int x = 0;
                foreach (var token in this.CurrentBuffer.Tokens[y])
                {
                    var value = token.Value;

                    var font = new Font(this.Font, token.Directive.FontStyle);

                    var color = (token.Directive.ApplyExStyle(currentStyle)).Color;

                    var offset = (int)this._getTextWidth(g, this.CurrentBuffer.Document.Text[y].ToString().Substring(0, x));
                    TextRenderer.DrawText(
                        g,
                        value,
                        font,
                        new Point(
                            marginLeft + offset,
                            marginTop + y*this.FontHeight
                        ),
                        color,
                        TextFormatFlags.NoPadding
                    );

                    /*g.DrawRectangle(
                        new Pen(token.Directive.Color),
                        marginLeft + offset,
                        marginTop + y * this.FontHeight,
                        TextRenderer.MeasureText(value, this.Font).Width,
                        this.FontHeight
                    );*/

                    x += value.Length;
                }
        	}

            //キャレットの描画
            if (this.CurrentBuffer.Caret.Visible) {
                int cx = marginLeft + (int)this._getTextWidth(g, this.CurrentBuffer.Document.Text[this.CurrentBuffer.Caret.Y].ToString().Substring(0, this.CurrentBuffer.Caret.X));
                int cy = marginTop  + this.CurrentBuffer.Caret.Y * this.FontHeight;
                g.DrawLine(new Pen(currentStyle["Cursor"].Color), new Point(cx, cy), new Point(cx, cy+this.FontHeight));
            }

            base.OnPaint(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            //ベースのonValidatedを実行
            base.OnValidated(e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if ((keyData & (Keys.Up | Keys.Right | Keys.Down | Keys.Left | Keys.Back | Keys.Delete | Keys.Enter)) != 0)
            {
                return true;
            }

            return base.IsInputKey(keyData);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!this._IsSystemKeyPressed) {
                this.CurrentBuffer.Document.Input(e.KeyChar, this.CurrentBuffer.Caret.X, this.CurrentBuffer.Caret.Y);
                this.CurrentBuffer.Caret.X++;

                this.CurrentBuffer.RemarkAll();
                this.Refresh();
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            this._IsSystemKeyPressed = true;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (this.CurrentBuffer.Caret.Y == 0)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.CurrentBuffer.Caret.Y--;
                        this._CaretCorrection();

                    }


                    break;
                case Keys.Right:
                    if (this.CurrentBuffer.Caret.X == this._CurrentLine.Length)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.CurrentBuffer.Caret.X++;

                    }


                    break;
                case Keys.Down:
                    if (this.CurrentBuffer.Caret.Y == this.CurrentBuffer.Document.Text.Count-1)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.CurrentBuffer.Caret.Y++;
                        this._CaretCorrection();

                    }


                    break;
                case Keys.Left:
                    if (this.CurrentBuffer.Caret.X == 0)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.CurrentBuffer.Caret.X--;

                    }


                    break;
                case Keys.Back:
                    if (!((this.CurrentBuffer.Caret.X == 0) && (this.CurrentBuffer.Caret.Y == 0)))
                    {
                        int tmpBeforeLength;
                        if (this.CurrentBuffer.Caret.Y != 0) {
                            tmpBeforeLength = this.CurrentBuffer.Document.Text[this.CurrentBuffer.Caret.Y -1].Length;
                        } else {
                            tmpBeforeLength = 0;
                        }

                        this.CurrentBuffer.Document.Delete(this.CurrentBuffer.Caret.X - 1, this.CurrentBuffer.Caret.Y, this.CurrentBuffer.Caret.X, this.CurrentBuffer.Caret.Y);
                        
                        if (this.CurrentBuffer.Caret.X == 0)
                        {
                            this.CurrentBuffer.Caret.Y--;
                            this.CurrentBuffer.Caret.X = tmpBeforeLength;
                        }
                        else
                        {
                            this.CurrentBuffer.Caret.X--;
                        }

                    }

                    break;
                case Keys.Delete:

                    break;
                case Keys.Enter:

                    if (this.CurrentBuffer.Caret.X == this._CurrentLine.Length) {
                        this.CurrentBuffer.Document.Insert(this.CurrentBuffer.Caret.Y+1, new StringBuilder(""));
                    } else {
                        this.CurrentBuffer.Document.Insert(this.CurrentBuffer.Caret.Y +1, new StringBuilder(this._CurrentLine.ToString().Substring(this.CurrentBuffer.Caret.X)));
                        this.CurrentBuffer.Document.Delete(this.CurrentBuffer.Caret.X, this.CurrentBuffer.Caret.Y, this._CurrentLine.Length, this.CurrentBuffer.Caret.Y);
                    }
                    this.CurrentBuffer.Caret.Y++;
                    this.CurrentBuffer.Caret.X = 0;
                    break;
                default:
                    this._IsSystemKeyPressed = false;
                    base.OnPreviewKeyDown(e);
                    break;
            }

            this.CurrentBuffer.Caret.Visible = true;

            Dispatcher.GetInstance().Dispatch(OnEvents.OnKeyPress);

            this.CurrentBuffer.RemarkAll();
            this.Refresh();
        }

#endregion

        private Timer _CaretTimer;
        protected void OnCaretTimer(object sender, EventArgs e)
        {
            if (true)
            {
                this.CurrentBuffer.Caret.Visible ^= true;
            }
            int marginLeft = 0;
            int marginTop  = 0;

            if (this.CurrentBuffer.IsEnabledNumber) {
                marginLeft += this._NumberWidth;
            }

            Dispatcher.GetInstance().Dispatch(OnEvents.OnTimer);

            this.Refresh();
        }
    }
}
