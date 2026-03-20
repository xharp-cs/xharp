using System;
using LimineBootloader;

namespace Utils
{
    unsafe class Graphics
    {
        public static Limine.Framebuffer* fb_ptr;
        static uint* fb;

        public static void Init()
        {
            Limine.Framebuffer* framebuffer = Limine.GetFramebuffer();
            if (framebuffer == null)
                ASM.Hcf();

            fb_ptr = framebuffer;
            fb = (uint*)framebuffer->Address;
        }

        public static void PutPixel(ulong x, ulong y, int color)
        {
            if (x >= fb_ptr->Width || y >= fb_ptr->Height)
                return;

            fb[y * (fb_ptr->Pitch / 4) + x] = (uint)color;
        }

        public static void FillRect(ulong x, ulong y, ulong w, ulong h, int color)
        {
            for (ulong i = 0; i < w; i++) 
            {
                for (ulong j = 0; j < h; j++)
                {
                    if  (x >= fb_ptr->Width || y >= fb_ptr->Height){}
                    else fb[y * (fb_ptr->Pitch / 4) + x] = (uint)color;
                }
            }
        }

    }
}
