using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefTypeValTypeParams
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Passing a class by value");
            Person fred = new Person("Fred", 12);
            Console.WriteLine("Before pass by val: ");
            fred.Display();

            SendAClassByValue(fred);

            Console.WriteLine("After pass by val");
            fred.Display();

            SendAClassByReference(ref fred);
            Console.WriteLine("After pass by ref");
            fred.Display();

            Console.ReadLine();

            //Person p = new Person();
        }

        static void SendAClassByValue(Person p)
        {
            p.personAge = 99;

            p = new Person("Nikki", 99);
        }

        static void SendAClassByReference(ref Person p)
        {
            p.personAge = 555;

            p = new Person("Nikki", 999);
        }
    }

    class Person
    {
        public string personName;
        public int personAge;

        public Person(string name, int age)
        {
            personName = name;
            personAge = age;
        }

        public Person() 
        {

        }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Age: {1}", personName, personAge);
        }



        //public 
    }
}
