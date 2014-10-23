using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate {
    class Program {
        static void Main(string[] args) {
            BinaryOp b = new BinaryOp(SimpleMath.Add);
            Console.WriteLine("10 + 10 is {0}", b(10,10));
            Console.WriteLine("10 + 10 is {0}", b.Invoke(10, 10));  //Also ok
            Console.WriteLine();
            DisplayDelegateInfo(b);

            SimpleMath m = new SimpleMath();
            BinaryOp bInst = new BinaryOp(m.Subtract);
            DisplayDelegateInfo(bInst);

            Console.ReadLine();
        }

        static void DisplayDelegateInfo(Delegate delObj) {
            foreach (Delegate d in delObj.GetInvocationList()) {
                Console.WriteLine("Method name: {0}", d.Method);
                Console.WriteLine("Type name: {0}", d.Target);
            }
        }
    }

    public delegate int BinaryOp(int x, int y);

    public class SimpleMath {
        public static int Add(int x, int y) {
            return x + y;
        }

        public int Subtract(int x, int y) {
            return x - y;
        }
    }
}
