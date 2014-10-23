using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Events {
    class Program {

        event EventHandler UserChanged;

        public void doSth() {
            fireUserChanged();
        }

        private void fireUserChanged() {
            if (UserChanged == null) {
                return;
            }
            UserChanged(this, new EventArgs());
        }

        static void Main(string[] args) {
            Program p = new Program();
            p.UserChanged += (o, e) => {
                Console.WriteLine("received event");
            };
            p.doSth();
          
            Console.ReadLine();
        }

      
    }
}
