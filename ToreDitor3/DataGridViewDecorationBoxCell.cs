using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;


namespace ToreDitor
{
    class DataGridViewDecorationBoxCell : DataGridViewTextBoxCell
    {
        public DataGridViewDecorationBoxCell()
            : this("")
        {
        }
        public DataGridViewDecorationBoxCell(string deco)
            : base()
        {
            switch (deco)
            {
                case "underline":

                    this.FontStyle = FontStyle.Underline;

                    break;
                case "upperline":

                    // ToDo

                    break;
                case "strikethrough":

                    this.FontStyle = FontStyle.Strikeout;

                    break;
                default:

                    this.FontStyle = FontStyle.Regular;

                    break;
            }

            this.Value = "D";
            this.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override object Clone()
        {
            var cell = (DataGridViewDecorationBoxCell)base.Clone();
            cell.FontStyle = this.FontStyle;
            return cell;
        }

        private FontStyle _fontStyle = FontStyle.Regular;
        public FontStyle FontStyle {
            get
            {
                return this._fontStyle;
            }
            set
            {
                this._fontStyle = value;

                this.Style.Font = new Font(this.Style.Font ?? SystemFonts.DefaultFont, this.FontStyle);
            }
        }
    }
}
