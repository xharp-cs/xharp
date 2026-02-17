using System;
using Include;

namespace Utils
{
    unsafe class Graphics
    {
        static Limine.Framebuffer* fb_ptr;
        static uint* fb;
        public static void Init(Limine.Framebuffer* Framebuffer)
        {
            fb_ptr = Framebuffer;
            fb = (uint*)Framebuffer->Address;
        }

        public static void PutPixel(ulong x, ulong y, Int32 color)
        {
            if(x>fb_ptr->Width || y>fb_ptr->Height)
                fb[y * (fb_ptr->Pitch/4) + x] = (uint)color;
        }
    }
}