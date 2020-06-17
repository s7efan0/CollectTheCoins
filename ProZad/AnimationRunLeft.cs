using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProZad
{
    class AnimationRunLeft : AnimationRunRight
    {
        public AnimationRunLeft(Player pl) : base(pl)
        {

        }


        override protected void AddResources()
        {
            listsOfImages.AddLast(Properties.Resources.characterRun1L);
            listsOfImages.AddLast(Properties.Resources.characterRun2L);
            listsOfImages.AddLast(Properties.Resources.characterRun3L);
            listsOfImages.AddLast(Properties.Resources.characterRun4L);
            listsOfImages.AddLast(Properties.Resources.characterRun5L);
            listsOfImages.AddLast(Properties.Resources.characterRun6L);
            listsOfImages.AddLast(Properties.Resources.characterRun7L);
            listsOfImages.AddLast(Properties.Resources.characterRun8L);
            listsOfImages.AddLast(Properties.Resources.characterRun9L);
            listsOfImages.AddLast(Properties.Resources.characterRun10L);
            listsOfImages.AddLast(Properties.Resources.characterRun11L);
            listsOfImages.AddLast(Properties.Resources.characterRun12L);
            listsOfImages.AddLast(Properties.Resources.characterRun13L);
            listsOfImages.AddLast(Properties.Resources.characterRun14L);
            listsOfImages.AddLast(Properties.Resources.characterRun15L);
            listsOfImages.AddLast(Properties.Resources.characterRun16L);
            listsOfImages.AddLast(Properties.Resources.characterRun17L);
            listsOfImages.AddLast(Properties.Resources.characterRun18L);
        }

        public override void Idle()
        {
            player.currentAnimation = player.animationIdleLeft;
        }

        public override void jumpDown()
        {
            player.currentAnimation = player.animationJumpDownLeft;
        }

        public override void jumpUp()
        {
            player.currentAnimation = player.animationJumpUpLeft;
        }

        public override void lookLeft()
        {

        }

        public override void lookRight()
        {
            player.currentAnimation = player.animationRunRight;
        }
    }
}
