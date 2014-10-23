using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello world!");
            foreach (String arg in args)                       
            {
                Console.WriteLine(arg);
            }

            string[] cmdArgs = Environment.GetCommandLineArgs();
            foreach (String arg in cmdArgs)
            {
                Console.WriteLine(arg);
            }

            ShowEnvironmentDetails();

            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Your name is {0} zzz test {0}", name);

            FormatNumericalData();
            DisplayMessage();

            Console.ReadLine();
        }

        private static void DisplayMessage()
        {

            string userMessage = string.Format("100000 in hex is {0:x}", 100000);
            System.Windows.MessageBox.Show(userMessage);
        }

        private static void FormatNumericalData()
        {
            Console.WriteLine("c - currency format {0:c}", 99999);
            Console.WriteLine("d9 - decimal format {0:d9}", 99999);
            Console.WriteLine("f3 fixed point format {0:f3}", 99999);
            Console.WriteLine("n numeric format {0:n}", 99999);
            Console.WriteLine("x hex format {0:x}", 99999);
        }

        private static void ShowEnvironmentDetails()
        {
            foreach (String drive in Environment.GetLogicalDrives())
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            Console.WriteLine("OS: {0}", Environment.OSVersion);
            Console.WriteLine("64 bit system: {0}", Environment.Is64BitOperatingSystem);
            Console.WriteLine("Number of Processors: {0}", Environment.ProcessorCount);
            Console.WriteLine(".NET Version {0}", Environment.Version);
            Console.WriteLine("Machine Name {0}", Environment.MachineName);
            Console.WriteLine("System directory {0}", Environment.SystemDirectory);

            ConsoleColor prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("GetFolderPath: {0}",
                Environment.GetFolderPath(Environment.SpecialFolder.System));
            Console.WriteLine("GetFolderPath: {0}",
                Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            
            
            Console.WriteLine("User name {0}", Environment.UserName);

            Console.ForegroundColor = prevColor;

            
        }
    }
}
