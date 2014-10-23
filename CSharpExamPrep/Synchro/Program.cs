using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Synchro {
    class Program {
        static void Main(string[] args) {
            int i = 0;
            Interlocked.Add(ref i, 3);
            Console.WriteLine(i);
            Console.ReadLine();
            //lock
        }
    }
}
