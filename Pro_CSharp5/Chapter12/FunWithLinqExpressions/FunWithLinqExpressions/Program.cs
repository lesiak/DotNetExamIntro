using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLinqExpressions {
    class Program {
        static void Main(string[] args) {
            ProductInfo[] itemsInStock = new []{  ///Works fine!!!
                new ProductInfo {Name = "Mac's Coffee", Description = "Coffee", NumberInStock = 24},
                new ProductInfo {Name = "Milk Made Milk", Description = "Milk", NumberInStock = 100},
                new ProductInfo {Name = "Pure Tofu", Description = "Tofu", NumberInStock = 120},
                new ProductInfo {Name = "Crunchy Pops", Description = "Chips", NumberInStock = 2},
                new ProductInfo {Name = "RipOff Water", Description = "Water", NumberInStock = 100},
                new ProductInfo {Name = "Classic Valpo Pizza", Description = "Pizza", NumberInStock = 73}
            };
            SelectEverything(itemsInStock);
            SelectProductNames(itemsInStock);
            GetOverstock(itemsInStock);
            GetNamesAndDescriptions(itemsInStock);
            GetCountFromQuery();
            ReverseEverything(itemsInStock);
            AlphabetizeProductNames(itemsInStock);
            DisplayDiff();
            DisplayIntersect();
            DisplayUnion();
            DisplayConcat();
            DisplayConcatDistinct();
            AggregateOps();
            Console.ReadLine();
        }

        static void SelectEverything(ProductInfo[] products) {
            Console.WriteLine("=> All producrt details:");
            var allProducts = from p in products select p;
            foreach (var p in allProducts) {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }

        static void SelectProductNames(ProductInfo[] products) {
            Console.WriteLine("=> All Names:");
            var allNames = from p in products select p.Name;
            foreach (var p in allNames) {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }

        static void GetOverstock(ProductInfo[] products) {
            Console.WriteLine("=> GetOverstock");
            var overstock = from p in products 
                            where p.NumberInStock > 25
                            where p.NumberInStock > 25      //works fine
                            select p;
            foreach (var p in overstock) {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }

        static void GetNamesAndDescriptions(ProductInfo[] products) {
            Console.WriteLine("=> GetNamesAndDescriptions:");
            var nameDesc = from p in products select new { p.Name, p.Description };
            foreach (var p in nameDesc) {
                Console.WriteLine(p);
            }
            Console.WriteLine();
        }

        static void GetCountFromQuery() {
            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2" };
            int numb = (from g in currentVideoGames
                        where g.Length > 6
                        select g).Count();
            Console.WriteLine("{0} items honor the Linq Query", numb);
            Console.WriteLine();
        }

        static void ReverseEverything(ProductInfo[] products) {
            Console.WriteLine("=> Products in reverse");
            var allProducts = products.Reverse();
            foreach (var prod in allProducts) {
                Console.WriteLine(prod);
            }
            Console.WriteLine();
        }

        static void AlphabetizeProductNames(ProductInfo[] products) {
            Console.WriteLine("=> Ordered by Name");
            var subset = from p in products
                         orderby p.Name
                         select p;
            foreach (var p in subset) {
                Console.WriteLine(p);
            }
            Console.WriteLine();

        }

        static void DisplayDiff() {
            Console.WriteLine("=> Cars I have but you don't");
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            //var carDiff = (from c in myCars select c).Except(from c2 in yourCars select c2);
            var carDiff = myCars.Except(yourCars);
            foreach (string c in carDiff) {
                Console.WriteLine(c);
            }
            Console.WriteLine();

        }

        static void DisplayIntersect() {
            Console.WriteLine("=> Cars we have in common");
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carIntersect = myCars.Intersect(yourCars);
            foreach (string c in carIntersect) {
                Console.WriteLine(c);
            }
            Console.WriteLine();
        }

        static void DisplayUnion() {
            Console.WriteLine("=> Here is union");
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carUnion = myCars.Union(yourCars);
            foreach (string c in carUnion) {
                Console.WriteLine(c);
            }
            Console.WriteLine();
        }

        static void DisplayConcat() {
            Console.WriteLine("=> Here is concat");
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carConcat = myCars.Concat(yourCars);
            foreach (string c in carConcat) {
                Console.WriteLine(c);
            }
            Console.WriteLine();
        }

        static void DisplayConcatDistinct() {
            Console.WriteLine("=> Here is concat distinct");
            List<string> myCars = new List<string>() { "Yugo", "Aztec", "BMW" };
            List<string> yourCars = new List<string>() { "BMW", "Saab", "Aztec" };

            var carConcatDistinct = myCars.Concat(yourCars).Distinct();
            foreach (string c in carConcatDistinct) {
                Console.WriteLine(c);
            }
            Console.WriteLine();
        }

        static void AggregateOps() {
            double[] winterTemps = { 2.0, -21.3, 8, -4, 0, 8.2 };
            Console.WriteLine("Max: {0}", winterTemps.Max());
            Console.WriteLine("Min: {0}", winterTemps.Min());
            Console.WriteLine("Average: {0}", winterTemps.Average());
            Console.WriteLine("Sum: {0}", winterTemps.Sum());
        }

    }
}
