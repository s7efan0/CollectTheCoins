using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProZad
{
    class AnimationJumpDownRight : IAnimator
    {
        protected Player player;
        protected Image imageJumpDown;

        public AnimationJumpDownRight(Player pl)
        {
            player = pl;
            imageJumpDown = Properties.Resources.characterJumpDownR;
        }

        public void animate()
        {
            player.pictureBox.Image = imageJumpDown;
        }

        public virtual void Idle()
        {
            player.currentAnimation = player.animationIdleRight;
        }

        public void jumpDown()
        {
            reload();
        }

        public virtual void jumpUp()
        {
            player.currentAnimation = player.animationJumpUpRight;
        }

        public void reload()
        {
            player.pictureBox.Image = imageJumpDown;
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
