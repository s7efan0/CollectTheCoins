using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProZad
{
    class AnimationRunRight : IAnimator
    {
        protected Player player;
        protected LinkedList<Image> listsOfImages;
        protected LinkedListNode<Image> currentImage;

        public AnimationRunRight(Player pl)
        {
            this.player = pl;
            listsOfImages = new LinkedList<Image>();
            AddResources();
            currentImage = listsOfImages.First;
        }

        protected virtual void AddResources()
        {
            listsOfImages.AddLast(Properties.Resources.characterRun1R);
            listsOfImages.AddLast(Properties.Resources.characterRun2R);
            listsOfImages.AddLast(Properties.Resources.characterRun3R);
            listsOfImages.AddLast(Properties.Resources.characterRun4R);
            listsOfImages.AddLast(Properties.Resources.characterRun5R);
            listsOfImages.AddLast(Properties.Resources.characterRun6R);
            listsOfImages.AddLast(Properties.Resources.characterRun7R);
            listsOfImages.AddLast(Properties.Resources.characterRun8R);
            listsOfImages.AddLast(Properties.Resources.characterRun9R);
            listsOfImages.AddLast(Properties.Resources.characterRun10R);
            listsOfImages.AddLast(Properties.Resources.characterRun11R);
            listsOfImages.AddLast(Properties.Resources.characterRun12R);
            listsOfImages.AddLast(Properties.Resources.characterRun13R);
            listsOfImages.AddLast(Properties.Resources.characterRun14R);
            listsOfImages.AddLast(Properties.Resources.characterRun15R);
            listsOfImages.AddLast(Properties.Resources.characterRun16R);
            listsOfImages.AddLast(Properties.Resources.characterRun17R);
            listsOfImages.AddLast(Properties.Resources.characterRun18R);
        }

        public void animate()
        {
            player.pictureBox.Image = currentImage.Value;            

            if (currentImage.Next == null)
            {
                currentImage = listsOfImages.First;
            }
            else
            {
                currentImage = currentImage.Next;
            }
        }

        public virtual void Idle()
        {
            player.currentAnimation = player.animationIdleRight;
        }

        public virtual void jumpDown()
        {
            player.currentAnimation = player.animationJumpDownRight;
        }

        public virtual void jumpUp()
        {
            player.currentAnimation = player.animationJumpUpRight;
        }

        public void reload()
        {
            currentImage = listsOfImages.First;
        }

        public void startRunning()
        {

        }

        public virtual void lookLeft()
        {
            player.currentAnimation = player.animationRunLeft;
        }

        public virtual void lookRight()
        {

        }
    }
}
