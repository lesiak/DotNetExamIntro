using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtensions {
    class Program {
        static void Main(string[] args) {
            string[] data = { "This", "is", "annoying" };
            data.PrintDataAndBeep();

            Console.WriteLine();

            List<int> myInts = new List<int>() { 10, 15, 20 };
            myInts.PrintDataAndBeep();

            Console.ReadLine();
        }
    }
}
