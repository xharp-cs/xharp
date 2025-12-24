#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include <limine.h>

__attribute__((used, section(".limine_requests")))
static volatile struct limine_framebuffer_request fb_req = {
    .id = LIMINE_FRAMEBUFFER_REQUEST,
    .revision = 0
};

struct fb_info {
    void* addr;
    uint64_t width;
    uint64_t height;
    uint64_t pitch;
    uint16_t bpp;
};

static struct fb_info fb;

struct fb_info*
xharp_Include_Limine__GetFramebuffer(void)
{
    if (!fb_req.response || fb_req.response->framebuffer_count < 1)
        return 0;

    struct limine_framebuffer* lfb = fb_req.response->framebuffers[0];

    fb.addr = lfb->address;
    fb.width = lfb->width;
    fb.height = lfb->height;
    fb.pitch = lfb->pitch;
    fb.bpp = lfb->bpp;

    return &fb;
}
__attribute__((noreturn))
void xharp_Include_ASM__hcf(void)
{
    for (;;) {
        asm volatile ("hlt");
    }
}