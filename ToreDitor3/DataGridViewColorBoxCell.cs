using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ToreDitor
{
    public class DataGridViewColorBoxCell : DataGridViewTextBoxCell
    {
        public DataGridViewColorBoxCell(Color color)
            : base()
        {
            this.Color = color;

            this.UpdateValue();
        }
        public DataGridViewColorBoxCell(string color)
            : this(ColorTranslator.FromHtml(color))
        {
        }

        public override object Clone()
        {
            var cell = (DataGridViewColorBoxCell)base.Clone();
            cell.Color = this.Color;
            return cell;
        }

        private Color _color = Color.Transparent;
        public Color Color
        {
            get
            {
                return this._color;
            }
            set
            {
                this._color = value;
                this.UpdateValue();

                this.DataGridView?.InvalidateCell(this);
            }
        }

        protected void UpdateValue()
        {
            if (this.Color.A == 0)
            {
                this.Value = "";
                return;
            }

            // WORK AROUND
            this.Value = $"      #{this.Color.R.ToString("X2")}{this.Color.G.ToString("X2")}{this.Color.B.ToString("X2")}";
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            this.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            var brush = new SolidBrush(this.Color);
            var pen = new Pen(new SolidBrush(SystemColors.ActiveBorder), 1.5f)
            {
                LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel
            };
            var rect = new Rectangle(cellBounds.X + 2, cellBounds.Y + 2, 20, cellBounds.Height - 6);

            if (this.Color.A == 0)
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            }

            graphics.FillRectangle(brush, rect);
            graphics.DrawRectangle(pen, rect);

        }

        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
            var dialog = new ColorDialog();

            dialog.Color = this.Color;
            dialog.SolidColorOnly = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Color = dialog.Color;
            };
        }

        protected override Size GetSize(int rowIndex)
        {
            return base.GetSize(rowIndex) + new Size(100, 0);
        }
    }
}
