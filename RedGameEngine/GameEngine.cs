using RedGameEngine.World;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
 using RedGameEngine.Util;
using System.Collections.Generic;

namespace RedGameEngine
{
    public class GameEngine
    {
        private Form Form;

        private WorldManager worldManager;
        private Graphics g;

        private bool running;
        private Thread thread;
        private float fps;
        private readonly Font fpsFont = new Font("Courier", 20);

        private KeyHandler KeyHandler;
        private Dictionary<TickSchedule, List<Action>> ticks;

        public void AddEntity(WorldEntity entity)
        {
            worldManager.AddEntity(entity);
        }

        public GameEngine(Form form, int width=500, int height=500)
        {

 
            this.Form = form;
            this.Form.FormBorderStyle = FormBorderStyle.Fixed3D;

            // Double Buffering
            DrawPanel panel = new DrawPanel(width, height);
            Form.Controls.Add(panel);


            // No Resizing
            this.Form.MaximizeBox = false;
            //this.form.MinimizeBox = false;

            this.Form.ClientSize = new Size(width, height); // Size of form

            g = panel.CreateGraphics();
            worldManager = new WorldManager(this);
            fps = 0;

            KeyHandler = new KeyHandler(form);

            // Add Closing Event
            form.FormClosing += (sender, args) => Stop();



            ticks = new Dictionary<TickSchedule, List<Action>>();
            foreach(TickSchedule t in Enum.GetValues(typeof(TickSchedule)))
            {
                ticks[t] = new List<Action>();
            }
        }

        public void SetPlayer(WorldPlayer player)
        {
            player.KeyInput = KeyHandler;
            worldManager.SetPlayer(player);
        }

        public void Start()
        {
            running = true;
            
            // TODO: create thread which runs Loop();
            thread = new Thread(new ThreadStart(Loop));
            thread.Start();
            
        }

        public void Stop()
        {
            running = false;
        }

        public void Loop()
        {
            long now = DateTime.Now.Ticks;
            float fps = 60;
            float timeBetween = 10000000f / fps;
            long delta;
            long elapsed = 0;
            int ticks = 0;

            while(running)
            {
                delta = DateTime.Now.Ticks - now;
                if(delta > timeBetween)
                {
                    Tick();
                    Render();

                    now = DateTime.Now.Ticks;
                    ticks++;
                    elapsed += delta;
                }
                if(elapsed > timeBetween*fps)
                {
                    this.fps = ticks;
                    ticks = 0;
                    elapsed = 0;
                }
            }
        }

        public void AddTickMethod(Action tick, TickSchedule priority)
        {
            ticks[priority].Add(tick);
        }

        private void Tick()
        {
            ticks[TickSchedule.BEFORE_LOGIC].ForEach((a) => a.Invoke());

            worldManager.Tick();

            ticks[TickSchedule.BEFORE_INPUT].ForEach((a) => a.Invoke());

            KeyHandler.Tick();

            ticks[TickSchedule.AFTER_INPUT].ForEach((a) => a.Invoke());
        }

        private void Render()
        {
            g.Clear(Form.BackColor);
            worldManager.Render(g);
            //g.DrawString("" + this.fps, fpsFont, Brushes.Black, 100, 100);
            ticks[TickSchedule.AFTER_RENDER].ForEach((a) => a.Invoke());
        }
    }


    public enum TickSchedule
    {
        BEFORE_LOGIC,
        BEFORE_INPUT,
        AFTER_INPUT,
        AFTER_RENDER
    }
}
