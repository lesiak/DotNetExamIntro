using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Reflection.Emit;

namespace DynamicAsmBuilder {
    class Program {
        static void Main(string[] args) {
            CreateMyAsm(AppDomain.CurrentDomain);
            Console.WriteLine("-> Finished creating MyAssembly.dll");

            Console.WriteLine("-> Loading MyAssembly.dll from file");
            Assembly a = Assembly.Load("MyAssembly");

            Type hello = a.GetType("MyAssembly.HelloWorld");
            Console.Write("-> Enter message to pass HelloWorld class: ");
            string msg = Console.ReadLine();
            object[] ctorArgs = { msg };
            dynamic hwObj = Activator.CreateInstance(hello, ctorArgs);
            Console.WriteLine("-> Saying hello via dynamic dispatch");
            hwObj.SayHello();

            Console.WriteLine(hwObj.GetMsg());
            Console.ReadLine();
        }

        static void CreateMyAsm(AppDomain currAppDomain) {
            AssemblyName assemblyName = new AssemblyName();
            assemblyName.Name = "MyAssembly";
            assemblyName.Version = new Version("1.0.0.0");

            AssemblyBuilder assembly = currAppDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);

            ModuleBuilder module = assembly.DefineDynamicModule("MyAssembly", "MyAssembly.dll");

            TypeBuilder helloWorldClass = module.DefineType("MyAssembly.HelloWorld", TypeAttributes.Public);

            FieldBuilder msgField = helloWorldClass.DefineField("theMessage", typeof(string), FieldAttributes.Private);

            Type[] constructorArgs = new Type[1];
            constructorArgs[0] = typeof(string);

            ConstructorBuilder constructor = helloWorldClass.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, constructorArgs);
            ILGenerator constructorIL = constructor.GetILGenerator();
            constructorIL.Emit(OpCodes.Ldarg_0);
            Type objectClass = typeof(object);

            ConstructorInfo superConstructor = objectClass.GetConstructor(new Type[0]);
            constructorIL.Emit(OpCodes.Call, superConstructor);
            constructorIL.Emit(OpCodes.Ldarg_0);
            constructorIL.Emit(OpCodes.Ldarg_1);
            constructorIL.Emit(OpCodes.Stfld, msgField);
            constructorIL.Emit(OpCodes.Ret);

            helloWorldClass.DefineDefaultConstructor(MethodAttributes.Public);

            MethodBuilder getMsgMethod = helloWorldClass.DefineMethod("GetMsg", MethodAttributes.Public, typeof(string), null);
            ILGenerator methodIL = getMsgMethod.GetILGenerator();
            methodIL.Emit(OpCodes.Ldarg_0);
            methodIL.Emit(OpCodes.Ldfld, msgField);
            methodIL.Emit(OpCodes.Ret);

            MethodBuilder sayHiMethod = helloWorldClass.DefineMethod("SayHello", MethodAttributes.Public, null, null);
            methodIL = sayHiMethod.GetILGenerator();
            methodIL.EmitWriteLine("Hello from the HelloWorld class");
            methodIL.Emit(OpCodes.Ret);

            helloWorldClass.CreateType();

            assembly.Save("MyAssembly.dll");




        }
    }
}
