using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonObject {
    class Program {
        static void Main(string[] args) {
            int i = 10;
            string str = "abc";
            var anon = new { i, str };
            Console.WriteLine(anon);
            Console.ReadLine();
        }
    }
}
