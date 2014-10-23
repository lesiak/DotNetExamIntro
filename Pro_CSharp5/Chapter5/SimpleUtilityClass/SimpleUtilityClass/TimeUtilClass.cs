using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleUtilityClass
{
    static class TimeUtilClass
    {
        //public int i = 0; ERROR: Cannot declare instnce members in a static class

        public static void PrintTime()
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        public static void PrintDate()
        {
            Console.WriteLine(DateTime.Now.ToShortDateString());
        }
    }
}
