using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CarLibrary;

namespace CSharpCarClient {
    class Program {
        static void Main(string[] args) {
            SportsCar viper = new SportsCar("Viper", 240, 40);
            viper.TurboBoost();

            MiniVan mv = new MiniVan();
            mv.TurboBoost();

            Console.ReadLine();
        }
    }
}
