using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates {
    class Program {

        public delegate int Calculate(int x, int y);

        static int Add(int x, int y) {
            int result = x + y;
            Console.WriteLine(result);
            return result;
        }

        static void Main(string[] args) {
            Calculate calc = delegate (int x, int y)
            {
                return x + y;
            };
           // Func
            Console.WriteLine(calc(3, 4));
            Console.ReadLine();
        }
    }
}
