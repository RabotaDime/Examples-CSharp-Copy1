using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace VectorClock
{
    public struct Vector2D
    {
        public float A;
        public float B;



        public Vector2D (float aA, float aB)
        {
            A = aA;
            B = aB;
        }



        public float Length
        {
            get { return (float) Math.Sqrt((A * A) + (B * B)); }
        }



        public static Vector2D UnitVectorFromAngleD (float aDegrees)
        {
            float Radians = MathUtils.DegToRad(aDegrees);

            return new Vector2D
            (
                (float) Math.Cos( Radians ),
                (float) Math.Sin( Radians )
            );
        }



        public float GetCrossProduct (Vector2D aOtherVector)
        {
            return (this.A * aOtherVector.B) - (this.B * aOtherVector.A);
        }



        public float GetDotProduct (Vector2D aOtherVector)
        {
            return (this.A * aOtherVector.A) + (this.B * aOtherVector.B);
        }



        public float GetAngleBetween (Vector2D aOtherVector)
        {
            return (float) Math.Acos
            (
                this.GetDotProduct(aOtherVector) /
                (this.Length * aOtherVector.Length)
            );
        }



/*
        public float GetAngleBetween2 (Vector2D aOtherVector)
        {
            return 0;// this.Length * aOtherVector.Length * Math.Sin()
            return (float) Math.Atan2
            (
                this.GetCrossProduct(aOtherVector) /
                (this.Length * aOtherVector.Length)
            );
        }
*/
    }
}
