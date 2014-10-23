using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues {
    class Program {
        static void Main(string[] args) {
            LINQBasedFieldsAreClunky ex = new LINQBasedFieldsAreClunky();
            ex.PrintGames();
            Console.WriteLine();

            IEnumerable<String> redColours = GetStringSubset();
            foreach (var c in redColours) {
                Console.WriteLine(c);
            }
            Console.WriteLine();

            foreach (var c in GetStringSubsetAsArray()) {
                Console.WriteLine(c);
            }

            Console.ReadLine();
        }

        static IEnumerable<string> GetStringSubset() {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            IEnumerable<string> redColours = from c in colors
                                             where c.Contains("Red")
                                             select c;
            return redColours;
        }

        static string[] GetStringSubsetAsArray() {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var redColours = from c in colors
                                             where c.Contains("Red")
                                             select c;
            return redColours.ToArray();
        }
    }

    class LINQBasedFieldsAreClunky {
        private static string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

        private IEnumerable<string> subset = from g in currentVideoGames
                                             where g.Contains(" ")
                                             orderby g
                                             select g;

        public void PrintGames() {
            foreach (var item in subset) {
                Console.WriteLine(item);
            }
        }
    }
}
