using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Car
    {
        public const int MaxSpeed = 100;

        public int CurrentSpeed { get; set; }

        public string PetName { get; set; }

        private bool isCarDead;

        private Radio theMusicBox = new Radio();

        public Car()
        {

        }

        public Car(string name, int speed)
        {
            PetName = name;
            CurrentSpeed = speed;
        }

        public void CrankTunes(bool state)
        { theMusicBox.TurnOn(state); }

        public void Accelerate(int delta)
        {
            if (isCarDead)
            {
                Console.WriteLine("{0} is out of order", PetName);
            }
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed > MaxSpeed)
                {
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

                }
                else
                {
                    Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
                }
            }
        }


    }
}
