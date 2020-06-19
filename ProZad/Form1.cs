using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    public partial class Form1 : Form
    {
        LevelManager lvlManager;

        public Form1(MainMenu f2)
        {
            InitializeComponent();
            lvlManager = new LevelManager(f2, this, pbPlayer, label2, Controls.OfType<PictureBox>(), Controls.OfType<Timer>());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            lvlManager.keyDown(e);
        }

        private void tMove_Tick(object sender, EventArgs e)
        {
            lvlManager.moveTick();
        }

        private void tGravity_Tick(object sender, EventArgs e)
        {
            lvlManager.gravityTick();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            lvlManager.keyUp(e);
        }

        private void tAnimator_Tick(object sender, EventArgs e)
        {
            lvlManager.animatorTick();
        }
    }
}
