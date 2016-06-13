
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.module extern calc.netmodule
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly calc
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.file calc.netmodule
    .hash = (1D 27 55 51 72 1D E2 50 E2 4E 11 4E 5F D9 09 5A   // .'UQr..P.N.N_..Z
             7A D1 E1 33 )                                     // z..3
.class extern public Calc
{
  .file calc.netmodule
  .class 0x02000002
}
.module calc.exe
// MVID: {9751918F-2150-4F09-823A-D06573107EC9}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00E50000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] argv) cil managed
  {
    .entrypoint
    // Code size       149 (0x95)
    .maxstack  5
    .locals init (bool V_0,
             int32 V_1,
             int32 V_2,
             class [mscorlib]System.Exception V_3)
    IL_0000:  nop
    IL_0001:  ldarg.0
    IL_0002:  ldlen
    IL_0003:  conv.i4
    IL_0004:  ldc.i4.2
    IL_0005:  ceq
    IL_0007:  ldc.i4.0
    IL_0008:  ceq
    IL_000a:  stloc.0
    IL_000b:  ldloc.0
    IL_000c:  brfalse.s  IL_001c

    IL_000e:  nop
    IL_000f:  ldstr      "Use: Calc [number] [number], for example: Calc 10 6"
    IL_0014:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0019:  nop
    IL_001a:  br.s       IL_0094

    IL_001c:  nop
    .try
    {
      IL_001d:  nop
      IL_001e:  ldarg.0
      IL_001f:  ldc.i4.0
      IL_0020:  ldelem.ref
      IL_0021:  call       int32 [mscorlib]System.Int32::Parse(string)
      IL_0026:  stloc.1
      IL_0027:  ldarg.0
      IL_0028:  ldc.i4.1
      IL_0029:  ldelem.ref
      IL_002a:  call       int32 [mscorlib]System.Int32::Parse(string)
      IL_002f:  stloc.2
      IL_0030:  ldstr      "{0} + {1} = {2}"
      IL_0035:  ldloc.1
      IL_0036:  box        [mscorlib]System.Int32
      IL_003b:  ldloc.2
      IL_003c:  box        [mscorlib]System.Int32
      IL_0041:  ldloc.1
      IL_0042:  ldloc.2
      IL_0043:  call       int32 [.module calc.netmodule]Calc::Add(int32,
                                                                   int32)
      IL_0048:  box        [mscorlib]System.Int32
      IL_004d:  call       string [mscorlib]System.String::Format(string,
                                                                  object,
                                                                  object,
                                                                  object)
      IL_0052:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0057:  nop
      IL_0058:  ldstr      "{0} - {1} = {2}"
      IL_005d:  ldloc.1
      IL_005e:  box        [mscorlib]System.Int32
      IL_0063:  ldloc.2
      IL_0064:  box        [mscorlib]System.Int32
      IL_0069:  ldloc.1
      IL_006a:  ldloc.2
      IL_006b:  call       int32 [.module calc.netmodule]Calc::Subtract(int32,
                                                                        int32)
      IL_0070:  box        [mscorlib]System.Int32
      IL_0075:  call       string [mscorlib]System.String::Format(string,
                                                                  object,
                                                                  object,
                                                                  object)
      IL_007a:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_007f:  nop
      IL_0080:  nop
      IL_0081:  leave.s    IL_0094

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0083:  stloc.3
      IL_0084:  nop
      IL_0085:  ldloc.3
      IL_0086:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_008b:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_0090:  nop
      IL_0091:  nop
      IL_0092:  leave.s    IL_0094

    }  // end handler
    IL_0094:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file program.res
