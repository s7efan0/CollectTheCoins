using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProZad
{
    class AnimationJumpUpLeft : AnimationJumpUpRight
    {
        public AnimationJumpUpLeft(Player pl) : base(pl)
        {
            imageJumpUp = Properties.Resources.characterJumpUpL;
        }

        public override void idle()
        {
            player.currentAnimation = player.animationIdleLeft;
        }

        public override void jumpDown()
        {
            player.currentAnimation = player.animationJumpDownLeft;
        }

        public override void startRunning()
        {
            player.currentAnimation = player.animationRunLeft;
        }

        public override void lookLeft()
        {

        }

        public override void lookRight()
        {
            player.currentAnimation = player.animationJumpDownRight;
        }
    }
}
