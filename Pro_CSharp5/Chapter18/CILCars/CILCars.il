.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}

.assembly extern System.Windows.Forms
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )    
  .ver 4:0:0:0
}


.assembly CILCars {
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module CILCars.dll

.namespace CILCars {
	
	.class public auto ansi beforefieldinit CILCar extends [mscorlib]System.Object {
		.field public string petName
		.field public int32  currSpeed

		.method public hidebysig specialname rtspecialname
		instance void .ctor(int32 c, string p) cil managed {
			.maxstack 9
			ldarg.0    //this object
			call instance void [mscorlib]System.Object::.ctor()

			ldarg.0
			ldarg.1
			stfld int32 CILCars.CILCar::currSpeed

			ldarg.0
			ldarg.2
			stfld string CILCars.CILCar::petName
			ret
		}


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

		.method public hidebysig static int32 Add(int32 a, int32 b) cil managed {
			.maxstack 2
			ldarg.0
			ldarg.1
			add
			ret
		}



	}

	.class public auto ansi beforefieldinit CILCarInfo extends [mscorlib]System.Object {

		.method public hidebysig static void
		Display(class CILCars.CILCar c) cil managed {
			.maxstack 8

			.locals init ([0] string caption)

			ldstr "{0}'s speed is"
			ldarg.0

			ldfld string CILCars.CILCar::petName
			call string [mscorlib]System.String::Format(string, object)
			stloc.0

			ldarg.0
			ldflda int32 CILCars.CILCar::currSpeed
			call instance string [mscorlib]System.Int32::ToString()
			ldloc.0

			call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult
			[System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string)

			pop
			ret
		}

	}

}