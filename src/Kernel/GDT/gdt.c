#include <stdint.h> 
struct GDTR 
{ 
    uint16_t limit; 
    uint64_t base; 
} __attribute__((packed)); 

static struct GDTR gdtr;

void LoadGdt(uint16_t limit, uint64_t base) 
{ 
    gdtr.limit = limit;
    gdtr.base = base;

    asm("lgdt %0" : : "m"(gdtr));
}