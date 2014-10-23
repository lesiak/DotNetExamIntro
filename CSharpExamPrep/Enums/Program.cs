using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums {

    enum Days {
        Mon, Tue
    }

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(Days.Mon.ToString("d"));
            Console.WriteLine(Days.Tue.ToString("d"));

            Console.WriteLine("Days.Mon == 0: {0}",Days.Mon == 0);

            Days result;
            //Console.WriteLine("Result before: {0}", result); result is not initialized
            bool parsed = Enum.TryParse<Days>("BadValue", out result);
            Console.WriteLine("Parsed?: {0}", parsed);
            Console.WriteLine("Result: {0}", result);

            Console.ReadLine();
        }

    }
}
