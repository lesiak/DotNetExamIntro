using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionTest {
    class Program {
        static void Main(string[] args) {
            ccc();
            int @aaa = 0;
            Console.WriteLine(@aaa);
            Console.ReadLine();
        }

        static void aaa() {
            throw new Exception("Dupa");
        }

        static void bbb() {
            try {
                aaa();
            } catch (Exception e) {
                Console.WriteLine(e.HResult);
                Console.WriteLine(e);
                //throw e;        //resets stack trace
                throw;
            }
        }

        static void ccc() {
            bbb();  //unhandled
            //try {
            //    bbb();
            // } catch (Exception e) {
            //Console.WriteLine(e);
            //}
        }
    }
}
