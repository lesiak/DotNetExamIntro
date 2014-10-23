using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOverrides
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person();

            Console.WriteLine("ToString: {0}", p1.ToString());
            Console.WriteLine("Hash Code: {0}", p1.GetHashCode());
            Console.WriteLine("Type: {0}", p1.GetType());

            Person p2 = p1;
            object o = p2;

            if (o.Equals(p1) && p2.Equals(o))
            {
                Console.WriteLine("Same instance");
            }

            Person pNull = null;
            Console.WriteLine();
            Console.WriteLine("is pNull a person {0}", pNull is Person);
            Console.WriteLine("is p1 equal to null {0}", p1.Equals(null));
            Console.WriteLine("is empty string equal to null {0}", "" == null);
            Console.WriteLine();


            Person p11 = new Person("Homer", "Simpson", 50);
            Person p12 = new Person("Homer", "Simpson", 50);


            Console.WriteLine("ToString: {0}", p11.ToString());
            Console.WriteLine("p11.Hash Code: {0}", p11.GetHashCode());
            Console.WriteLine("p12.Hash Code: {0}", p12.GetHashCode());
            Console.WriteLine("is p11 equal to p12 {0}", p11.Equals(p12));

            p12.Age = 45;
            Console.WriteLine("is p11 equal to p12 {0}", p11.Equals(p12));
            Console.WriteLine("p11.Hash Code: {0}", p11.GetHashCode());
            Console.WriteLine("p12.Hash Code: {0}", p12.GetHashCode());

            Console.WriteLine();

            Console.WriteLine("=> static object methods");
            Person p3 = new Person("Sally", "Jones", 4);
            Person p4 = new Person("Sally", "Jones", 4);
            Console.WriteLine("object.Equals {0}", object.Equals(p3, p4));
            Console.WriteLine("object.ReferenceEquals {0}", object.ReferenceEquals(p3, p4));
            Console.ReadLine();
        }
    }

    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string fName, string lName, int personAge)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
        }

        public Person()
        {

        }

        public override string ToString()
        {
            return string.Format("[First Name: {0}; Last Name: {1}; Age: {2}]",
                FirstName, LastName, Age);
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person temp = (Person)obj;
                if (temp.FirstName == this.FirstName
                    && temp.LastName == this.LastName
                    && temp.Age == this.Age)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
