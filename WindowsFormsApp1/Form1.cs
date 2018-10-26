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
            player = new SuperPlayer();
            engine.SetPlayer(player);

            engine.AddTickMethod(SpawnerTick, TickSchedule.BEFORE_LOGIC);
            engine.AddTickMethod(EngineEnder, TickSchedule.AFTER_RENDER);

            engine.Start();
        }

        private int i;
        private SuperPlayer player;
        public void EngineEnder()
        {
            if (player.dead) engine.Stop();
        }

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
