using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections {
    class Program {
        static void Main(string[] args) {
            UseGenericList();
            UseGenericStack();
            UseGenericQueue();
            UseSortedSet();
            Console.ReadLine();
        }

        static void UseGenericList() {
            List<Person> people = new List<Person>() {
                new Person("Homer"),
                new Person("Marge"),
                new Person("Lisa"),
                new Person("Bart")
            };
            Console.WriteLine("Items in list: {0}", people.Count);

            foreach (Person p in people) {
                Console.WriteLine(p);
            }

            Console.WriteLine("=> Insert a new person");

            people.Insert(2, new Person("Maggie"));
            Console.WriteLine("Items in list: {0}", people.Count);

            Person[] arrayOfPeople = people.ToArray();
            for (int i = 0; i < arrayOfPeople.Length; i++) {
                Console.WriteLine("Name: {0}", arrayOfPeople[i].FirstName);
            }
            Console.WriteLine();
        }

        public static void UseGenericStack() {
            Stack<Person> people = new Stack<Person>();
            people.Push(new Person("Homer"));
            people.Push(new Person("Marge"));
            people.Push(new Person("Lisa"));
            people.Push(new Person("Bart"));

            Console.WriteLine("First person is: {0}", people.Peek());
            Console.WriteLine("Popped person is: {0}", people.Pop());
            Console.WriteLine("First person is: {0}", people.Peek());
            Console.WriteLine("Popped person is: {0}", people.Pop());
            Console.WriteLine("First person is: {0}", people.Peek());
            Console.WriteLine("Popped person is: {0}", people.Pop());
            Console.WriteLine("First person is: {0}", people.Peek());
            Console.WriteLine("Popped person is: {0}", people.Pop());
            try {
                Console.WriteLine("First person is: {0}", people.Peek());
                Console.WriteLine("Popped person is: {0}", people.Pop());
            } catch (InvalidOperationException ex) {
                Console.WriteLine(ex);
            }
            Console.WriteLine();
        }

        static void UseGenericQueue() {
            Queue<Person> people = new Queue<Person>();
            people.Enqueue(new Person("Homer"));
            people.Enqueue(new Person("Marge"));
            people.Enqueue(new Person("Lisa"));
            people.Enqueue(new Person("Bart"));

            Console.WriteLine("First person is: {0}", people.Peek());
            Console.WriteLine("Dequeued person is: {0}", people.Dequeue());
            Console.WriteLine("Dequeued person is: {0}", people.Dequeue());
            Console.WriteLine("Dequeued person is: {0}", people.Dequeue());
            Console.WriteLine("Dequeued person is: {0}", people.Dequeue());
            try {
                Console.WriteLine("First person is: {0}", people.Peek());
            } catch (InvalidOperationException ex) {
                Console.WriteLine(ex);
            }
            Console.WriteLine();
        }

        static void UseSortedSet() {
            Console.WriteLine("=>SortedSet");
            //  SortedSet<Person> setOfPeople = new SortedSet<Person>(); Runime error At least one object must implement IComparable.
            SortedSet<Person> setOfPeople = new SortedSet<Person>(new SortPeopleByName())
             {
                new Person("Homer"),
                new Person("Marge"),
                new Person("Lisa"),
                new Person("Bart")
            };
            

            foreach (Person p in setOfPeople) {
                Console.WriteLine(p);
            }
            Console.WriteLine();
                

            setOfPeople.Add(new Person("AAron"));
            setOfPeople.Add(new Person("Yumi"));
           

            foreach (Person p in setOfPeople) {
                Console.WriteLine(p);
            }

        }
    }

    class SortPeopleByName : IComparer<Person> {

        public int Compare(Person x, Person y) {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }
}
