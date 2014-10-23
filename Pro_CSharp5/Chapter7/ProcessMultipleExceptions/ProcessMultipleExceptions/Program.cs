using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions {
    class Program {
        static void Main(string[] args) {
            Car myCar = new Car("Zippy", 20);

            try {
                myCar.Accelerate(-10);

            } catch (CarIsDeadException e) {
                Console.WriteLine("Message: {0}", e.Message);
           // } catch (ArgumentException e) {
            //    Console.WriteLine("Message: {0}", e.Message);
            } finally {
                myCar.CrankTunes(false);
            }


            Console.ReadLine();
        }
    }
}
