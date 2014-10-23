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

        Console.WriteLine(Days.Mon == 0);
    
            Console.ReadLine();
        }
        
    }
}
