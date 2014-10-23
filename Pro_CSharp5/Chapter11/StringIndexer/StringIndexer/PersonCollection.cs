using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringIndexer {
    class PersonCollection : IEnumerable {
        private Dictionary<string,Person> people = new Dictionary<string,Person>();

        public Person this[string name] {
            get { return people[name]; }
            set { people[name]=value; }
        }

        public int Count {
            get { return people.Count; }
        }



        IEnumerator IEnumerable.GetEnumerator() {
            return people.GetEnumerator();
        }
    }


}
