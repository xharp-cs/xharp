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
        Serial.WriteLine("Serial initalized on COM1(0x3f8). ");
        Console.WriteLine("[OK] Serial init");
        Console.WriteLine("[-] Gdt init...");
        Gdt.SetUp();
        Serial.WriteLine("GDT Init - OK. ");
        Console.WriteLine("[OK] GDT init");

        while(true) ASM.Hcf();
    }
}