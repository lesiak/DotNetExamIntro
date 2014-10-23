using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqJoin {
    class Program {
        static void Main(string[] args) {
            var dictionary1 = new Dictionary<string, string>() { { "1", "B" }, { "2", "A" }, { "3", "B" }, { "4", "A" }, };
            var dictionary2 = new Dictionary<string, string>() { { "5", "B" }, { "6", "A" }, { "7", "B" }, { "8", "A" }, };

            /*IEnumerable<int> a = new List<int>() { 1, 2 };
            foreach (var i in a) {

            } */
            
            var joinResult = from d1 in dictionary1
                       join d2 in dictionary2 on d1.Value equals d2.Value into groupResult
                       select new
                       {
                           Key1 = d1.Key,
                           Gr = groupResult,
                          // Key2 = d2.Key, d2 does not exist
                           Value = d1.Value
                       };

            foreach (var v in joinResult) {
                Console.WriteLine("{0} [{1}] {2}", v.Key1, string.Join(", ",v.Gr.ToArray()), v.Value);
            }

            
            Console.ReadLine();
        }
    }
}
