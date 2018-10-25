using RedGameEngine.World;

namespace WindowsFormsApp1
{
    public class SuperPlayer : WorldPlayer
    {
        public SuperPlayer()
        {
            PosX = 0;
            PosY = 0;
            vy = 0;
        }
        float vy;
        public override void Update()
        {
            vy += 0.1f;
            PosY += vy;
        }
    }
}