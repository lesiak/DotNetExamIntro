using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose {
    class Program {
        static void Main(string[] args) {
            MyResourceWrapper rw = new MyResourceWrapper();
            rw.Dispose();

            try {
                MyResourceWrapper rw1 = new MyResourceWrapper();
            } finally {
                rw.Dispose();
            }

            using (MyResourceWrapper rw2 = new MyResourceWrapper(),
                rw3 = new MyResourceWrapper()) {
                
            }

            Console.ReadLine();
        }
    }

    class MyResourceWrapper : IDisposable {

        public void Dispose() {
            Console.WriteLine("In Dispose"); 
        }

        
    }
}
