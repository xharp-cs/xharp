using System;
using LimineBootloader;
using System.Runtime.InteropServices;

namespace Utils
{
    unsafe class PSF
    {
        public unsafe static Limine.File* fontFile;
        public unsafe static PSF2* font;
        public static uint GlyphCount;
        public static uint GlyphSize;
        public unsafe static byte* GlyphBase;

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PSF2
        {
            public UInt32 Magic;
            public UInt32 Version;
            public UInt32 HeaderSize;
            public UInt32 Flags;
            public UInt32 NumGlyph;
            public UInt32 BytesPerGlyph;
            public UInt32 Height;
            public UInt32 Width;
        }

        public static unsafe void Init()
        {
            fontFile = Limine.GetFont();
            font = (PSF2*)fontFile->Address;

            if (font->Magic != 0x864AB572)
                ASM.Hcf();

            if (font->Flags == 0)
            {
                GlyphBase = null;
                return;
            }

            GlyphCount = font->NumGlyph;
            GlyphSize = font->BytesPerGlyph;
            GlyphBase = (byte*)fontFile->Address + font->HeaderSize;
        }

        public static unsafe byte* GetGlyph(int c)  
        {
            c -= 32; // Font offset

            if (c < 0 || c >= GlyphCount)
                return null;

            return GlyphBase + c * GlyphSize;
        }

    }
}
