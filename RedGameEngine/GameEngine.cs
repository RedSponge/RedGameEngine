using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedGameEngine
{
    public class GameEngine
    {
        private Form form;
        
        public GameEngine(Form form)
        {
            this.form = form;
        }


        public static implicit operator GameEngine(Form f)
        {
            return new GameEngine(f);
        }
    }
}
