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

        Player player;

        public Form1()
        {
            InitializeComponent();
            player = new Player(pbPlayer, Controls.OfType<PictureBox>());

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.movingLeft= true;
            }
            if (e.KeyCode == Keys.Right)
            {
                player.movingRight = true;
            }
            if (e.KeyCode == Keys.Up && !player.playerMidAir)
            {
                player.force = 20;
            }
        }

        private void tMove_Tick(object sender, EventArgs e)
        {
            if (player.movingLeft)
            {
                pbPlayer.Left -= player.playerSpeed;
            }
            if (player.movingRight)
            {
                pbPlayer.Left += player.playerSpeed;
            }
            if (pbPlayer.Top > 650)
            {
                pbPlayer.Top = 315;
                pbPlayer.Left = 178;
            }
        }

        private void tGravity_Tick(object sender, EventArgs e)
        {
            player.gravityPull();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.movingLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                player.movingRight = false;
            }
        }
    }
}
