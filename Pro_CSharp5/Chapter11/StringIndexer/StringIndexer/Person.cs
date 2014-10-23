using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringIndexer {
    class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string fName, string lName, int age) {
            FirstName = fName;
            LastName = lName;
            Age = age;
        }

        public override string ToString() {
            return string.Format("[{0} {1}]", FirstName, LastName);
        }
    }
}
