﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnumerator {
    class Program {
        static void Main(string[] args) {

            Garage carLot = new Garage();

            foreach (Car c in carLot) {
                Console.WriteLine("{0} is going {1} MPH", c.PetName, c.CurrentSpeed);
            }

            IEnumerator i = carLot.GetEnumerator();
            i.MoveNext();
            Car myCar = (Car)i.Current;
            Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);
            Console.ReadLine();
        }
    }
}
