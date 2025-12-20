OUTPUT_FORMAT(elf64-x86-64)
ENTRY(_start)

KERNEL_VMA = 0xffffffff80000000;

PHDRS {
    limine_requests PT_LOAD;
    text PT_LOAD FLAGS(5);  /* RX */
    rodata PT_LOAD FLAGS(4); /* R */
    data PT_LOAD FLAGS(6);   /* RW */
}

SECTIONS {
    . = KERNEL_VMA;
    .limine_requests : ALIGN(0x1000) {
        KEEP(*(.limine_requests_start))
        KEEP(*(.limine_requests))
        KEEP(*(.limine_requests_end))
    } :limine_requests

    . = ALIGN(0x1000);
    .text : ALIGN(0x1000) {
        *(.text .text.*)
        *(.text$mn*)       /* C# / ILC methods */
        *(.ctors)
        *(.dtors)
        *(.xtext)
    } :text

    . = ALIGN(0x1000);
    .rodata : ALIGN(0x1000) {
        *(.rodata .rodata.*)
        *(.rdata .rdata.*)       /* ILC / MSVC */
        *(.pdata .pdata.*)
        *(.xdata .xdata.*)
    } :rodata

    .note.gnu.build-id : {
        *(.note.gnu.build-id)
    } :rodata

    . = ALIGN(0x1000);
    .data : ALIGN(0x1000) {
        *(.data .data.*)
        *(.tdata .tdata.*)
        *(.tbss .tbss.*)
        *(.managed .managed.*)
        *(.CRT .CRT*)
        *(.ctors)
        *(.dtors)
    } :data

    .bss : ALIGN(0x1000) {
        *(.bss .bss.*)
        *(COMMON)
    } :data

    /DISCARD/ : {
        *(.eh_frame*)
        *(.note .note.*)
        *(.comment)
        *(.debug*)
    }
}
