using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    abstract class Obstacles
    {
        protected List<PictureBox> listOfObstacles;
        protected PictureBox playerPictureBox;

        public Obstacles(PictureBox ppb, IEnumerable<PictureBox> allPictureBoxes, String tag)
        {
            listOfObstacles = new List<PictureBox>();
            playerPictureBox = ppb;
            setAllObstacles(allPictureBoxes, tag);
        }

        public void setAllObstacles(IEnumerable<PictureBox> allPictureBoxes, String tag)
        {
            foreach (PictureBox pb in allPictureBoxes)
            {
                if (pb != null && pb.Tag != null && pb.Tag.Equals(tag))
                {
                    listOfObstacles.Add(pb);
                }
            }
        }

        public bool collidesWithPlayer()
        {
            foreach (PictureBox pb in listOfObstacles)
            {
                if (pb.Bounds.IntersectsWith(playerPictureBox.Bounds) && 
                    ( (playerPictureBox.Left + 25 >= pb.Left && playerPictureBox.Left + 25 <= pb.Left + pb.Width) 
                    || (playerPictureBox.Left + playerPictureBox.Width - 25 >= pb.Left && playerPictureBox.Left + playerPictureBox.Width - 25 <= pb.Left + pb.Width) 
                    || (playerPictureBox.Left + playerPictureBox.Width / 2 >= pb.Left && playerPictureBox.Left + playerPictureBox.Width / 2 <= pb.Left + pb.Width)))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
