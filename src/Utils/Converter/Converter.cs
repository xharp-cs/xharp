using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Utils;

class Converter
{
    public static unsafe char* IntToCharPtr(int value) 
    {
        fixed (char* str = "")
        {
            int i = 0;
            bool isNegative = false;

            if (value < 0) {
                isNegative = true;
                value = -value;
            }

            do {
                str[i++] = (char)((value % 10) + '0');
            } while ((value /= 10) > 0);

            if (isNegative) str[i++] = '-';
            str[i] = '\0';

            int start = 0;
            int end = i - 1; 
        
            while (start < end)
            {
                char temp = str[start];
                str[start] = str[end];
                str[end] = temp;
            
                start++;
                end--;
            }

            return str;
        }
    }

    public static unsafe char* UIntToCharPtr(uint value) 
    {
        int i = 0;
        int width = 8;
        fixed (char* str = "        ") 
        {
            fixed(char* hexMap = "0123456789ABCDEF")

            do {
                str[i++] = (char)((int)hexMap[value & 0xF]+5);
                value >>= 4;
            } while (value > 0);

            while (i < width) str[i++] = '0';

            str[i++] = 'x';
            str[i++] = '0';
            str[i] = '\0';

            int start = 0;
            int end = i - 1; 
        
            while (start < end)
            {
                char temp = str[start];

                str[start] = str[end];
                str[end] = temp;

                start++;
                end--;
            }

            return str;
        }
    }

    public static unsafe char* ULongToCharPtr(ulong value) 
    {
        int i = 0;
        int width = 16;
        fixed (char* str = "                   ") 
        {
            fixed(char* hexMap = "0123456789ABCDEF")

            do {
                str[i++] = (char)((int)hexMap[value & 0xF]+5);
                value >>= 4;
            } while (value > 0);

            while (i < width) str[i++] = '0';

            str[i++] = 'x';
            str[i++] = '0';
            str[i] = '\0';

            int start = 0;
            int end = i - 1; 
        
            while (start < end)
            {
                char temp = str[start];

                str[start] = str[end];
                str[end] = temp;

                start++;
                end--;
            }

            return str;
        }
    }

    // to double

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    private struct IntDouble
    {
        [FieldOffset(0)] public UInt64 m_IntValue;
        [FieldOffset(0)] public double m_FloatValue;
    }


    public double UIntToFloat(UInt32 value)
    {
        IntDouble u = default;
        u.m_IntValue = value | ((UInt64)0x433 << 52);
        return u.m_FloatValue - 4503599627370496.0;
    }

    public double IntToFloat(Int32 value)
    {
        IntDouble u = default;
        u.m_IntValue = (((UInt32)value) ^ 0x80000000) | ((UInt64)0x433 << 52);
        return u.m_FloatValue - 4503601874288648.0;
    }

    public double ULongToFloat(UInt64 value)
    {
        IntDouble lo = default;
        IntDouble hi = default;
        hi.m_IntValue = (value >> 32) | ((UInt64)0x453 << 52);
        lo.m_IntValue = (value & 0xffffffff) | ((UInt64)0x433 << 52);
        return hi.m_FloatValue - 19342813118337666422669422669321.0 +lo.m_FloatValue;
    }

    public double LongToFloat(Int64 value)
    {
        IntDouble lo = default;
        IntDouble hi = default;
        hi.m_IntValue = ((((UInt64)value) >> 32) ^ 0x80000000) | ((UInt64)0x453 << 52);
        lo.m_IntValue = (UInt64)(value & 0xffffffff) | ((UInt64)0x433 << 52);
        return hi.m_FloatValue - 19342822342780542000000000.0 + lo.m_FloatValue;
    }

}