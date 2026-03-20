#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include "./limine.h"

__attribute__((used, section(".limine_requests")))
static volatile struct limine_framebuffer_request fb_req = {
    .id = LIMINE_FRAMEBUFFER_REQUEST_ID,
    .revision = 0
};

struct Fb {
    void* addr;
    uint64_t width;
    uint64_t height;
    uint64_t pitch;
    uint16_t bpp;
};

static struct Fb fb;

struct Fb*
GetFramebuffer(void)
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

static volatile struct limine_module_request module_request = {
    .id = LIMINE_MODULE_REQUEST_ID,
    .revision = 0
};

static void hcf(void) {
    for (;;) {
        asm ("hlt");
    }
}

struct File
{
    char* name;
    uint64_t revision;
    void* address;
    uint64_t size;
    char* path;
    char* string;
};

static struct File font;

struct File*
GetFont()
{
    if (!module_request.response) {hcf();}

    struct limine_module_response *resp = module_request.response;

    struct limine_file *file = resp->modules[0];

    font.name = "test font";
    font.revision = file->revision;
    font.address = file->address;
    font.size = file->size;
    font.path = file->path;
    font.string = file->string;

    return &font;
}