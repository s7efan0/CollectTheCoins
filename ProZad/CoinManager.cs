using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    class CoinManager
    {
        PictureBox playerPictureBox;
        List<PictureBox> listOfCoins;
        List<PictureBox> listOfCoinsCollected;
        int maxCoins;
        int coinsCollected;
        Label score;

        LinkedList<Image> coinAnimationImages;
        LinkedListNode<Image> currentImage;

        public CoinManager(PictureBox ppb, Label sc, IEnumerable<PictureBox> allPictureBoxes)
        {
            playerPictureBox = ppb;
            this.score = sc;
            listOfCoins = new List<PictureBox>();
            listOfCoinsCollected = new List<PictureBox>();
            coinAnimationImages = new LinkedList<Image>();
            coinsCollected = 0;
            setListOfCoins(allPictureBoxes);
            maxCoins = listOfCoins.Count;
            setAnimationImages();
            currentImage = coinAnimationImages.First;
            score.Text = coinsCollected.ToString() + "/" + maxCoins.ToString();
        }

        private void setAnimationImages()
        {
            coinAnimationImages.AddLast(Properties.Resources.image_1);
            coinAnimationImages.AddLast(Properties.Resources.image_2);
            coinAnimationImages.AddLast(Properties.Resources.image_3);
            coinAnimationImages.AddLast(Properties.Resources.image_4);
            coinAnimationImages.AddLast(Properties.Resources.image_5);
            coinAnimationImages.AddLast(Properties.Resources.image_6);
            coinAnimationImages.AddLast(Properties.Resources.image_7);
            coinAnimationImages.AddLast(Properties.Resources.image_8);
            coinAnimationImages.AddLast(Properties.Resources.image_9);
            coinAnimationImages.AddLast(Properties.Resources.image_10);
            coinAnimationImages.AddLast(Properties.Resources.image_11);
            coinAnimationImages.AddLast(Properties.Resources.image_12);
            coinAnimationImages.AddLast(Properties.Resources.image_13);
            coinAnimationImages.AddLast(Properties.Resources.image_14);
            coinAnimationImages.AddLast(Properties.Resources.image_15);
            coinAnimationImages.AddLast(Properties.Resources.image_16);
        }

        private void setListOfCoins(IEnumerable<PictureBox> allPictureBoxes)
        {
            foreach (PictureBox pb in allPictureBoxes)
            {
                if (pb != null && pb.Tag != null && pb.Tag.Equals("coin"))
                {
                    listOfCoins.Add(pb);
                }
            }
        }

        public List<PictureBox> getListOfCoins()
        {
            return listOfCoins;
        }

        public void PlayAnimations()
        {
            foreach(PictureBox pb in listOfCoins)
            {
                pb.Image = currentImage.Value;
            }

            if (currentImage.Next == null)
            {
                currentImage = coinAnimationImages.First;
            }
            else
            {
                currentImage = currentImage.Next;
            }
        }

        private void update(PictureBox pb)
        {
            pb.Hide();
            coinsCollected++;
            score.Text = coinsCollected.ToString() + "/" + maxCoins.ToString();
            listOfCoinsCollected.Add(pb);
            listOfCoins.Remove(pb);
        }

        public void checkCoinCollision()
        {
            foreach (PictureBox pb in listOfCoins)
            {
                if (playerPictureBox.Bounds.IntersectsWith(pb.Bounds))
                {
                    update(pb);
                    break;
                }
            }
        }

        public void resetCoins()
        {
            listOfCoinsCollected.ForEach(p => p.Show());
            listOfCoins.AddRange(listOfCoinsCollected);
            listOfCoinsCollected.Clear();
            coinsCollected = 0;
            score.Text = coinsCollected.ToString() + "/" + maxCoins.ToString();
        }
    }
}
