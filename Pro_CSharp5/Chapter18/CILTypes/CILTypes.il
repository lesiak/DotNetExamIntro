.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}

.assembly CILTypes {
  .ver 1:0:0:0
}
.module CILTypes.dll

.namespace MyNamespace {
	.class public interface IMyInterface {}

	.class public interface IMyOtherInterface implements MyNamespace.IMyInterface {}

	.class public MyBaseClass {
		.field private string stringField = "hello"
		.field private int32 intField = int32(42)

		.method public hidebysig static void MyMethod(
			int32 inputInt, int32& refInt, class [mscorlib]System.Collections.ArrayList ar, [out] int32& outputInt) cil managed {
			//TODO
			ret
		}

		.method public hidebysig static void Speak() cil managed {
			.maxstack 1
			ldstr "Hello there"
			call void [mscorlib]System.Console::WriteLine(string)
			ret
		}


		.method public hidebysig static void MyLocalVariables() cil managed {
			.maxstack 8
			.locals init ([0] string myStr, [1] int32 myInt, [2] object myObj)
			ldstr "CIL code is fun"
			stloc.0

			ldc.i4 33
			stloc.1

			newobj instance void [mscorlib]System.Object::.ctor()
			stloc.2
			ret
		}

		.method public hidebysig static int32 Add(int32 a, int 32b) cil managed {
			.maxstack 2
			ldarg.0
			ldarg.1
			add
			ret
		}

		.method public hidebysig specialname rtspecialname
		instance void .ctor(string s, int32 i) cil managed {
			//TODO
			ret
		}

		.method public hidebysig specialname
		instance string get_TheString() cil managed {
			//TODO
			ret
		}

		.method public hidebysig specialname
		instance void set_TheString(string 'value') cil managed {
			//TODO
		}

		.property instance string TheString() {
			.get instance string MyNamespace.MyBaseClass::get_TheString()
			.set instance void MyNamespace.MyBaseClass::set_TheString(string)
		}

	}

	.class public MyDerivedClass 
			extends MyNamespace.MyBaseClass 
			implements MyNamespace.IMyInterface {}

	.class public sealed value MyStruct {}

	.class public sealed enum MyEnum {
		.field public static literal valuetype MyNamespace.MyEnum A = int32(0)
		.field public static literal valuetype MyNamespace.MyEnum B = int32(1)
		.field public static literal valuetype MyNamespace.MyEnum C = int32(2)

	}
}