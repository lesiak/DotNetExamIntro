using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimpleFileIO {
    class Program {
        static void Main(string[] args) {
            FileInfo f = new FileInfo(@".\Test.dat");
            //FileStream fs = f.Create();

            //  fs.Close();

            using (FileStream fs = f.Create()) {
            }

            FileInfo f2 = new FileInfo(@".\Test2.dat");
            using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)) {

            }

            using (FileStream fs3 = f2.OpenRead()) {

            }

            using (FileStream fs4 = f2.OpenWrite()) {

            }

            FileInfo f5 = new FileInfo(@".\aaa.txt");
            using (StreamReader sReader = f5.OpenText()) {

            }

            FileInfo f6 = new FileInfo(@".\Test6.txt");
            using (StreamWriter sw = f6.CreateText()) {

            }

            FileInfo f7 = new FileInfo(@".\Test7.txt");
            using (StreamWriter sw = f7.AppendText()) {

            }

            using (FileStream fs8 = File.Create(@".\Test8.dat")) {

            }

            using (FileStream fs9 = File.Open(@".\Test9.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None)) {

            }

            using (FileStream fs = File.OpenRead(@".\Test9.dat")) {

            }

            using (FileStream fs = File.OpenWrite(@".\Test9.dat")) {

            }

            string[] tasks = {"Fix bathroom sink",
                             "call Dave",
                             "Call Mom and Dad",
                             "Plax XBox"};

            File.WriteAllLines(@".\tasks.txt", tasks);

            foreach (string task in File.ReadAllLines(@".\tasks.txt")) {
                Console.WriteLine("TODO: {0}", task);
            }
            Console.ReadLine();
        }
    }
}
