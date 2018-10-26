using System;
using System.Windows.Forms;
using RedGameEngine;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private GameEngine engine;

        public void Form1_Load(object sender, EventArgs args)
        {
            i = 0;

            engine = new GameEngine(this);
            engine.CreatePlayer(new SuperPlayer());

            engine.AddTickMethod(SpawnerTick, TickPriority.BEFORE_LOGIC);

            engine.Start();
        }

        private int i;
        public void SpawnerTick()
        {
            i++;
            if(i % 60 == 0)
            {
                engine.AddEntity(new MyEntity());
            }
        }
    }
}
