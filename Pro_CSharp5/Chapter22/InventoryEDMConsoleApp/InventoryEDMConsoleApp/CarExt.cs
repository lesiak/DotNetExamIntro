using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryEDMConsoleApp {
    public partial class Car {
        public override string ToString() {
            return string.Format("{0} is a {1} {2} with id {3}",
                CarNickName ?? "**No Name",                    
                Color,
                Make, 
                CarID);
        }

        /*partial void OnCarNicknameChanging(global::System.String value) {
            Console.WriteLine("-> Changing name to {0}", value);
        } */
    }
}
