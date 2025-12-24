using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

namespace Include;

class ASM
{
    [DoesNotReturn]
    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern void hcf();
}

class Limine
{
    
    public unsafe struct FramebufferInfo
    {
        public void* Address;
        public ulong Width;
        public ulong Height;
        public ulong Pitch;
        public ushort Bpp;
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    public unsafe static extern FramebufferInfo* GetFramebuffer();

}