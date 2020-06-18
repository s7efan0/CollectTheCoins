using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    class MovingObstacles : Obstacles
    {
        bool directionUp;
        int counter;
        int movingSpeed;
        public MovingObstacles(PictureBox ppb, IEnumerable<PictureBox> allPictureBoxes) : base(ppb, allPictureBoxes, "movingObs")
        {
            directionUp = false;
            counter = 35;
            movingSpeed = 3;
        }

        public void moveObstacles()
        {
            if (counter-- == 0)
            {
                directionUp = !directionUp;
                counter = 35;
                movingSpeed = -movingSpeed;
            }
            listOfObstacles.ForEach(obs => obs.Top += movingSpeed);
        }
    }
}
