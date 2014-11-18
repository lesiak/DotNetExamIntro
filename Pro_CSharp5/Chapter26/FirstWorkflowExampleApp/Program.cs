using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Threading;

namespace FirstWorkflowExampleApp {

    class Program {
        static void Main(string[] args) {
            Dictionary<string, object> wfArgs = new Dictionary<string, object>();
            wfArgs.Add("MessageToShow", "Hello");

            Activity workflow1 = new Workflow1();
           
            //RunWithWorkflowInvoker(workflow1, wfArgs);
            RunWithWorkflowApplication(workflow1, wfArgs);
            
            
            Console.ReadLine();
        }

        static void RunWithWorkflowInvoker(Activity workflow1, Dictionary<string, object> wfArgs) {
            WorkflowInvoker.Invoke(workflow1, wfArgs);
            Console.WriteLine("Done");
        }

        static void RunWithWorkflowApplication(Activity workflow1, Dictionary<string, object> wfArgs) {
            AutoResetEvent waitHandle = new AutoResetEvent(false);
            WorkflowApplication app = new WorkflowApplication(workflow1, wfArgs);

            app.Completed = (completedArgs) => {
                waitHandle.Set();
                Console.WriteLine("Workflow done");
            };

            app.Run();

            waitHandle.WaitOne();
            Console.WriteLine("Done");
        }
    }
}
