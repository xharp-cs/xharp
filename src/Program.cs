using System;
using System.Runtime.CompilerServices;
using Include;
using Utils;

public class Program : System.Object
{
    public Program() : base() { }
    ~Program() { }

    public static int Main() => 0;

    [System.Runtime.InteropServices.UnmanagedCallersOnly(EntryPoint = "KernelEntry", CallConvs = new[] { typeof(CallConvCdecl) })]
    public static unsafe int KernelMain(ulong boot_info_address)
    {
        Limine.Framebuffer* framebuffer = Limine.GetFramebuffer();
        if (framebuffer == null)
            ASM.Hcf();

        Graphics.Init(framebuffer);

        for (ulong i = 0; i < 100; i++) {
            Graphics.PutPixel(i,i,0xffffff);
        }
        ASM.Hcf();

        return 0;
    }

}