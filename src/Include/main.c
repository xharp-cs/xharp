#include <stdint.h>
#include <stddef.h>
#include <stdbool.h>
#include <limine.h>

void hcf(void) {
    for (;;) {
        asm ("hlt");
    }
}