using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverArray {
    class Program {        

        static void Main(string[] args) {
            QueryOverStrings();
            Console.WriteLine();
            
            QueryOverLongWay();
            Console.WriteLine();

            QueryOverInts();

            ImmediateExecution();
            Console.ReadLine();
        }

        static void QueryOverStrings() {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            IEnumerable<string> subset = from game in currentVideoGames
                                         where game.Contains(" ")
                                         orderby game
                                         select game;
            foreach (string s in subset) {
                Console.WriteLine(s);
            }
            ReflectOverQueryResults(subset);
        }

        static void QueryOverLongWay() {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            List<string> subset = new List<string>();
            foreach (string game in currentVideoGames) {
                if (game.Contains(" ")) {
                    subset.Add(game);
                }
            }
            subset.Sort();

            foreach (string s in subset) {
                Console.WriteLine(s);
            }
        }

        static void QueryOverInts() {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            IEnumerable<int> subset = from i in numbers
                                      where i < 10
                                      select i;

            foreach (int i in subset) {
                //subset is evaluated here
                Console.WriteLine(i);
            }
            
            Console.WriteLine();

            numbers[0] = 4;
            foreach (int i in subset) {
                //subset is evaluated here
                Console.WriteLine(i);
            }

            Console.WriteLine();
            ReflectOverQueryResults(subset);
        }

        static void ImmediateExecution() {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            int[] subsetAsIntArray = (from i in numbers
                                      where i < 10
                                      select i).ToArray();

            List<int> subsetAsIntList = (from i in numbers
                                      where i < 10
                                      select i).ToList();
        }

        static void ReflectOverQueryResults(object resultSet) {
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
        }
    }
}
