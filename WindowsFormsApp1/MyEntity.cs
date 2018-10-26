using RedGameEngine.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MyEntity : WorldEntity
    {
        public MyEntity()
        {
            Random random = new Random();
            PosX = random.Next((int)(500 - Width));
            PosY = random.Next((int)(500 - Width));
            VX = random.Next(10)-5;
            VY = random.Next(10)-5;
            counter = 0;
        }

        public int VX;
        public int VY;
        private int counter;
        public override void Update()
        {
            PosX += VX;
            PosY += VY;
            if (PosX < 0 || PosX + Width > 500) VX *= -1;
            if (PosY < 0 || PosY + Height > 500) VY *= -1;
            counter++;
            if(counter > 100)
            {
                dead = true;
            }
        }
    }
}
