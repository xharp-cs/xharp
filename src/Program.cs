using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using LimineBootloader;
using Utils;

public class Program : System.Object
{
    [System.Runtime.InteropServices.UnmanagedCallersOnly(EntryPoint = "KernelEntry", CallConvs = new[] { typeof(CallConvCdecl) })]
    public static unsafe int KernelMain(ulong boot_info_address)
    {
        Graphics.Init();
        PSF.Init();

        Console.SetUp();
        Console.WriteLine("[-] Serial init...");
        Serial.Init(0x3f8);
        Serial.Write("Serial initalized on COM1(0x3f8).");
        Console.WriteLine("[OK] Serial init");
        /*
        Console.WriteLine("This text is written by write2 method!");
        Console.WriteLine("Aa Bb Cc Dd Ee Ff Gg Hh Ii Jj Kk Ll Mm Nn Oo Pp Qq Rr Ss Tt Uu Vv Ww Xx Yy Zz.");
        Console.WriteLine(10);     
        Console.WriteLine(0xffffffffffffffff);
        */

        ASM.Hcf();


        return 0;
    }
}