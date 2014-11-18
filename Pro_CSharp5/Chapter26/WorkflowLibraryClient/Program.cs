using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckInventoryWorkflowLib;
using System.Activities;

namespace WorkflowLibraryClient {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine(" *** Inventory Look Up ***");
            string color = "Blue";
            string make = "BMW";

            Dictionary<string, object> wfArgs = new Dictionary<string, object>() {
                {"RequestedColor", color},
                {"RequestedMake", make},
            };
            try {
                IDictionary<string, object> outputArgs = WorkflowInvoker.Invoke(new CheckInventory(), wfArgs);
                Console.WriteLine(outputArgs["FormattedResponse"]);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
