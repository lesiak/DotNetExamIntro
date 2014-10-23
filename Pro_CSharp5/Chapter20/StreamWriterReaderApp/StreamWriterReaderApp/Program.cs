using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamWriterReaderApp {
    class Program {
        static void Main(string[] args) {
            using (StreamWriter sw = File.CreateText("reminders.txt")) {
                sw.WriteLine("Don't forget Mother's day");
                sw.WriteLine("Don't forget Fathers's day");
                sw.WriteLine("Don't forget these numbers: ");
                for (int i = 0; i < 10; i++) {
                    sw.Write(i + " ");
                }
                sw.Write(sw.NewLine);
            }
            Console.WriteLine("Created file");

            using (StreamReader sr = File.OpenText("reminders.txt")) {
                string input = null;
                while ((input = sr.ReadLine()) != null) {
                    Console.WriteLine(input);
                }
            }
            Console.ReadLine();
        }
    }
}
