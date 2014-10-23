using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer {
    class PersonCollection : IEnumerable {
        private ArrayList arPeople = new ArrayList();

        public Person this[int index] {
            get { return (Person)arPeople[index]; }
            set { arPeople.Insert(index, value); }
        }

        public int Count {
            get { return arPeople.Count; }
        }



        IEnumerator IEnumerable.GetEnumerator() {
            return arPeople.GetEnumerator();
        }
    }


}
