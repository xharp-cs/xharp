using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace Include;

class ASM
{
    [DoesNotReturn]
    [DllImport("*", EntryPoint = "Hcf")]
    public static extern void Hcf();
}

class Limine
{
    
    public unsafe struct Framebuffer
    {
        public void* Address;
        public ulong Width;
        public ulong Height;
        public ulong Pitch;
        public ushort Bpp;
    }

    [DllImport("*", EntryPoint = "GetFramebuffer")]
    public unsafe static extern Framebuffer* GetFramebuffer();

}