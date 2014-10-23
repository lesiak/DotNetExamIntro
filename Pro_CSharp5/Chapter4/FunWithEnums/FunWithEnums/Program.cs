using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithEnums
{
    class Program
    {
        static void Main(string[] args)
        {
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            //Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(emp.GetType()));
            Console.WriteLine("EmpType uses a {0} for storage", Enum.GetUnderlyingType(typeof(EmpType)));

            Console.WriteLine("emp is a {0}", emp.ToString());
            Console.WriteLine("emp num value {0}", (byte)emp);

            Console.WriteLine("emp num value via Enum.Format {0}", Enum.Format(typeof(EmpType), emp, "d"));


           // int[] a = { 0, 1 };
           // Console.WriteLine(a.GetType());

            EvaluateEnum(EmpType.Contractor);
            EvaluateEnum(DayOfWeek.Monday);
            EvaluateEnum(ConsoleColor.Gray);
            Console.ReadLine();
            
        }

        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("Grubt");
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("contractor");
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("ok, Sir");
                    break;

            }

        }

        static void EvaluateEnum(Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}", Enum.GetUnderlyingType(e.GetType()));

            Array enumData = Enum.GetValues(e.GetType());
            //var x =  enumData[0];
          
            Console.WriteLine("This enum has {0} members", enumData.Length);
            for(int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value {0:D}", enumData.GetValue(i));
            }
            Console.WriteLine();
        }


    }

    enum EmpType : byte //cn cange the underlying type
    {
        Manager,  //=0
        // Manager,  //=0
        Grunt, //  = 11,      may have duplicate num value, but in switch it would say that 11 already occurs
        Contractor = 11,//need not to be sequential
        VicePresident //= 999 cannot be converted into byte
    }


}
