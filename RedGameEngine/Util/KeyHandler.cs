using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedGameEngine.Util
{
    public class KeyHandler
    {
        private bool[] keys;
        private bool[] keyPresses;

        public KeyHandler(Form form, int support = 256)
        {
            keys = new bool[support];
            keyPresses = new bool[support];

            form.KeyDown += (sender, args) => KeyDown((int)args.KeyCode);
            form.KeyUp += (sender, args) => KeyUp((int)args.KeyCode);
        }


        // For JustPressed and JustReleased, called before entity ticks
        public void Tick()
        {
            for(int i = 0; i < keys.Length; i++) {
                keyPresses[i] = keys[i];    
            }
        }

        public bool IsPressed(Keys key)
        {
            return keys[(int)key];
        }

        public bool IsReleased(Keys key)
        {
            return !keys[(int)key];
        }

        public bool JustPressed(Keys key)
        {
            return keys[(int)key] && !keyPresses[(int)key];
        }

        public bool JustReleased(Keys key)
        {
            return !keys[(int)key] && keyPresses[(int)key];
        }

        private void KeyDown(int keycode)
        {
            keys[keycode] = true;
        }

        private void KeyUp(int keycode)
        {
            keys[keycode] = false;
        }
    }
}
