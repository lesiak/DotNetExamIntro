using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizableDisposableClass {
    class Program {
        static void Main(string[] args) {
            using (MyResourceWrapper rw = new MyResourceWrapper()) {
                rw.Dispose();
            }
            Console.ReadLine();
            MyResourceWrapper rw2 = new MyResourceWrapper();
        }
    }

    class MyResourceWrapper : IDisposable {

        private bool disposed = false;

        ~MyResourceWrapper() {
            // Does not execute
            CleanUp(false);
            Console.Beep();
        }

        public void Dispose() {
            Console.WriteLine("In Dispose");
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    Console.WriteLine("In CleanUp managed");
                }
                Console.WriteLine("In CleanUp unmanaged");
                disposed = true;
            }
        }


    }
}
