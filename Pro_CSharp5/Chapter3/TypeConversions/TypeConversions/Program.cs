using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeConversions {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=> Type Conversions");
            short numb1 = 9, numb2 = 10;
            Console.WriteLine("{0} + {1} = {2}", numb1, numb2, Add(numb1, numb2));


            
           // short a1 = (short)(1 + numb4);
            short numb3 = 30000, numb4 = 30000;
            short ans = (short)Add(numb3, numb4);
            Console.WriteLine("{0} + {1} = {2}", numb3, numb4, ans);

            ProcessBytes();

            Console.ReadLine();
        }

        static void ProcessBytes() {
            byte b1 = 100;
            byte b2 = 250;

            try {
                byte sum = checked((byte)Add(b1, b2));
                Console.WriteLine("sum = {0}", sum);
            } catch (OverflowException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static int Add(int x, int y) {
            return x + y;
        }
    }
}

