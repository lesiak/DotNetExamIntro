using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleException
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    myCar.Accelerate(10);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error!");
                Console.WriteLine("TargetSite: {0}", e.TargetSite);
                Console.WriteLine("Class defining: {0}", e.TargetSite.DeclaringType);
                Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
                Console.WriteLine("Message: {0}", e.Message);
                Console.WriteLine("Source: {0}", e.Source);
                Console.WriteLine("StackTrace: {0}", e.StackTrace);
                Console.WriteLine("HelpLink: {0}", e.HelpLink);
                if (e.Data != null)
                {
                    Console.WriteLine("Custom Data:");
                    foreach (DictionaryEntry de in e.Data)
                    {
                        Console.WriteLine("\t {0} -> {1}", de.Key, de.Value);
                    }
                }
            }


            Console.ReadLine();
        }
    }

    

    
}
