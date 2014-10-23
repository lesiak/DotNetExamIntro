using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable {
    class Program {
        static void Main(string[] args) {
            QueryStringWithOperators();
            QueryStringWithEnumvrablesAndLambdas();
            QueryStringWithAnoymousMethods();
            VeryComplexQueryExpression.QueryStringsWithRawDelegates();
            Console.ReadLine();
            
        }

        static void QueryStringWithOperators() {
            Console.WriteLine("=> Query operators");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = from game in currentVideoGames
                         where game.Contains(" ")
                         orderby game
                         select game;

            foreach (string s in subset) {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }


        static void QueryStringWithEnumvrablesAndLambdas() {
            Console.WriteLine("=> Enumerables and lambdas");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };

            var subset = currentVideoGames.Where(game => game.Contains(" "))
                .OrderBy(game => game)
                .Select(game => game);

            foreach (string s in subset) {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }


        static void QueryStringWithAnoymousMethods() {
            Console.WriteLine("=> Anounymous methods");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            Func<string, bool> searchFilter = delegate(string game) { return game.Contains(" "); };
            Func<string, string> itemToProcess = delegate(string s) { return s; };
            var subset = currentVideoGames.Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);

            foreach (string s in subset) {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
    }

    class VeryComplexQueryExpression {
        public static void QueryStringsWithRawDelegates() {
            Console.WriteLine("=> Raw delegates");
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            Func<string, bool> searchFilter = new Func<string,bool>(Filter);
            Func<string, string> itemToProcess = new Func<string,string>(Identity);
            var subset = currentVideoGames.Where(searchFilter)
                .OrderBy(itemToProcess)
                .Select(itemToProcess);

            foreach (string s in subset) {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }

        public static bool Filter(string name) {
            return name.Contains(" ");
        }

        public static string Identity(string name) {
            return name;
        }
    }
}
