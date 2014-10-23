using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp {
    class Program {
        static void Main(string[] args) {
            ShowWindowsDirectoryInfo();
            DisplayImages();
            ModifyAppDirectory();
            FunWithDirectoryType();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo() {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine();
        }

        static void DisplayImages() {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            Console.WriteLine(dir.Exists);

            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            Console.WriteLine("Found {0} *.jpg files", imageFiles.Length);

            foreach (FileInfo fi in imageFiles) {
                Console.WriteLine("File Name: {0}", fi.Name);
                Console.WriteLine("File Size: {0}", fi.Length);
                Console.WriteLine("Creation: {0}", fi.CreationTime);
                Console.WriteLine("Attributes: {0}", fi.Attributes);
                Console.WriteLine();
            }
        }

        static void ModifyAppDirectory() {
            DirectoryInfo dir = new DirectoryInfo(".");

            dir.CreateSubdirectory("MyFolder");
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder\Data");
            Console.WriteLine("New folderr is {0}", myDataFolder);
            Console.WriteLine();
        }

        static void FunWithDirectoryType() {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Drives on this machine:");
            foreach (string s in drives) {
                Console.WriteLine(s);
            }

            Console.WriteLine("Deleting MyFolder");
            try {
                Directory.Delete(@".\MyFolder", recursive: true);
                Console.WriteLine("Done");
            } catch (IOException ex) {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
