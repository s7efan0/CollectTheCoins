using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    class Player
    {
        public PictureBox pictureBox;
        private bool movingLeft, movingRight, playerMidAir;
        private const int playerSpeed = 5, gravity = 5;
        private int force = 0;
        List<PictureBox> groundPictureBoxes;

        AnimationIdle animationIdle;
        AnimationRun animationRun;
        IAnimator currentAnimation;



        public Player(PictureBox pb, IEnumerable<PictureBox> groundsEnumerable)
        {
            this.pictureBox = pb;
            movingLeft = movingRight = false;
            playerMidAir = true;
            setGroundPictureBoxes(groundsEnumerable);
            animationIdle = new AnimationIdle(pb);
            animationRun = new AnimationRun(pb);
            currentAnimation = animationIdle;
        }

        private void setGroundPictureBoxes(IEnumerable<PictureBox> groundsEnumerable)
        {
            groundPictureBoxes = new List<PictureBox>();
            foreach(PictureBox pb in groundsEnumerable)
            {
                if(pb != null && pb.Tag != null && pb.Tag.Equals("ground"))
                {
                    groundPictureBoxes.Add(pb);
                }
            }
        }

        public void startMoving(KeyEventArgs e)
        {
            currentAnimation = animationRun;
            if (e.KeyCode == Keys.Left)
            {
                this.movingLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.movingRight = true;
            }
            if (e.KeyCode == Keys.Up && !this.playerMidAir)
            {
                this.force = 20;
            }
        }

        public void move()
        {
            if (this.movingLeft)
            {
                pictureBox.Left -= Player.playerSpeed;
            }
            if (this.movingRight)
            {
                pictureBox.Left += Player.playerSpeed;
            }
            if (pictureBox.Top > 650)
            {
                //Reload level
                pictureBox.Top = 315;
                pictureBox.Left = 178;
            }
        }

        public void stopMoving(KeyEventArgs e)
        {
            currentAnimation = animationIdle;
            currentAnimation.reload();
            if (e.KeyCode == Keys.Left)
            {
                this.movingLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.movingRight = false;
            }
        }

        public void gravityPull()
        {
            playerMidAir = isPlayerMidAir();

            if (playerMidAir)
            {
                if (force <= 0)
                { 
                    //pictureBox.Image = ProZad.Properties.Resources.cf;
                    pictureBox.Top += gravity;
                }
                else
                {
                    //pictureBox.Image = ProZad.Properties.Resources.cj;
                    force -= 1;
                    pictureBox.Top -= gravity;
                }
            }
            else
            {
                if (force > 0)
                {
                    //pictureBox.Image = ProZad.Properties.Resources.cj;
                    pictureBox.Top -= gravity;
                }
                else
                { 
                    //pictureBox.Image = ProZad.Properties.Resources.c2;
                }
            }
        }

        private bool isPlayerMidAir()
        {
            foreach (PictureBox pb in groundPictureBoxes)
            {
                if (pictureBox.Bounds.IntersectsWith(pb.Bounds))
                {
                    return false;
                }
            }
            return true;
        }

        public void playAnimation()
        {
            currentAnimation.Animate();
        }
    }
}
