using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer {
    class Program {
        static void Main(string[] args) {
            UseCustomIndexer();
            UseGenericListIndexer();

            ArrayList arList = new ArrayList();
            //arList[0] = "AAA"; ERROR
            arList.Insert(0, "AAA");
            //arList.Insert(10, "AAA"); ERROR
            Console.ReadLine();

        }

        static void UseCustomIndexer() {
            PersonCollection myPeople = new PersonCollection();
            myPeople[0] = new Person("Homer", "Simpson", 40);
            myPeople[1] = new Person("Marge", "Simpson", 38);

            for (int i = 0; i < myPeople.Count; i++) {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }

        static void UseGenericListIndexer() {
            List<Person> myPeople = new List<Person>();
            // myPeople[0] = new Person("Homer", "Simpson", 40); ArgumentOutOfRangeException
            // myPeople[1] = new Person("Marge", "Simpson", 38);ArgumentOutOfRangeException
            myPeople.Add(new Person("Homer", "Simpson", 40));
            myPeople.Add(new Person("Marge", "Simpson", 38));


            for (int i = 0; i < myPeople.Count; i++) {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }
    }
}
