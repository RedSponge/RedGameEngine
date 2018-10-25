using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RedGameEngine.World
{
    public abstract class WorldEntity
    {
        protected WorldManager WorldIn;
        public float PosX { protected set; get; }
        public float PosY { protected set; get; }
        public float Width { protected set; get; }
        public float Height { protected set; get; }

        private readonly Brush representingBrush;

        public WorldEntity(WorldManager worldIn)
        {
            WorldIn = worldIn;
            PosX = PosY = 0;
            Width = Height = 20;
            representingBrush = new SolidBrush(GetRepesentingColor());
        }

        public abstract void Update();

        public void Render(Graphics g)
        {
            g.FillRectangle(representingBrush, PosX, PosY, Width, Height);
        }

        public Color GetRepesentingColor()
        {
            return Color.Black;
        }
    }
}
