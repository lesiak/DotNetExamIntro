using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithGenericCollections {
    public class Person {
        public string FirstName { get; set; }

        public Person(string firstName) {
            FirstName = firstName;
        }

        public override string ToString() {
            return string.Format("[Name: {0}]", FirstName);
        }
    }
}
