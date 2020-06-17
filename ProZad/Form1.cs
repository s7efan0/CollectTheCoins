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
        CoinManager coinManager;

        public Form1()
        {
            InitializeComponent();
            player = new Player(pbPlayer, Controls.OfType<PictureBox>());
            coinManager = new CoinManager(pbPlayer, label2, Controls.OfType<PictureBox>());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            player.startMoving(e);
            if (e.KeyCode == Keys.R)
            {
                reloadLevel();
            }
        }

        private void tMove_Tick(object sender, EventArgs e)
        {
            player.move();
            coinManager.checkCoinCollision();
            if (pbPlayer.Top > 650)
            {
                reloadLevel();
            }
        }

        private void tGravity_Tick(object sender, EventArgs e)
        {
            player.gravityPull();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            player.stopMoving(e);
        }

        private void tAnimator_Tick(object sender, EventArgs e)
        {
            coinManager.PlayAnimations();
            player.playAnimation();
        }

        public void reloadLevel()
        {
            coinManager.resetCoins();
            player.reloadPlayer();
        }
    }
}
