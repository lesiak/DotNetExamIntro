using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections {
    class Program {
        static void Main(string[] args) {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(11);
            queue.Enqueue(22);
            queue.Enqueue(33);
            
            // Console.WriteLine(q.get[0]);

            var data = Enumerable.Range(1, 50).Where(x => x%2==0);
            var qeryable = data.AsQueryable();
            Console.WriteLine(qeryable);
          //  Console.WriteLine("Expression {0}", qeryable.Expression);
            var cc = new {Name = "dsada"};
            var dd = cc;
          //  cc.Name = "a"; //read only
           // Console.WriteLine(cc.Name);
            Console.WriteLine("IS value type {0}", cc.GetType().IsValueType);

                 
           // Console.WriteLine(data is IQueryable);
            //Console.WriteLine(data1 is IQueryable);
            

            Parallel.ForEach(queue, (item, state, i) => Console.WriteLine("{0} {1}", item, i));

            List<int> ll = new List<int>();
            Console.WriteLine(ll.Count);    //property
            Console.WriteLine(ll.Count());  //extension

            Console.ReadLine();
            //StringReader
            //Parallel.ForEach
        }
    }
}
