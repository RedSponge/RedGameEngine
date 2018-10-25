using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedGameEngine.Util
{
    internal class DrawPanel : Panel
    {
        public DrawPanel(int width, int height)
        {
            this.Size = new Size(width, height);
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
            this.Location = new Point(0, 0);
        }
    }
}
