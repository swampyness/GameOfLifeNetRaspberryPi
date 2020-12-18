using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifeNet
{
    public partial class Form1 : Form
    {
        Life Life;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Life = new Life();
            Life.PictureBox = PictureBoxCanvas;
            Life.Init();
            TimerTick.Interval = 1;
            TimerTick.Enabled = true;
        }

        private void TimerTick_Tick(object sender, EventArgs e)
        {
            Life.Draw();
        }
    }
}
