using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConnectedLayer;

namespace AdoNetTransaction {
    class Program {
        static void Main(string[] args) {
            
            InventoryDAL dal = new InventoryDAL();
            dal.OpenConnection(@"Data Source=(local)\SQLExpress;Initial Catalog=AutoLot;Integrated Security=True");
            Console.WriteLine("Simulating db error");
            dal.ProcessCreditRisk(throwEx: true, custID: 333);
            Console.WriteLine();

            Console.WriteLine("moving client");
            dal.ProcessCreditRisk(throwEx: false, custID: 333);

            Console.ReadLine();
        }
    }
}
