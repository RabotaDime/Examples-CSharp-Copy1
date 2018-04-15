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



        public override string ToString ()
        {
            return "[" + ((double) A).ToString() + ", " + ((double) B).ToString() + "]";
        }



        public float Length
        {
            get { return (float) Math.Sqrt((A * A) + (B * B)); }
        }

        public Angle Angle
        {
            get
            {
                float AngleVal = this.GetAngleBetween(XAxis).Degrees;

                //  Изменяем угол для нижних квадрантов (третьего (III) и четвертого (IV))
                if (B < 0) AngleVal *= -1;

                //  Результатом будет угол в градусах от -180.0 до +180.0, в зависимости
                //  от направления вектора. 
                return new Angle(AngleVal, AngleType.Degrees);
            }
        }



        public static Vector2D XAxis { get { return new Vector2D (1, 0); } }
        public static Vector2D YAxis { get { return new Vector2D (0, 1); } }

        public static Vector2D UnitVectorFromAngle (Angle aAngle)
        {
            //     
            // 1.0 --...           Unit Circle
            //     .     /| .     / 
            //     .    / |    . /  
            //     .   /  |      .
            //     .V /   | Vy = sin
            //     . /    |        .
            //     ./    _|         .
            //     /____|_|.........|
            //        Vx = cos     1.0 
            //
            return new Vector2D
            (
                (float) Math.Cos( aAngle.Radians ),
                (float) Math.Sin( aAngle.Radians )
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



        public Angle GetAngleBetween (Vector2D aOtherVector)
        {
            float AngleVal = (float) Math.Acos
            (
                this.GetDotProduct(aOtherVector) /
                (this.Length * aOtherVector.Length)
            );

            return new Angle(AngleVal, AngleType.Radians);
        }

        public Angle GetAngleBetween2 (Vector2D aOtherVector)
        {
            float AngleVal = (float) Math.Atan2
            (
                this.GetCrossProduct    (aOtherVector),
                this.GetDotProduct      (aOtherVector)
            );

            return new Angle(AngleVal, AngleType.Radians);
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
