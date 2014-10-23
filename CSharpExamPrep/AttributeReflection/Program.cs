using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Reflection;
               //ng_MS
namespace AttributeReflection {

    [DataContract(Name = "Customer")]
    class MyObject { 
        [DataMember]
        public string FirstName;
    }

    class CustomSerializer {
        public static void  SerializeJson(object target) {
            Type typeObj = target.GetType();
            var typeAttr = typeof(DataContractAttribute);

            Attribute attr1 = typeObj.GetCustomAttributes(typeAttr).FirstOrDefault();            
            Console.WriteLine(((DataContractAttribute)attr1).Name);

            CustomAttributeData attr2 = (from a in typeObj.GetTypeInfo().CustomAttributes
                        where a.AttributeType == typeAttr
                             select a).FirstOrDefault();

            Console.WriteLine("constructor args");
           
            foreach (CustomAttributeTypedArgument cata in attr2.ConstructorArguments) {
                Console.WriteLine(cata);
            }
            Console.WriteLine("namedargs");
            foreach (CustomAttributeNamedArgument cana in attr2.NamedArguments) {
                Console.WriteLine(cana);
            }
            //Console.WriteLine(attr2.ConstructorArguments);  //type only

            Console.WriteLine("sel args");
            Attribute attr3 = (from a in typeObj.GetCustomAttributes()
                            where a.GetType() == typeAttr
                             select a).FirstOrDefault();
            Console.WriteLine(((DataContractAttribute)attr3).Name);

            CustomAttributeData attr4 = typeObj.CustomAttributes.
                Where (a => a.GetType() == typeAttr).FirstOrDefault();
         //   foreach (CustomAttributeTypedArgument cata in attr4.ConstructorArguments) {
         //       Console.WriteLine(cata);
         //   }

        }
    }

    class Program {
        static void Main(string[] args) {
            
            var obj = new MyObject();
            CustomSerializer.SerializeJson(obj);

            Console.ReadLine();
        }
    }
}
