using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithObservableCollection {
    class Program {
        static void Main(string[] args) {
            ObservableCollection<Person> people = new ObservableCollection<Person>() {
                new Person("Peter"),
                new Person("Kevin"),
            };

            people.CollectionChanged += people_CollectionChanged;

            people.Add(new Person("Fred"));
            people.RemoveAt(0);

            Console.ReadLine();
        }

        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            Console.WriteLine("Action for this event: {0}", e.Action);

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) {
                Console.WriteLine("Here are the OLD items");
                foreach (Person p in e.OldItems) {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
                Console.WriteLine("Here are the NEW items");
                foreach (Person p in e.NewItems) {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

        }
    }
}
