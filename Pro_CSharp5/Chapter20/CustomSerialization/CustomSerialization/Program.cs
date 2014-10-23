using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace CustomSerialization {
    class Program {
        static void Main(string[] args) {
            StringData sd = new StringData();
            MoreData md = new MoreData();

            SoapFormatter soapFormat = new SoapFormatter();

            using (Stream fStream = new FileStream("MyDataSoap.xml", FileMode.Create, FileAccess.Write, FileShare.None)) {
                soapFormat.Serialize(fStream, sd);
            }

            using (Stream fStream = new FileStream("MyDataSoap1.xml", FileMode.Create, FileAccess.Write, FileShare.None)) {
                soapFormat.Serialize(fStream, md);
            }

            Console.WriteLine("Serialization done!");
            Console.WriteLine("More data after serialization {0}", md.dataItemOne);
            Console.ReadLine();
        }
    }
}
