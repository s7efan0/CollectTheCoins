using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProZad
{
    class StationaryObstacles : Obstacles
    {
        public StationaryObstacles(PictureBox ppb, IEnumerable<PictureBox> allPictureBoxes) : base(ppb, allPictureBoxes, "stationaryObs")
        {}
    }
}
