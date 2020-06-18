using System;
using System.Collections.Generic;
using System.Drawing;
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

        public AnimationIdleRight animationIdleRight;
        public AnimationRunRight animationRunRight;
        public AnimationJumpDownRight animationJumpDownRight;
        public AnimationJumpUpRight animationJumpUpRight;

        public AnimationIdleLeft animationIdleLeft;
        public AnimationRunLeft animationRunLeft;
        public AnimationJumpDownLeft animationJumpDownLeft;
        public AnimationJumpUpLeft animationJumpUpLeft;
        public IAnimator currentAnimation;

        public String orientation = "Right";

        public Player(PictureBox pb, IEnumerable<PictureBox> allPictureBoxes)
        {
            this.pictureBox = pb;
            movingLeft = movingRight = false;
            playerMidAir = true;
            setAnimations();
            setGroundPictureBoxes(allPictureBoxes);
        }

        private void setAnimations()
        {
            this.animationIdleRight = new AnimationIdleRight(this);
            this.animationRunRight = new AnimationRunRight(this);
            this.animationJumpDownRight = new AnimationJumpDownRight(this);
            this.animationJumpUpRight = new AnimationJumpUpRight(this);

            this.animationIdleLeft = new AnimationIdleLeft(this);
            this.animationRunLeft = new AnimationRunLeft(this);
            this.animationJumpDownLeft = new AnimationJumpDownLeft(this);
            this.animationJumpUpLeft = new AnimationJumpUpLeft(this);
            currentAnimation = animationJumpDownRight;
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
            if (e.KeyCode == Keys.Left && !movingRight)
            {
                this.orientation = "Left";
                currentAnimation.lookLeft();
                this.movingLeft = true;
            }
            if (e.KeyCode == Keys.Right && !movingLeft)
            {
                this.orientation = "Right";
                currentAnimation.lookRight();
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
        }

        public void reloadPlayer()
        {
            //Reload level
            pictureBox.Top = 420;
            pictureBox.Left = 55;
        }

        public void stopMoving(KeyEventArgs e)
        {
            playerMidAir = !isPlayerOnGround();
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
            playerMidAir = !isPlayerOnGround();
            if (playerMidAir)
            {
                if (force <= 0)
                {
                    pictureBox.Top += gravity;
                }
                else
                {
                    force -= 1;
                    pictureBox.Top -= gravity;
                }
            }
            else
            {
                if (force > 0)
                {
                    pictureBox.Top -= gravity;
                }
            }
        }

        private void animationStateChange()
        {
            if (playerMidAir)
            {
                if (force <= 0)
                {
                    currentAnimation.jumpDown();
                }
                else
                {
                    currentAnimation.jumpUp();
                }
            }
            else
            {
                if (force <= 0)
                {
                    if (movingLeft || movingRight)
                    {
                        currentAnimation.startRunning();
                    }
                    else
                    {
                        currentAnimation.Idle();
                    }
                }
                else
                {
                    currentAnimation.jumpUp();
                }
            }
        }

        private bool isPlayerColladingWithGround() // todo add collading with obstacles
        {
            foreach (PictureBox pb in groundPictureBoxes)
            {
                if (pictureBox.Bounds.IntersectsWith(pb.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        private bool isPlayerOnGround()
        {
            foreach (PictureBox pb in groundPictureBoxes)
            {
                if (pictureBox.Bounds.IntersectsWith(pb.Bounds) && (pictureBox.Location.Y + pictureBox.Height) <= pb.Location.Y + 5)
                {
                    return true;
                }
            }
            return false;
        }

        public void playAnimation()
        {
            animationStateChange();
            currentAnimation.animate();
        }
    }
}
