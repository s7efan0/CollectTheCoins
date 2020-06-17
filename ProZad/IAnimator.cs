using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProZad
{
    interface IAnimator
    {
        void animate();

        void reload();

        void startRunning();

        void Idle();

        void jumpUp();

        void jumpDown();

        void lookLeft();

        void lookRight();
    }
}
