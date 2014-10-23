using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryWriterReaderApp {
    class Program {
        static void Main(string[] args) {
            FileInfo f = new FileInfo("BinFile.dat");

            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite())) {
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);
                double aDouble = 1234.67;
                int anInt = 34567;
                string aString = "A, B, C";

                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            
            }

            using (BinaryReader br = new BinaryReader(f.OpenRead())) {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }

            Console.WriteLine("Done!");
            Console.ReadLine();
        
        }
    }
}
