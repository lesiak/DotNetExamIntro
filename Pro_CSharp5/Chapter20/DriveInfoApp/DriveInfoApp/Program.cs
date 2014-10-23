using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DriveInfoApp {
    class Program {
        static void Main(string[] args) {
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in myDrives) {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("DriveType: {0}", d.DriveType);

                if (d.IsReady) {
                    Console.WriteLine("TotalFreeSpace: {0}", d.TotalFreeSpace);
                    Console.WriteLine("DriveFormat: {0}", d.DriveFormat);
                    Console.WriteLine("VolumeLabel: {0}", d.VolumeLabel);
                }
            }
            Console.ReadLine();
        }
    }
}
