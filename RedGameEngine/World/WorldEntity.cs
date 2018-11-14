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
        public WorldManager WorldIn { get; internal set; }
        public float PosX { protected set; get; }
        public float PosY { protected set; get; }
        public float Width { protected set; get; }
        public float Height { protected set; get; }

        private readonly Brush representingBrush;

        public bool dead;


        public WorldEntity(WorldManager worldIn = null)
        {
            WorldIn = worldIn;
            PosX = PosY = 0;
            Width = Height = 20;
            representingBrush = new SolidBrush(GetRepesentingColor());
            dead = false;
        }

        public abstract void Update();

        public virtual void Render(Graphics g)
        {
            g.FillRectangle(representingBrush, PosX, PosY, Width, Height);
        }

        public virtual Color GetRepesentingColor()
        {
            return Color.Black;
        }
    }
}
