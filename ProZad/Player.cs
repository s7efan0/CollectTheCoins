using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    class Player
    {
        public PictureBox pictureBox;
        public bool movingLeft, movingRight, playerMidAir;
        public int playerSpeed, gravity, force;
        List<PictureBox> groundPictureBoxes;

        public Player(PictureBox pb, IEnumerable<PictureBox> groundsEnumerable)
        {
            this.pictureBox = pb;
            movingLeft = movingRight = false;
            playerMidAir = true;
            playerSpeed = 5;
            gravity = 5;
            force = 0;
            setGroundPictureBoxes(groundsEnumerable);
        }

        private void setGroundPictureBoxes(IEnumerable<PictureBox> groundsEnumerable)
        {
            groundPictureBoxes = new List<PictureBox>();
            foreach(PictureBox pb in groundsEnumerable)
            {
                if(pb != null && pb.Tag != null && pb.Tag.Equals("ground"))
                {
                    groundPictureBoxes.Add(pb);
                }
            }
        }

        public void gravityPull()
        {
            playerMidAir = isPlayerMidAir();

            if (playerMidAir)
            {
                if (force <= 0)
                { 
                    pictureBox.Image = ProZad.Properties.Resources.cf;
                    pictureBox.Top += gravity;
                }
                else
                {
                    pictureBox.Image = ProZad.Properties.Resources.cj;
                    force -= 1;
                    pictureBox.Top -= gravity;
                }
            }
            else
            {
                if (force > 0)
                {
                    pictureBox.Image = ProZad.Properties.Resources.cj;
                    pictureBox.Top -= gravity;
                }
                else
                { 
                    pictureBox.Image = ProZad.Properties.Resources.c2;
                }
            }
        }

        private bool isPlayerMidAir()
        {
            foreach (PictureBox pb in groundPictureBoxes)
            {
                if (pictureBox.Bounds.IntersectsWith(pb.Bounds))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
