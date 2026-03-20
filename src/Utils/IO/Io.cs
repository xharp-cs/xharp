using System;
using System.Runtime.InteropServices;

namespace Utils;

class Io
{
    [DllImport("*", EntryPoint = "inb")]
    public unsafe static extern byte InB(UInt16 port);

    [DllImport("*", EntryPoint = "outb")]
    public unsafe static extern void OutB(UInt16 port, byte value);
}