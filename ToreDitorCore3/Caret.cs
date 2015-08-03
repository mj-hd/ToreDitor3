using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ToreDitorCore
{
    public class Caret
    {
    
        public int X
        {
            get { return this._Point.X; }
            set { this._Point.X = value; }
        }

        public int Y
        {
            get { return this._Point.Y; }
            set { this._Point.Y = value; }
        }

        public Point Point
        {
            get { return this._Point; }
            set { this._Point = value; }
        }

        public Boolean Visible
        {
            get { return this._Visible; }
            set { this._Visible = value; }
        }
        
        private Point _Point     = new Point();
        private Boolean _Visible = true;
    }
}
