using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorClock
{
    public enum AngleType
    {
        Undefined = 0,

        Radians = 1,
        Degrees = 2,
    }

    public struct Angle
    {
        private float _Radians;
        private float _Degrees;

        public Angle (float aValue, AngleType aType)
        {
            if (aType == AngleType.Radians)
            {
                _Radians = aValue;
                _Degrees = RadToDeg(aValue);
            }
            else if (aType == AngleType.Degrees)
            {
                _Degrees = aValue;
                _Radians = DegToRad(aValue);
            }
            else
            {
                _Degrees = 0;
                _Radians = 0;
            }
        }

        public float Radians
        {
            get { return _Radians; }
            set
            {

            }
        }

        public float Degrees
        {
            get { return _Degrees; }
            set
            {

            }
        }



        public static float DegToRad (float aDegrees)
        {
            return (float) (aDegrees * (Math.PI / 180));
        }

        public static float RadToDeg (float aRadians)
        {
            return (float) (aRadians * (180 / Math.PI));
        }
    }



    class MathUtils
    {
    }
}
