using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Misc.Exercises
{
    //   Пример условия, которое всегда равно true и дает код, 
    //   который нельзя достичь (unreachable). 
    class CCompileTime1
    {
        public bool Example ()
        {
            if (null == (object)null != false)
            {
                //  null == (object)null  -- дает true
                //  true != false         -- дает true
                return true;
            }

            #pragma warning disable CS0162 // Unreachable code detected
            return false;
            #pragma warning restore CS0162 // Unreachable code detected
        }



        public static void Execute ()
        {
        }
    }
}
