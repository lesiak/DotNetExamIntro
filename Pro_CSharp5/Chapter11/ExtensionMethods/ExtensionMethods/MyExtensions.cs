using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyExtensionMethods {
    static class MyExtensions {

        public static void DisplayDefiningAssembly(this object obj) {
            Console.WriteLine("{0} lives here: => {1}\n",
                obj.GetType().Name,
                Assembly.GetAssembly(obj.GetType()).GetName().Name);
        }

        public static int ReverseDigits(this int i) {
            char[] digits = i.ToString().ToCharArray();

            Array.Reverse(digits);
         

            string newDigits = new string(digits);
            return int.Parse(newDigits);
        }
    }
}
