using System;
namespace System
{
    public struct Int16 { }
    public struct Int32 { public static short Abs(short value) => Math.Abs(value); }
    public struct Int64 { public static long Abs(long value) => Math.Abs(value); }
    public struct IntPtr
    {
        public static readonly IntPtr Zero;
        public static explicit operator IntPtr(int value) => (nint)value;

        public static explicit operator IntPtr(long value) => checked((nint)value);

        public static unsafe explicit operator IntPtr(void* value) => (nint)value;
        public static nint Add(nint pointer, int offset) => pointer + offset;
        public static nint Subtract(nint pointer, int offset) => pointer - offset;
        private readonly nint _value;

        public IntPtr(int value) { }
        public IntPtr(long value) { }
        public unsafe IntPtr(void* value) { }
        public static IntPtr Abs(IntPtr value) => Math.Abs(value);
        public unsafe void* ToPointer() => (void*)_value;
    }
}