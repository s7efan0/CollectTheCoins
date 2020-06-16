using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProZad
{
    class AnimationIdle : IAnimator
    {
        public PictureBox pictureBox;
        LinkedList<Image> listsOfImages;
        LinkedListNode<Image> currentImage;
        int counter;

        public AnimationIdle(PictureBox pb)
        {
            counter = 0;
            this.pictureBox = pb;
            listsOfImages = new LinkedList<Image>();
            ICollection<Image> images = listsOfImages;
            images.Add(Properties.Resources.characterIdle1R);
            images.Add(Properties.Resources.characterIdle2R);
            images.Add(Properties.Resources.characterIdle3R);
            images.Add(Properties.Resources.characterIdle4R);
            images.Add(Properties.Resources.characterIdle5R);
            images.Add(Properties.Resources.characterIdle6R);
            images.Add(Properties.Resources.characterIdle7R);
            images.Add(Properties.Resources.characterIdle8R);
            images.Add(Properties.Resources.characterIdle9R);
            images.Add(Properties.Resources.characterIdle10R);
            images.Add(Properties.Resources.characterIdle11R);
            currentImage = listsOfImages.First;
        }

        public void Animate()
        {
            if (counter-- > 0)
            {
                return;
            }
            pictureBox.Image = currentImage.Value;

            if(currentImage.Next == null)
            {
                currentImage = listsOfImages.First;
                counter = 50;
            }
            else
            {
                currentImage = currentImage.Next;
            }
        }

        public void reload()
        {
            counter = 0;
            currentImage = listsOfImages.First;
        }
    }
}
