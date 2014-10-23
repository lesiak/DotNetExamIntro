using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatStrings {
    struct Point {
        public int X;
        public int Y;
    }

    class Program {
        static void Main(string[] args) {
            Point p = new Point() { X = 10, Y = 20 };
            Console.WriteLine(p);
            int i = 10;
            Console.WriteLine("int");
            Console.WriteLine("{0,8}", i);
            Console.WriteLine("{0,8:C}", i);
            Console.WriteLine();


            double d = 10.23;
            Console.WriteLine("double");            
            Console.WriteLine("{0,8}", d);
            Console.WriteLine("{0,8:C}", d);

            Console.WriteLine();

            DateTime now = DateTime.Now;
            Console.WriteLine("DateTime");
            Console.WriteLine("{0:d}", now);
            Console.WriteLine("{0:D}", now);
            Console.WriteLine("{0:M}", now);
            Console.WriteLine("{0:Y}", now);

            DateTime dt = new DateTime(2008, 4, 10);
            Console.WriteLine(dt.ToString("d",CultureInfo.CreateSpecificCulture("pl-PL")));

            Console.WriteLine();
            testFormatNum();
            
            Console.ReadLine();
        }

        static void testFormatNum() {
            Console.WriteLine("testFormatNum");
            decimal d = 1234.56M;
            int i = 9;
            d = i;
            //i = d;  narrowing
            Console.WriteLine(d.ToString("c"));
            Console.WriteLine(d.ToString("C"));
            Console.WriteLine("{0:C}", d);
            Console.WriteLine("{1}, {2}", d, d, d);
            Console.WriteLine("{Veni}");
        }
    }
}
