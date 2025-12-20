using System;
using System.Runtime.CompilerServices;
public class Program : System.Object
{
    public Program() : base() { }
    ~Program() { }

    public static int Main() => 0;


    [System.Runtime.InteropServices.UnmanagedCallersOnly(EntryPoint = "KernelEntry", CallConvs = new[] { typeof(CallConvCdecl) })]
    public static unsafe int KernelMain(ulong boot_info_address)
    {
        return 0;
    }

}