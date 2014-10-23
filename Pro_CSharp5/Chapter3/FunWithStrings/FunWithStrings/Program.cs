using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicStringFunctionality();
            StringConcatenation(); 
            EscapeChars();
            StringEquality();
            StringsAreImmutable2();
            FunWithStringBuilder();
            Console.ReadLine();

        }

        static void BasicStringFunctionality() {
            Console.WriteLine("=> Basic String functionality:");
            string firstName = "Freddy";
            Console.WriteLine("Value of firstName {0}", firstName);
            Console.WriteLine("firstName has {0} characters", firstName.Length);
            Console.WriteLine("firstName in uppercase {0}", firstName.ToUpper());
            Console.WriteLine("firstName in lowercase {0}", firstName.ToLower());
            Console.WriteLine("firstName contails lettet y? {0}", firstName.Contains('y'));
            Console.WriteLine("firstName after replace? {0}", firstName.Replace("dy", ""));
            Console.WriteLine();
        }

        static void StringConcatenation()
        {
            Console.WriteLine("=> String concatenation:");
            Console.WriteLine("+ operator {0}","Hello" + " World");
            Console.WriteLine("String.Concat {0}", String.Concat("Hello", " World"));
            Console.WriteLine();
        }

        static void EscapeChars() {
            Console.WriteLine("=> Escape characters:");
            string strWithTabs = "Model\tColor\tSpeed";
            Console.WriteLine(strWithTabs);

            Console.WriteLine("Now withh double  \"quotes \"");
            Console.WriteLine("C:\\AAA");
            Console.WriteLine("aaa\naaav");

            Console.WriteLine(@"C:\AAA\Debug");
            
            string longString = @"aaa
                bbb
                    ccc";
            Console.WriteLine(longString);

            Console.WriteLine(@"He said""argh""");
        }

        static void StringEquality()
        {
            Console.WriteLine("=> String Equality:");
            string s1 = "Hello!";
            string s2 = "Yo!";
            Console.WriteLine("s1 = {0}", s1);
            Console.WriteLine("s2 = {0}", s2);
            Console.WriteLine();

            Console.WriteLine("s1 == s2: {0}", s1 == s2);
            Console.WriteLine("s1 == Hello!: {0}", s1 == "Hello!");
            Console.WriteLine("s1 == HELLO!: {0}", s1 == "HELLO!");
            Console.WriteLine("s1 == hello!: {0}", s1 == "hello!");
            Console.WriteLine("s1.Equals(s2): {0}", s1.Equals(s2));
            Console.WriteLine("Yo.Equals(s2): {0}", "Yo!".Equals(s2));
            Console.WriteLine();
        }

        static void StringsAreImmutable2() 
        {
            string s2 = "Other string";
            s2 = "new valie";

            
        }

        static void FunWithStringBuilder() 
        {
            Console.WriteLine("=> Using th StringBuilder:", 256);
            StringBuilder sb = new StringBuilder("***********-----**********");
            sb.AppendLine();
            sb.AppendLine("one");
            sb.AppendLine("two");
            sb.AppendLine("three");
            Console.WriteLine(sb.ToString());
            sb.Replace("two", "2");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("sb has {0} chars", sb.Length);
            Console.WriteLine();

        }
    }
}
