using System;
using System.Reflection;
using Utils;


class Serial
{
    static int port;
    public static int Init(int _port)
    {
        port = _port;
        Io.OutB((ushort)(port+1), 0x00);
        Io.OutB((ushort)(port+3), 0x80);
        Io.OutB((ushort)(port+0), 0x03);
        Io.OutB((ushort)(port+1), 0x00);
        Io.OutB((ushort)(port+3), 0x03);
        Io.OutB((ushort)(port+2), 0xc7);
        Io.OutB((ushort)(port+4), 0x0b);
        Io.OutB((ushort)(port+4), 0x1e);
        Io.OutB((ushort)(port+0), 0xae);

        if(Io.InB((ushort)(port+0)) != 0xAE) {
            return 1;
        }

        Io.OutB((ushort)(port+4), 0x0f);
        return 0;
    }

    public static int Recived() {
        return Io.InB((ushort)(port + 5)) & 1;
    }

    public static char Read() {
        while (Recived() == 0);

        return (char)Io.InB((ushort)port);
    }

    public static int IsTransmitEmpty()
    {
        return Io.InB((ushort)(port+5));
    }

    public static void Write(char value)
    {
        while (IsTransmitEmpty()==0);
        Io.OutB((ushort)port, (byte)value);
    }

    public unsafe static void Write(char* value)
    {
        while (IsTransmitEmpty()==0);
        for (int i = 0; i < Helper.GetLengthOfCharPtr(value); i++)
        {
            Io.OutB((ushort)port, (byte)value[i]);
        }
    }

    public unsafe static void Write(String value)
    {
        while (IsTransmitEmpty()==0);
        fixed (char* s = value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                Io.OutB((ushort)port, (byte)s[i+5]);
            }
        }
    }

    public unsafe static void WriteLine(String value){Write(value); Io.OutB((ushort)port, 0x0A);}

}