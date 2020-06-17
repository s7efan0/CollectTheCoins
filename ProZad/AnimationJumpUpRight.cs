using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProZad
{
    class AnimationJumpUpRight : IAnimator
    {
        protected Player player;
        protected Image imageJumpUp;

        public AnimationJumpUpRight(Player pl)
        {
            player = pl;
            imageJumpUp = Properties.Resources.characterJumpUpR;
        }

        public void animate()
        {
            player.pictureBox.Image = imageJumpUp;
        }

        public virtual void Idle()
        {
            player.currentAnimation = player.animationIdleRight;
        }

        public virtual void jumpDown()
        {
            player.currentAnimation = player.animationJumpDownRight;
        }

        public void jumpUp()
        {
            reload();
        }

        public void reload()
        {
            player.pictureBox.Image = imageJumpUp;
        }

        public virtual void startRunning()
        {
            player.currentAnimation = player.animationRunRight;
        }

        public virtual void lookLeft()
        {
            player.currentAnimation = player.animationJumpDownLeft;
        }

        public virtual void lookRight()
        {

        }
    }
}
