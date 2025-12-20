using System;
namespace System
{
    public struct Int16 { }
    public struct Int32 { public static short Abs(short value) => Math.Abs(value); }
    public struct Int64 { public static long Abs(long value) => Math.Abs(value); }
    public struct IntPtr
    {
        public static readonly IntPtr Zero;
        private readonly nint _value;

        public IntPtr(int value) { }
        public IntPtr(long value) { }
        public unsafe IntPtr(void* value) { }
        public static IntPtr Abs(IntPtr value) => Math.Abs(value);
        public unsafe void* ToPointer() => (void*)_value;
    }
}