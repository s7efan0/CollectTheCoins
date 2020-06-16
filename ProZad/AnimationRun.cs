using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProZad
{
    class AnimationRun : IAnimator
    {
        public PictureBox pictureBox;
        LinkedList<Image> listsOfImages;
        LinkedListNode<Image> currentImage;

        public AnimationRun(PictureBox pb)
        {
            this.pictureBox = pb;
            listsOfImages = new LinkedList<Image>();
            ICollection<Image> images = listsOfImages;
            images.Add(Properties.Resources.characterRun1R);
            images.Add(Properties.Resources.characterRun2R);
            images.Add(Properties.Resources.characterRun3R);
            images.Add(Properties.Resources.characterRun4R);
            images.Add(Properties.Resources.characterRun5R);
            images.Add(Properties.Resources.characterRun6R);
            images.Add(Properties.Resources.characterRun7R);
            images.Add(Properties.Resources.characterRun8R);
            images.Add(Properties.Resources.characterRun9R);
            images.Add(Properties.Resources.characterRun10R);
            images.Add(Properties.Resources.characterRun11R);
            images.Add(Properties.Resources.characterRun12R);
            images.Add(Properties.Resources.characterRun13R);
            images.Add(Properties.Resources.characterRun14R);
            images.Add(Properties.Resources.characterRun15R);
            images.Add(Properties.Resources.characterRun16R);
            images.Add(Properties.Resources.characterRun17R);
            images.Add(Properties.Resources.characterRun18R);

            currentImage = listsOfImages.First;
        }

        public void Animate()
        {
            pictureBox.Image = currentImage.Value;

            if (currentImage.Next == null)
            {
                currentImage = listsOfImages.First;
            }
            else
            {
                currentImage = currentImage.Next;
            }
        }

        public void reload()
        {
            currentImage = listsOfImages.First;
        }
    }
}
