using System.Runtime.CompilerServices;
using LimineBootloader;
using Utils;


namespace System;

public class Console
{
    static ulong xConsole;
    static ulong yConsole;

    public static void SetUp()
    {
        // setup offset
        xConsole=10;yConsole=10;

        // there something another will be
    }

    public static void Write(String value, int fgColor=0xffffff, int bgColor=0x000000)
    {
        PutString(value, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)value.Length*7;
    }

    public unsafe static void Write(int value, int fgColor=0xffffff, int bgColor=0x000000)
    {
        char* str = Converter.IntToCharPtr(value);
        PutString(str, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)Helper.GetLengthOfCharPtr(str)*7;
    }

    public unsafe static void Write(uint value, int fgColor = 0xffffff, int bgColor = 0x000000)
    {
        char* str = Converter.UIntToCharPtr(value);
        PutString(str, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)Helper.GetLengthOfCharPtr(str)*7;
    }

    public unsafe static void Write(ulong value, int fgColor = 0xffffff, int bgColor = 0x000000)
    {
        char* str = Converter.ULongToCharPtr(value);
        PutString(str, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)Helper.GetLengthOfCharPtr(str)*7;
    }

    public static void WriteLine(String value, int fgColor = 0xffffff, int bgColor = 0x000000)
    {
        PutString(value, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)value.Length*7;
        yConsole += 15;

        xConsole = 10;
    }

    public unsafe static void WriteLine(int value, int fgColor = 0xffffff, int bgColor = 0x000000)
    {
        char* str = Converter.IntToCharPtr(value);
        PutString(str, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)Helper.GetLengthOfCharPtr(str)*7;
        yConsole += 15;

        xConsole = 10;
    }

    public unsafe static void WriteLine(uint value, int fgColor = 0xffffff, int bgColor = 0x000000)
    {
        char* str = Converter.UIntToCharPtr(value);
        PutString(str, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)Helper.GetLengthOfCharPtr(str)*7;
        yConsole += 15;

        xConsole = 10;
    }

    public unsafe static void WriteLine(ulong value, int fgColor = 0xffffff, int bgColor = 0x000000)
    {
        char* str = Converter.ULongToCharPtr(value);
        PutString(str, xConsole, yConsole, fgColor, bgColor);
        xConsole += (ulong)Helper.GetLengthOfCharPtr(str)*7;
        yConsole += 15;

        xConsole = 10;
    }

    public static void Clear(int color){unsafe{ Graphics.FillRect(0,0,Graphics.fb_ptr->Width, Graphics.fb_ptr->Height, color);}}

    private unsafe static void PutChar(int c, ulong x, ulong y, int FgColor, int BgColor)
    {
        byte* glyph = PSF.GetGlyph(c);
        PSF.PSF2* font = PSF.font;

        if (glyph == null)
            return;

        uint rowBytes = (font->Width + 7) / 8;

        for (uint row = 0; row < font->Height; row++)
        {
            for (uint col = 0; col < font->Width; col++)
            {
                int byteIndex = (int)(row * rowBytes + col / 8);
                int bitIndex = 7 - (int)(col % 8);
                bool pixelOn = (glyph[byteIndex] & (1 << bitIndex)) != 0;
                Graphics.PutPixel(x + col, y + row, pixelOn ? FgColor : BgColor);
            }
        }
    }

    public unsafe static void PutString(string str, ulong x, ulong y, int fg, int bg)
    {
        fixed (char* s = str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                PutChar(s[i+5], x, y, fg, bg);
                x += PSF.font->Width+2;
            }
        }
    }

    public unsafe static void PutString(char* str, ulong x, ulong y, int fg, int bg)
    {
        for (int i = 0; i < Helper.GetLengthOfCharPtr(str); i++)
        {
            PutChar(str[i], x, y, fg, bg);
            x += PSF.font->Width+2;
        }
    }
    
}