using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    class LevelManager
    {
        Player player;
        CoinManager coinManager;
        MovingObstacles movingObstacles;
        StationaryObstacles stationaryObstacles;
        bool gamePaused;
        List<Timer> timers;
        MainMenu main;
        Form parent;

        public LevelManager(MainMenu m, Form p,PictureBox pbPlayer, Label lbl, IEnumerable<PictureBox> pictureBoxes, IEnumerable<Timer> t)
        {
            player = new Player(pbPlayer, pictureBoxes);
            coinManager = new CoinManager(pbPlayer, lbl, pictureBoxes);
            movingObstacles = new MovingObstacles(pbPlayer, pictureBoxes);
            stationaryObstacles = new StationaryObstacles(pbPlayer, pictureBoxes);
            gamePaused = false;
            timers = t.ToList();
            main = m;
            parent = p;
        }


        public void keyDown(KeyEventArgs e)
        {
            player.startMoving(e);
            if (e.KeyCode == Keys.R)
            {
                reloadLevel();
            }
            if (e.KeyCode == Keys.P)
            {
                gamePaused = !gamePaused;
                pauseGame(gamePaused);
            }
        }

        public void moveTick()
        {
            player.move();
            coinManager.checkCoinCollision();
            if (player.pictureBox.Top > 650 || movingObstacles.collidesWithPlayer() || stationaryObstacles.collidesWithPlayer())
            {
                reloadLevel();
            }
            if (coinManager.allCoinsCollected())
            {
                main.goBack(parent);
            }
        }

        public void gravityTick()
        {
            player.gravityPull();
        }

        public void keyUp(KeyEventArgs e)
        {
            player.stopMoving(e);
        }

        public void animatorTick()
        {
            coinManager.PlayAnimations();
            player.playAnimation();
            movingObstacles.moveObstacles();
        }

        public void reloadLevel()
        {
            coinManager.resetCoins();
            player.reloadPlayer();
        }

        public void pauseGame(bool gp)
        {
            foreach(Timer t in timers)
            {
                t.Enabled = gp;
            }
        }
    }
}
