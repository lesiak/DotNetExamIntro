using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExamPrep {
    class Program {
        static void Main(string[] args) {
            #region local variable capture

            int[] values = { 1, 3, 5, 7, 9 };
            int threshold = 6;
            var highValues = from v in values where v >= threshold select v;
            threshold = 3;
            var results = highValues.ToList();
            foreach (var item in results) {
                Console.WriteLine(item);
            }

            #endregion

            var storedPasswordHash = new byte[] { 148, 152 };
            var storedPasswordHash1 = new byte[] { 148, 152 };
            Console.WriteLine(storedPasswordHash.Equals(storedPasswordHash1));     //False
            Console.WriteLine(storedPasswordHash.SequenceEqual(storedPasswordHash1));     //True
             //     SHA1
          //  Func
                // System.Diagnostics.Trace
            Console.ReadLine();
        }
    }
}
