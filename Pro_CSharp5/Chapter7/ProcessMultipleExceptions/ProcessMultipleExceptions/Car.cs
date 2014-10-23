using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMultipleExceptions {
    class Car {
        public const int MaxSpeed = 100;

        public int CurrentSpeed { get; set; }

        public string PetName { get; set; }

        private bool isCarDead;

        private Radio theMusicBox = new Radio();

        public Car() {

        }

        public Car(string name, int speed) {
            PetName = name;
            CurrentSpeed = speed;
        }

        public void CrankTunes(bool state) { theMusicBox.TurnOn(state); }

        public void Accelerate(int delta) {
            if (delta < 0) {
                throw new ArgumentOutOfRangeException("delta", "Speed must be grater than zero");
            }
            if (isCarDead) {
                Console.WriteLine("{0} is out of order", PetName);
            } else {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed) {
                    CurrentSpeed = 0;
                    isCarDead = true;
                    //Console.WriteLine("{0} has overheated", PetName);
                    //throw new Exception(string.Format("{0} has overheated", PetName));
                    CarIsDeadException ex = new CarIsDeadException(
                        string.Format("{0} has overheated", PetName),
                        "You have a lead foot", DateTime.Now);
                    ex.HelpLink = "http://www.Cars.com";


                    throw ex;

                } else {
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }


    }
}
