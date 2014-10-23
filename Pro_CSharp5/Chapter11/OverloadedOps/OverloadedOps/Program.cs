using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadedOps {
    class Program {
        static void Main(string[] args) {
            Point ptOne = new Point(100, 100);
            Point ptTwo = new Point(40, 30);

            Console.WriteLine(ptOne);
            Console.WriteLine(ptTwo);

            Console.WriteLine(ptOne + ptTwo);
            Console.WriteLine(ptOne - ptTwo);

            Console.WriteLine(ptOne + 10);
            Console.WriteLine(11 + ptOne);

            ptOne += ptTwo;
            Console.WriteLine(ptOne);

            Point ptFive = new Point(1, 1);
            Console.WriteLine("Preincrement {0}:", ++ptFive);
            Console.WriteLine("Postincrement {0}:", ptFive++);
            Console.WriteLine("Postincrement After: {0}:", ptFive);

            Console.WriteLine("ptOne == ptTwo: {0}", ptOne == ptTwo);
            Console.WriteLine("ptOne != ptTwo: {0}", ptOne != ptTwo);

            Console.WriteLine("ptOne < ptTwo: {0}", ptOne < ptTwo);
            Console.WriteLine("ptOne > ptTwo: {0}", ptOne > ptTwo);
            Console.ReadLine();
        }
    }
}
