using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StringReaderWriterApp {
    class Program {
        static void Main(string[] args) {
            using (StringWriter strWriter = new StringWriter()) {
                strWriter.WriteLine("Don't forget x");

                Console.WriteLine("Contents of strWriter\n{0}", strWriter.ToString());
                StringBuilder sb = strWriter.GetStringBuilder();

                sb.Insert(0, "Hey!");
                Console.WriteLine("-> {0}", sb.ToString());

                sb.Remove(0, "Hey!".Length);
                Console.WriteLine("-> {0}", sb.ToString());
            
            
            
            }

            string txt = @"aaa
aaas
dasa

dsadsasa";
            Console.WriteLine(txt);
            Console.WriteLine("Reading txt:");

            using (StringReader sr = new StringReader(txt)) {
                string input = null;
                while ((input = sr.ReadLine()) != null) {
                    Console.WriteLine(input);
                }
            }

            Console.ReadLine();
        }
    }
}
