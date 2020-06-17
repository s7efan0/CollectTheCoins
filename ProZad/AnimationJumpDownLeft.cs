using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProZad
{
    class AnimationJumpDownLeft : AnimationJumpDownRight
    {
        public AnimationJumpDownLeft(Player pl) : base(pl)
        {
            imageJumpDown = Properties.Resources.characterJumpDownL;
        }

        public override void Idle()
        {
            player.currentAnimation = player.animationIdleLeft;
        }

        public override void jumpUp()
        {
            player.currentAnimation = player.animationJumpUpLeft;
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
