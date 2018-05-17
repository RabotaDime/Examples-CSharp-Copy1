using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Misc.Exercises
{
    //   Пример условия, которое всегда равно true и дает код, 
    //   который нельзя достичь (unreachable). 
    class CompileTime1
    {
        public bool Example ()
        {
            if (null == (object)null != false)
            {
                //  null == (object)null  -- дает true
                //  true != false         -- дает true
                return true;
            }

            return false;
        }



        public static void Execute ()
        {
        }
    }
}
