using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullables {

    enum MyEnum {
        A,
        B
    }

    class Program {
        static void Main(string[] args) {            

            Nullable<int> nA = 1;
            Nullable<int> nB = 1;

            Console.WriteLine("nA.Equals(nB): {0}", nA.Equals(nB));
            Console.WriteLine("nA.Equals(1): {0}",  nA.Equals(1));
            Console.WriteLine("nA & nB: {0}",  nA & nB);
            Console.WriteLine();
            Console.WriteLine();
            // Console.WriteLine(nA && nB);

            bool? bA = true;
            bool? bB = null;

            bool b1 = true;
            bool b2 = false;

            Console.WriteLine("Bools:");

            Console.WriteLine("bA & bB == null: {0}", (bA & bB) == null);
            //Console.WriteLine(bA && bB);         //error

            Console.WriteLine("b1 & b2: {0}", b1 & b2);
            Console.WriteLine("b1 && b2: {0}", b1 && b2);

            //Console.WriteLine(bA && bB);       
            //stat.aaa(); ERROR, TYPOE Name needed

            Console.ReadLine();

        }
    }
}
