using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyDirectoryWatcher {
    class Program {
        static void Main(string[] args) {
            FileSystemWatcher watcher = new FileSystemWatcher();
            try {
                watcher.Path = @"C:\AAA";
            } catch (ArgumentException ex) {
                Console.WriteLine(ex.Message);
                return;
            }

            watcher.NotifyFilter = NotifyFilters.LastAccess
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName
                | NotifyFilters.DirectoryName;

            watcher.Filter = "*.txt";

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            watcher.EnableRaisingEvents = true;

            Console.WriteLine(@"Press 'q' to quit app");
            while (Console.Read() != 'q') {
                ;
            }

        }

        static void OnCreated(object source, FileSystemEventArgs e) {
            Console.WriteLine("Created File: {0} {1}!", e.FullPath, e.ChangeType);
        }

        static void OnChanged(object source, FileSystemEventArgs e) {
            Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
        }

        static void OnDeleted(object source, FileSystemEventArgs e) {
            Console.WriteLine("Deleted File: {0} {1}!", e.FullPath, e.ChangeType);
        }

        static void OnRenamed(object source, RenamedEventArgs e) {
            Console.WriteLine("File: {0} renamed to {1}!", e.OldFullPath, e.FullPath);
        }
    }
}
