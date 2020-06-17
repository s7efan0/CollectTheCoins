using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProZad
{
    class AnimationIdleLeft : AnimationIdleRight
    {
        public AnimationIdleLeft(Player pl) : base(pl)
        {

        }

        protected override void AddResources()
        {
            listsOfImages.AddLast(Properties.Resources.characterIdle1L);
            listsOfImages.AddLast(Properties.Resources.characterIdle2L);
            listsOfImages.AddLast(Properties.Resources.characterIdle3L);
            listsOfImages.AddLast(Properties.Resources.characterIdle4L);
            listsOfImages.AddLast(Properties.Resources.characterIdle5L);
            listsOfImages.AddLast(Properties.Resources.characterIdle6L);
            listsOfImages.AddLast(Properties.Resources.characterIdle7L);
            listsOfImages.AddLast(Properties.Resources.characterIdle8L);
            listsOfImages.AddLast(Properties.Resources.characterIdle9L);
            listsOfImages.AddLast(Properties.Resources.characterIdle10L);
            listsOfImages.AddLast(Properties.Resources.characterIdle11L);
        }

        public override void jumpDown()
        {
            reload();
            player.currentAnimation = player.animationJumpDownLeft;
        }

        public override void jumpUp()
        {
            reload();
            player.currentAnimation = player.animationJumpUpLeft;
        }

        public override void startRunning()
        {
            reload();
            player.currentAnimation = player.animationRunLeft;
        }

        public override void lookLeft()
        {

        }

        public override void lookRight()
        {
            reload();
            player.currentAnimation = player.animationIdleRight;
        }
    }
}
