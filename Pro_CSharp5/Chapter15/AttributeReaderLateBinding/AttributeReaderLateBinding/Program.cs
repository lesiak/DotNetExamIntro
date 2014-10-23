using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace AttributeReaderLateBinding {
    class Program {
        static void Main(string[] args) {
            ReflectAttributesUsingLateBinding();
            Console.ReadLine();
        }

        static void ReflectAttributesUsingLateBinding() {
            try {
                Assembly asm = Assembly.Load("AtributedCarLibrary");

                Type vehicleDesc = asm.GetType("AtributedCarLibrary.VehicleDescriptionAttribute");

                PropertyInfo propDesc = vehicleDesc.GetProperty("Description");
                Type[] types = asm.GetTypes();
                foreach (Type t in types) {
                    object[] attrs = t.GetCustomAttributes(vehicleDesc, false);
                    foreach (object o in attrs) {
                        Console.WriteLine("-> {0}: {1}\n", t.Name, propDesc.GetValue(o));
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}
