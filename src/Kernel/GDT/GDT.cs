using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Utils;

public unsafe class Gdt 
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct GDT
    {
        public ulong Null, KernelCode, KernelData, UserCode, UserData;
    }

    static GDT gdt = new GDT{};

    public static void SetUp()
    {
        gdt.Null = 0;

        ulong kC = 0;
        kC |= 0b1011 << 8;
        kC |= 1 << 12;
        kC |= 0 << 13;
        kC |= 1 << 15; 
        kC |= 1 << 21;
        gdt.KernelCode = kC << 32;

        ulong kD = 0;
        kD |= 0b0011 << 8;
        kD |= 1 << 12;
        kD |= 0 << 13;
        kD |= 1 << 15; 
        kD |= 1 << 21;
        gdt.KernelData = kD << 32;

        ulong uC = kC | (3 << 13);
        gdt.UserCode = uC << 32;

        ulong uD = kD | (3 << 13);
        gdt.UserData = uD << 32;

        fixed(GDT* gdtP = &gdt)
            LoadGdt(5*sizeof(ulong)-1, (ulong)gdtP);
        FlushGdt();
    }

    [DllImport("*", EntryPoint = "LoadGdt")]
    public static extern void LoadGdt(ushort limit, ulong address);

    [DoesNotReturn]
    [DllImport("*", EntryPoint = "FlushGdt")]
    public static extern void FlushGdt();
}