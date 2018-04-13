using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorClock
{
    class MathUtils
    {
        public static float DegToRad (float aDegrees)
        {
            return (float) (aDegrees * (Math.PI / 180));
        }

        public static float RadToDeg (float aRadians)
        {
            return (float) (aRadians * (180 / Math.PI));
        }
    }
}
