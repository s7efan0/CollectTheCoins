using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProZad
{
    class AnimationIdleRight : IAnimator
    {
        protected Player player;
        protected LinkedList<Image> listsOfImages;
        protected LinkedListNode<Image> currentImage;
        protected int counter;

        public AnimationIdleRight(Player pl)
        {
            counter = 0;
            player = pl;
            listsOfImages = new LinkedList<Image>();
            AddResources();
            currentImage = listsOfImages.First;
        }

        protected virtual void AddResources()
        {
            listsOfImages.AddLast(Properties.Resources.characterIdle1R);
            listsOfImages.AddLast(Properties.Resources.characterIdle2R);
            listsOfImages.AddLast(Properties.Resources.characterIdle3R);
            listsOfImages.AddLast(Properties.Resources.characterIdle4R);
            listsOfImages.AddLast(Properties.Resources.characterIdle5R);
            listsOfImages.AddLast(Properties.Resources.characterIdle6R);
            listsOfImages.AddLast(Properties.Resources.characterIdle7R);
            listsOfImages.AddLast(Properties.Resources.characterIdle8R);
            listsOfImages.AddLast(Properties.Resources.characterIdle9R);
            listsOfImages.AddLast(Properties.Resources.characterIdle10R);
            listsOfImages.AddLast(Properties.Resources.characterIdle11R);
        }

        public void animate()
        {
            if (counter-- > 0)
            {
                return;
            }
            player.pictureBox.Image = currentImage.Value;
            if(currentImage.Next == null)
            {
                currentImage = listsOfImages.First;
                counter = 25;
            }
            else
            {
                currentImage = currentImage.Next;
            }
        }

        public void idle()
        {
           
        }

        public virtual void jumpDown()
        {
            reload();
            player.currentAnimation = player.animationJumpDownRight;
        }

        public virtual void jumpUp()
        {
            reload();
            player.currentAnimation = player.animationJumpUpRight;
        }

        public void reload()
        {
            counter = 0;
            currentImage = listsOfImages.First;
        }

        public virtual void startRunning()
        {
            reload();
            player.currentAnimation = player.animationRunRight;
        }

        public virtual void lookLeft()
        {
            reload();
            player.currentAnimation = player.animationIdleLeft;
        }

        public virtual void lookRight()
        {

        }
    }
}
