using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace CheckInventoryWorkflowLib {

    public sealed class CreateSalesMemoActivity : CodeActivity {
        // Define an activity input argument of type string
        public InArgument<string> Make { get; set; }
        public InArgument<string> Color { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context) {
            // Obtain the runtime value of the Text input argument
            StringBuilder salesMessage = new StringBuilder();
            salesMessage.AppendLine("*** Message To Sales ***");
            salesMessage.AppendLine("Please order the following ASAP!");
            salesMessage.AppendFormat("1 {0} {1}\n", context.GetValue(Color), context.GetValue(Make));
            System.IO.File.WriteAllText("SalesMemo.txt", salesMessage.ToString());
        }
    }
}
