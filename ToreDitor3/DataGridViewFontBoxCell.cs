using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ToreDitor
{
    class DataGridViewFontBoxCell : DataGridViewTextBoxCell
    {
        public DataGridViewFontBoxCell()
            : this("")
        {
        }
        public DataGridViewFontBoxCell(string font)
            : base()
        {
            switch (font)
            {
                case "bold":

                    this.FontStyle = FontStyle.Bold;

                    break;
                case "italic":

                    this.FontStyle = FontStyle.Italic;

                    break;
                default:

                    this.FontStyle = FontStyle.Regular;

                    break;
            }

            this.Value = "F";
            this.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public override object Clone()
        {
            var cell = (DataGridViewFontBoxCell)base.Clone();
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

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            var dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.FontStyle = dialog.Font.Style;
            }
        }
    }
}
