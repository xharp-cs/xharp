using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices; 

namespace Efi
{
    using EfiHandle = UIntPtr; 
    public unsafe struct EfiSimpleTextOutputProtocol
    {
        public IntPtr Reset;
        public IntPtr OutputStringPtr;
        public IntPtr QueryMode;
        public IntPtr SetMode;
        public IntPtr SetAttribute;
        public IntPtr ClearScreen;
        public IntPtr SetCursorPosition;
        public IntPtr EnableCursor;
        public IntPtr Mode;
    }

    public enum Efi_Status : ulong { Success = 0, }

    public unsafe struct EfiSystemTable
    {
        public fixed byte _pad0[52];
        public EfiHandle ConsoleOutHandle;
        public EfiSimpleTextOutputProtocol* ConOut;
    }
}