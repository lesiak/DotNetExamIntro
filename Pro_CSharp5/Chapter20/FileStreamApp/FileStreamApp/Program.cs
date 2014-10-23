using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileStreamApp {
    class Program {
        static void Main(string[] args) {

            using (FileStream fStream = File.Open(@".\myText.dat", FileMode.Create)) {
                string msg = "Hello";
                Console.WriteLine(Encoding.Default);
                byte[] msgAsBytesArray = Encoding.Default.GetBytes(msg);
                fStream.Write(msgAsBytesArray, 0, msgAsBytesArray.Length);

                fStream.Position = 0;

                Console.WriteLine("Msg as array of bytes");
                byte[] bytesFromFile = new byte[msgAsBytesArray.Length];
                for (int i = 0; i < msgAsBytesArray.Length; i++) {
                    bytesFromFile[i] = (byte) fStream.ReadByte();
                    Console.WriteLine(bytesFromFile[i]);
                }

                Console.Write("Decoded message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
            Console.ReadLine();
        }
    }
}
 