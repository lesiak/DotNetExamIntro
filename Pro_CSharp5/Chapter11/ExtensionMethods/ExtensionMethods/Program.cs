using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExtensionMethods;

namespace ExtensionMethods {
    class Program {
        static void Main(string[] args) {
            int myInt = 12345678;
            myInt.DisplayDefiningAssembly();

            System.Data.DataSet d = new System.Data.DataSet();
            d.DisplayDefiningAssembly();
            

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();
            sp.DisplayDefiningAssembly();

            Console.WriteLine(myInt);
            Console.WriteLine(myInt.ReverseDigits());

            Console.ReadLine();
        }
    }
}
