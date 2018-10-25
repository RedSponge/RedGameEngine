using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedGameEngine;
using RedGameEngine.World;

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
            engine = new GameEngine(this);
            engine.CreatePlayer(new SuperPlayer());


            engine.Start();
        }
    }
        
}
