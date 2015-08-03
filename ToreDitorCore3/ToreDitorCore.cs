using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToreDitorCore
{
    public partial class ToreDitorCore : UserControl
    {
        public ToreDitorCore()
            : this(SystemFonts.DefaultFont)
        {}
        public ToreDitorCore(Font font)
        {
            InitializeComponent();

            this.Buffer   = new Buffer(font);
            this.Scheme   = new Scheme();
            this.Document = new Document();
            this.Runtime  = new Runtime();
            this.Highlighter = new Highlighter(ref this.Document, ref this.Buffer);

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);

            this._CaretTimer = new Timer();
            this._CaretTimer.Interval = 500;
            this._CaretTimer.Tick += new System.EventHandler(this.OnCaretTimer);
            this._CaretTimer.Enabled = true;
        }

        public Scheme Scheme;
        public Runtime Runtime;
        public Document Document;
        public Buffer Buffer;
        public Highlighter Highlighter;

        public void Open(String fname)
        {
               this._fileSR = new StreamReader(fname, true);
               this.Document.Set(_fileSR.ReadToEnd());
               this._fileSR.Close();

               this.Highlighter.RemarkAll();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void ApplyEncoding()
        {
            throw new System.NotImplementedException();
        }

        private StreamReader _fileSR;
        private Boolean _IsSystemKeyPressed = false;
        private void _CaretCorrection()
        {
            if (this.Buffer.Caret.X > this._CurrentLine.Length)
            {
                this.Buffer.Caret.X = this._CurrentLine.Length;
            }
            if (this.Buffer.Caret.X < 0)
            {
                this.Buffer.Caret.X = this._CurrentLine.Length;
            }
            if (this.Buffer.Caret.Y > this.Document.Text.Count - 1)
            {
                this.Buffer.Caret.Y = this.Document.Text.Count - 1;
            }
            if (this.Buffer.Caret.Y < 0)
            {
                this.Buffer.Caret.Y = this.Document.Text.Count - 1;
            }
        }
        private StringBuilder _CurrentLine
        {
            get {
                return this.Document.Text[this.Buffer.Caret.Y];
            }
        }

        #region オーバーライド

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            int count = 0;
            int marginTop  = 0;
            int marginLeft = 0;
            Brush br;

            if (this.Buffer.isEnabledNumber) {
                marginLeft += 30;
                g.FillRectangle(this.Buffer.Aliases["defaultNumberBack"].Brush, 0.0f, 0.0f, 30.0f, (float)this.Height);
            }

            foreach (var line in this.Document.Text.Select((val, i) => new { i, val }))
        	{
        	    for (int x = 0; x < line.val.Length; x++ ) //文字の描画
        	    {

        	        if (this.Buffer.isEnabledNumber) {
        	            g.DrawString((line.i+1).ToString(), this.Buffer.Font, this.Buffer.Aliases["defaultNumber"].Brush, 0.0f, (float)line.i *this.Buffer.FontSize.Height);
        	        }

        	        String markName = "";
        	        this.Document.Marks.TryGetValue(count, out markName);
        	        if (markName != null) {
        	            br = this.Buffer.Aliases[markName].Brush;
        	        } else {
        	            br = this.Buffer.Aliases["default"].Brush;    
        	        }
        	        g.DrawString(line.val[x].ToString(),
        	            this.Buffer.Font,
        	            br,
        	            new PointF(
        	                (float)marginLeft + (float)x * this.Buffer.FontSize.Width,
        	                (float)marginTop  + (float)line.i * this.Buffer.FontSize.Height
        	            )
        	        );

        	        count++;
        	    }
        	    count++;
        	}

            //キャレットの描画
            
            if (this.Buffer.Caret.Visible) {
                int cx = marginLeft + this.Buffer.Caret.X * this.Buffer.FontSize.Width;
                int cy = marginTop  + this.Buffer.Caret.Y * this.Buffer.FontSize.Height;
                g.DrawLine(new Pen(this.Buffer.Aliases["defaultCaret"].Brush), new Point(cx, cy), new Point(cx, cy+this.Buffer.FontSize.Height));
            }

            base.OnPaint(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            //ベースのonValidatedを実行
            base.OnValidated(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!this._IsSystemKeyPressed) {
                this.Document.Input(e.KeyChar, this.Buffer.Caret.X, this.Buffer.Caret.Y);
                this.Buffer.Caret.X++;

                this.Highlighter.RemarkAll();
                this.Refresh();
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            this._IsSystemKeyPressed = true;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (this.Buffer.Caret.Y == 0)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.Buffer.Caret.Y--;
                        this._CaretCorrection();

                    }


                    break;
                case Keys.Right:
                    if (this.Buffer.Caret.X == this._CurrentLine.Length)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.Buffer.Caret.X++;

                    }


                    break;
                case Keys.Down:
                    if (this.Buffer.Caret.Y == this.Document.Text.Count-1)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.Buffer.Caret.Y++;
                        this._CaretCorrection();

                    }


                    break;
                case Keys.Left:
                    if (this.Buffer.Caret.X == 0)
                    {
                        //this.Beep();
                    }
                    else
                    {
                        this.Buffer.Caret.X--;

                    }


                    break;
                case Keys.Back:
                    if (!((this.Buffer.Caret.X == 0) && (this.Buffer.Caret.Y == 0)))
                    {
                        int tmpBeforeLength;
                        if (this.Buffer.Caret.Y != 0) {
                            tmpBeforeLength = this.Document.Text[this.Buffer.Caret.Y -1].Length;
                        } else {
                            tmpBeforeLength = 0;
                        }

                        this.Document.Delete(this.Buffer.Caret.X - 1, this.Buffer.Caret.Y, this.Buffer.Caret.X, this.Buffer.Caret.Y);
                        
                        if (this.Buffer.Caret.X == 0)
                        {
                            this.Buffer.Caret.Y--;
                            this.Buffer.Caret.X = tmpBeforeLength;
                        }
                        else
                        {
                            this.Buffer.Caret.X--;
                        }

                    }

                    break;
                case Keys.Delete:

                    break;
                case Keys.Enter:

                    if (this.Buffer.Caret.X == this._CurrentLine.Length) {
                        this.Document.Insert(this.Buffer.Caret.Y+1, new StringBuilder(""));
                    } else {
                        this.Document.Insert(this.Buffer.Caret.Y +1, new StringBuilder(this._CurrentLine.ToString().Substring(this.Buffer.Caret.X)));
                        this.Document.Delete(this.Buffer.Caret.X, this.Buffer.Caret.Y, this._CurrentLine.Length, this.Buffer.Caret.Y);
                    }
                    this.Buffer.Caret.Y++;
                    this.Buffer.Caret.X = 0;
                    break;
                default:
                    this._IsSystemKeyPressed = false;
                    base.OnPreviewKeyDown(e);
                    break;
            }

            this.Buffer.Caret.Visible = true;
            this.Highlighter.RemarkAll();
            this.Refresh();
        }

        #endregion

        private Timer _CaretTimer;
        protected void OnCaretTimer(object sender, EventArgs e)
        {
            if (true)
            {
                this.Buffer.Caret.Visible ^= true;
            }
            int marginLeft = 0;
            int marginTop  = 0;

            if (this.Buffer.isEnabledNumber) {
                marginLeft += 40;
            }

            this.Refresh();
        }
    }
}
