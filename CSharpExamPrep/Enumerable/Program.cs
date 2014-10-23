using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerable {
    class Program {
        static void Main(string[] args) {
            foreach (var i in GetValuesEnumerable()) {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        static IEnumerable<int> GetValuesEnumerable() {
            yield return 1;
            yield return 2;
            yield break;
            yield return 4;
        }
    }
}
