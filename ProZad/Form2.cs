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
    public partial class Form2 : Form
    {
        LevelManager levelManager;

        public Form2(MainMenu mm, int lvlKey)
        {
            InitializeComponent();
            levelManager = new LevelManager(mm, lvlKey,this, pbPlayer, label1, Controls.OfType<PictureBox>());
        }

        private void tGravity_Tick(object sender, EventArgs e)
        {
            levelManager.gravityTick();
        }

        private void tMove_Tick(object sender, EventArgs e)
        {
            levelManager.moveTick();
        }

        private void tAnimator_Tick(object sender, EventArgs e)
        {
            levelManager.animatorTick();
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            levelManager.keyUp(e);
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            levelManager.keyDown(e);
        }
    }
}
