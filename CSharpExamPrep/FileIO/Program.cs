using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileIO {
    class Program {
        static void Main(string[] args) {
            StreamWriter sw = File.CreateText("mytext.txt");
            sw.Write("Some data");
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.WaitForPendingFinalizers();
                      
        //    File.Delete("mytext.txt");
                
          //  String s = "aa";
            StringWriter strWriter = new StringWriter();

            XmlWriter writer = XmlWriter.Create(strWriter);
            writer.WriteStartElement("x", "root", "123");
            writer.WriteStartElement("item");
            writer.WriteAttributeString("xmlns", "x", null, "abc");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
            Console.WriteLine(strWriter.ToString());
            var x = new {Name = "AAA"};
            Console.WriteLine(x.GetType().IsClass);
              //CultureInfo.CreateSpecificCulture
            Console.ReadLine();
        }
    }
}
