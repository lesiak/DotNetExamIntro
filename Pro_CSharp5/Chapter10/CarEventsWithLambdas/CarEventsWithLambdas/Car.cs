using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEventsWithLambdas {
    public class Car {

        //public delegate void CarEngineHandler(string msgForCaller);
        public delegate void CarEngineHandler(object sender, CarEventArgs e);

        //public event CarEngineHandler Exploded;
        //public event CarEngineHandler AboutToBlow;

        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;

        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        private bool carIsDead;        

        public Car() {
            MaxSpeed = 100;
        }

        public Car(string name, int maxSp, int currSp) {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        public void Accelerate(int delta) {
            if (carIsDead) {
                if (Exploded != null) {  //This is necesary!!
                    Exploded(this, new CarEventArgs("Sorry, this car is dead"));
               }
            } else {
                CurrentSpeed += delta;
                if (10 == (MaxSpeed - CurrentSpeed) && AboutToBlow != null) {
                    AboutToBlow(this, new CarEventArgs("Careful buddy! Gonna blow!"));
                }

                if (CurrentSpeed >= MaxSpeed) {
                    carIsDead = true;
                } else {
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }

        


       
    }

    public class CarEventArgs : EventArgs {
        public readonly string msg;
        public CarEventArgs(string message) {
            msg = message;
        }
    }
}
