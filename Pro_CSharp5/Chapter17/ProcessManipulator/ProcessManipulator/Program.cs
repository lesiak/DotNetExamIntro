using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace ProcessManipulator {
    class Program {
        static void Main(string[] args) {
            ListAllRunningProcesses();
            Console.WriteLine("*** Enter PID of process to investigate ***");
//            Console.Write("PID: ");
  //          string pID = Console.ReadLine();
    //        int theProcID = int.Parse(pID);
      //      DisplayProcessInfo(theProcID);

            DisplayProcessInfo(Process.GetCurrentProcess().Id);
            StartAndKillProcess();

            Console.ReadLine();

        }

        static void ListAllRunningProcesses() {
            var runningProcs = from proc in Process.GetProcesses(".")
                               orderby proc.Id
                               select proc;

            foreach (var p in runningProcs) {
                string info = string.Format("-> PID {0}\tName: {1}", p.Id, p.ProcessName);
                Console.WriteLine(info); 
            }
            Console.WriteLine();
        }

        static void DisplayProcessInfo(int pID) {
            Process theProc = null;
            try {
                theProc = Process.GetProcessById(pID);
            } catch (ArgumentException ex) {
                Console.WriteLine(ex);
                return;
            }
            EnumThreadsForProcess(theProc);
            EnumModsForProcess(theProc);
        }

        static void EnumThreadsForProcess(Process theProc) {            
            Console.WriteLine("Here are the thereads used by {0}", theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;

            foreach (ProcessThread pt in theThreads) {
                string info = string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2}", pt.Id, pt.StartTime, pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine();
        }

        static void EnumModsForProcess(Process theProc) {
            Console.WriteLine("Here are the loaded modules for {0}", theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;

            foreach (ProcessModule pm in theMods) {
                string info = string.Format("-> Mod Name: {0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine();
        }

        static void StartAndKillProcess() {
            Process ieProc = null;

            try {
                //ieProc = Process.Start("IExplore.exe", "www.gazeta.pl");

                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", "www.gazeta.pl");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                ieProc = Process.Start(startInfo);
            } catch (InvalidOperationException ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Hit enter to Kill Process {0}...");
            Console.ReadLine();

            try {
                ieProc.Kill();
            } catch (InvalidOperationException ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
