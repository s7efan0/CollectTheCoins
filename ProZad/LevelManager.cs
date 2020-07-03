using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ProZad
{
    class LevelManager
    {
        Player player;
        CoinManager coinManager;
        MovingObstacles movingObstacles;
        StationaryObstacles stationaryObstacles;
        MainMenu main;
        Form parent;
        int lvlKey;

        public LevelManager(MainMenu m, int lvlkey,Form p,PictureBox pbPlayer, Label lbl, IEnumerable<PictureBox> pictureBoxes)
        {
            player = new Player(pbPlayer, pictureBoxes);
            coinManager = new CoinManager(pbPlayer, lbl, pictureBoxes);
            movingObstacles = new MovingObstacles(pbPlayer, pictureBoxes);
            stationaryObstacles = new StationaryObstacles(pbPlayer, pictureBoxes);
            main = m;
            parent = p;
            this.lvlKey = lvlkey;
        }


        public void keyDown(KeyEventArgs e)
        {
            player.startMoving(e);
            if (e.KeyCode == Keys.R)
            {
                reloadLevel();
            }
            if (e.KeyCode == Keys.Escape)
            {
                main.goBackToMainMenu(parent, false, lvlKey);
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
                main.goBackToMainMenu(parent, true, lvlKey);
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
    }
}
