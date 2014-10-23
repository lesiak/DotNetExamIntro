using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithMethods {
    class Program {
        static void Main(string[] args) {
            int x = 9, y = 10;
            Console.WriteLine("Before call x: {0}, y: {1}", x, y);
            Console.WriteLine("Answer is: {0}", Add(x, y));
            Console.WriteLine("After call x: {0}, y: {1}", x, y);

            int ans; // may be unassigned
            AddOut(90, 90, out ans);
            Console.WriteLine("90 + 90 = {0}", ans);

            string s1 = "Flip";
            string s2 = "Flop";
            Console.WriteLine("Before call s1: {0}, s2: {1}", s1, s2);
            SwapStrings(ref s1, ref s2);
            Console.WriteLine("After call s1: {0}, s2: {1}", s1, s2);



            double avg = CalculateAverage(1.0, 3.2, 5.4);
            Console.WriteLine("Calculated average {0}", avg);
            double[] data = { 1.0, 3.2, 5.4 };
            double avg1 = CalculateAverage(data);
            Console.WriteLine("Calculated average {0}", avg1);

            Console.WriteLine("Calculated average of empty {0}", CalculateAverage());
            Console.WriteLine("=> Optional arguments");
            EnterLogData("msg1", "CEO");
            EnterLogData("msg2");


            Console.WriteLine("=> Named arguments");
            DisplayFancyMessage(message: "aaa", backgroundColor: ConsoleColor.Gray, textColor: ConsoleColor.DarkGreen);

            DisplayFancyMessage(ConsoleColor.DarkGreen, backgroundColor: ConsoleColor.Gray, message: "aaa");

            //DisplayFancyMessage(backgroundColor: ConsoleColor.Gray, ConsoleColor.DarkGreen, message: "aaa"); Does not compile

            //DisplayFancyMessage("aaa"); does not compile
            DisplayFancyMessage(message: "aaa");
            Console.ReadLine();
        }

        static int Add(int x, int y) {
            int ans = x + y;

            //Caller will not get these updates
            x = 100;
            y = 200;
            return ans;
        }


        static void AddOut(int x, int y, out int ans) {
            //Console.WriteLine(ans); use of unassigned parameter
            ans = x + y;
        }

        static void SwapStrings(ref string s1, ref string s2) {
            string temp = s1;
            s1 = s2;
            s2 = temp;
        }

        static double CalculateAverage(params double[] values) {
            Console.WriteLine("You sent me {0} doubles", values.Length);

            double sum = 0;
            if (values.Length == 0) {
                return sum;
            }
            for (int i = 0; i < values.Length; ++i) {
                sum += values[i];
            }
            return sum / values.Length;
        }

        static void EnterLogData(string message, string owner = "programmer") {
            Console.WriteLine("Error: {0}", message);
            Console.WriteLine("Owner of Error: {0}", owner);
        }

        //  static string returnConstnt() {
        //      return "aaa";
        //  }

        static void DisplayFancyMessage(ConsoleColor textColor = ConsoleColor.Blue,
            ConsoleColor backgroundColor = ConsoleColor.White,
            string message = "mus be here as ooptional are always after positional") {
            ConsoleColor oldTextColor = Console.ForegroundColor;
            ConsoleColor oldBgColor = Console.BackgroundColor;

            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(message);

            Console.ForegroundColor = oldTextColor;
            Console.BackgroundColor = oldBgColor;


        }
    }
}
