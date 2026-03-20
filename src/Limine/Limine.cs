using System;
using System.Runtime.InteropServices;

namespace LimineBootloader;

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

    public unsafe struct File
    {
        public nint Name;
        public UInt64 Revision;
        public void* Address;
        public UInt64 Size;
        public nint Path;
        public nint String;
    }

    [DllImport("*", EntryPoint = "GetFont")]
    public unsafe static extern File* GetFont();
}