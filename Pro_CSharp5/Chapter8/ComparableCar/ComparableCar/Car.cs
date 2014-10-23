using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar {
    class Car : IComparable {
        public const int MaxSpeed = 100;

        public static IComparer SortByPetName {
            get {
                return new PetNameComparer();
            }
        }

        public int CarID { get; set; }

        public int CurrentSpeed { get; set; }

        public string PetName { get; set; }

        private bool isCarDead;

        private Radio theMusicBox = new Radio();

        public Car() {

        }

        public Car(string name, int speed, int id) {
            PetName = name;
            CurrentSpeed = speed;
            CarID = id;
        }

        public void CrankTunes(bool state) { theMusicBox.TurnOn(state); }

        public void Accelerate(int delta) {
            if (isCarDead) {
                Console.WriteLine("{0} is out of order", PetName);
            } else {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed) {
                    CurrentSpeed = 0;
                    isCarDead = true;
                    //Console.WriteLine("{0} has overheated", PetName);
                    //throw new Exception(string.Format("{0} has overheated", PetName));
                    Exception ex = new Exception(string.Format("{0} has overheated", PetName));
                    ex.HelpLink = "http://www.Cars.com";

                    ex.Data.Add("TimeStamp", string.Format("car explodaed at: {0}", DateTime.Now));
                    ex.Data.Add("Cause", "You have a lead foot");
                    ex.Data.Add("MyInt", 10);
                    throw ex;

                } else {
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }



        public int CompareTo(object obj) {
            Car temp = obj as Car;
            if (temp == null) {
                throw new ArgumentException("Parameter is not a car");
            }
            /*if (this.CarID > temp.CarID) {
                return 1;
            } else if (this.CarID < temp.CarID) {
                return -1;
            } else {
                return 0;
            }*/
            return this.CarID.CompareTo(temp.CarID);

        }
    }


    class PetNameComparer : IComparer {

        int IComparer.Compare(object o1, object o2) {
            Car c1 = o1 as Car;
            Car c2 = o2 as Car;
            if (c1 == null || c2 == null) {
                throw new ArgumentException("Parameter is not a car");
            }
            return String.Compare(c1.PetName, c2.PetName);
        }
    }
}
