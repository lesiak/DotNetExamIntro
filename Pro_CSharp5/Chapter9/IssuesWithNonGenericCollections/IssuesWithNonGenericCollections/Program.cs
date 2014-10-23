using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesWithNonGenericCollections {
    class Program {
        static void Main(string[] args) {
            SimpleBoxUnboxOperation();
            WorkWithArrayList();
            UsePersonCollection();
            UseGenericCollection();
            GenericMembers();
            Console.ReadLine();
        }

        static void SimpleBoxUnboxOperation() {
            int myInt = 25;
            object boxedInt = myInt;
            Console.WriteLine(myInt.GetType());  //this causes boxing!
            Console.WriteLine(boxedInt.GetType());
           //System.Array a = new int[3];
           //a.SetValue() takes object
            
            long unboxedInt = (int)boxedInt;
            try {
                
                long unboxedLong = (long)boxedInt;
                Console.WriteLine();
            } catch (InvalidCastException ex) {
                Console.WriteLine(ex);
            }
            Console.WriteLine();
        }


        static void WorkWithArrayList() {
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);

            Console.WriteLine(myInts);
            int i = (int)myInts[0];
            Console.WriteLine("Value of first item is {0}", i);
        }

        static void ArrayListOfRandomObjects() {
            ArrayList allMyObjects = new ArrayList();
            allMyObjects.Add(true);
            allMyObjects.Add(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0)));
            allMyObjects.Add(66);
            allMyObjects.Add(3.14);
        }

        static void UsePersonCollection() {
            PersonCollection myPeople = new PersonCollection();
            myPeople.AddPerson(new Person("Homer"));
            myPeople.AddPerson(new Person("Mary"));
            myPeople.AddPerson(new Person("Lisa"));
            myPeople.AddPerson(new Person("Bart"));
            myPeople.AddPerson(new Person("Maggie"));

            //myPeople.AddPerson(new OperatingSystem(PlatformID.MacOSX, new Version(10, 0))); ERROR

            foreach (Person p in myPeople) {  //Works without casting here
                Console.WriteLine(p);
            }
            try {
                foreach (int p in myPeople) {  //Runtime error
                    // Console.WriteLine(p);
                }
            } catch (InvalidCastException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }

        static void UseGenericCollection() {
            List<Person> morePeople = new List<Person>();
            morePeople.Add(new Person("Frank"));
            Console.WriteLine(morePeople[0]);
            ((IList)morePeople).Add(new Person("Joe"));
            try {
                ((IList)morePeople).Add("Baba");  //Runtime error
            } catch (ArgumentException ex) {
                Console.WriteLine(ex);
                Console.WriteLine();
            }
            List<int> moreInts = new List<int>();
            moreInts.Add(20);
            moreInts.Add(2);
            int sum = moreInts[0] + moreInts[1];

            //moreInts.Add(new Person("John")); ERROR
            Console.WriteLine();
            
        }

        static void GenericMembers() {
            int[] myInts = { 10, 4, 2, 33, 93 };
            Array.Sort<int>(myInts);

            foreach (int i in myInts) {
                Console.WriteLine(i);
            }
        }

        public class Person {
            public string Name { get; set; }

            public Person(string name) {
                Name = name;
            }

            public override string ToString() {
                return string.Format("[Name: {0}]", Name);
            }
        }

        public class PersonCollection : IEnumerable {
            private ArrayList arPeople = new ArrayList();

            public Person GetPerson(int pos) {
                return (Person)arPeople[pos];
            }

            public void AddPerson(Person p) {
                arPeople.Add(p);
            }

            public void ClearPeople() {
                arPeople.Clear();
            }

            public int Count {
                get {
                    return arPeople.Count;
                }
            }

            IEnumerator IEnumerable.GetEnumerator() {
                return arPeople.GetEnumerator();
            }
        }
    }
}
