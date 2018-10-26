using RedGameEngine.World;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class SuperPlayer : WorldPlayer
    {
        public SuperPlayer()
        {
            PosX = 250;
            PosY = 250;
            vy = 0;
        }
        float vy;
        public override void Update()
        {
            if (dead) return;
            vy += 0.1f;
            if(KeyInput.JustPressed(Keys.Space))
            {
                vy = -5;
            }
            PosY += vy;
        }
        

        [Interaction(type=typeof(MyEntity))]
        public void InteractionWithMyEntity(MyEntity e)
        {
            if (MathUtils.RectanglesIntersect(PosX, PosY, Width, Height, e.PosX, e.PosY, e.Width, e.Height)) dead = true;
        }
    }
}