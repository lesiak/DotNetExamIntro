using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AtributedCarLibrary;

namespace VehicleDescriptionAttributeReader {
    class Program {
        static void Main(string[] args) {
            ReflectOnAttributesUsingEarlyBinding();
            Console.ReadLine();
        }

        static void ReflectOnAttributesUsingEarlyBinding() {
            Type t = typeof(WinneBaggo);

            object[] customAttributes = t.GetCustomAttributes(false);

            foreach (VehicleDescriptionAttribute v in customAttributes) { //this is casting, only works if all atributes have this type
                Console.WriteLine(" -> {0}\n", v.Description);
            }
        }
    }
}
