using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class MathUtils
    {

        public static bool RectanglesIntersect(float x1, float y1, float w1, float h1, float x2, float y2, float w2, float h2)
        {
            return !(x2 > x1 + w1 || x2 + w2 < x1 || y2 > y1 + h1 || y2 + h2 < y1);
        }
    }
}
