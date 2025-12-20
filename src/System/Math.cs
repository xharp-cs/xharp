using System;

namespace System

{
    public static partial class Math
    {
        public static short Abs(short value)
        {
            int i = (int)value;
            if (i < 0) { return (short)-i; }
            else { return value; }
        }

        public static long Abs(long value)
        {
            if (value < 0) { return -value; }
            else { return value; }
        }

        public static nint Abs(nint value)
        {
            if (value < 0){value = -value;}
            return value;
        }
    }
}