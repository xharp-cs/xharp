using System;
using System.Runtime.CompilerServices;
using Include;

public class Program : System.Object
{
    public Program() : base() { }
    ~Program() { }

    public static int Main() => 0;

    [System.Runtime.InteropServices.UnmanagedCallersOnly(EntryPoint = "KernelEntry", CallConvs = new[] { typeof(CallConvCdecl) })]
    public static unsafe int KernelMain(ulong boot_info_address)
    {
        Limine.FramebufferInfo* framebuffer = Limine.GetFramebuffer();
        if (framebuffer == null)
            ASM.hcf();

        for (ulong i = 0; i < 100; i++) {
            uint* fb_ptr = (uint*)framebuffer->Address;
            fb_ptr[i * (framebuffer->Pitch/ 4) + i] = 0xffffff;
            fb_ptr[i * (framebuffer->Pitch/ 4) + i+10] = 0xffffff;
            fb_ptr[i * (framebuffer->Pitch/ 4) + i+20] = 0xffffff;
            fb_ptr[i * (framebuffer->Pitch/ 4) + i+30] = 0xffffff;
            fb_ptr[i * (framebuffer->Pitch/ 4) + i+40] = 0xffffff;
        }
        ASM.hcf();

        return 0;
    }

}