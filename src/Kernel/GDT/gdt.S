.section .text
.global FlushGdt

FlushGdt:
    push 0x08

    lea rax, [rip + ReloadCS]
    push rax

    retfq

ReloadCS:
    mov ax, 0x10
    mov ds, ax
    mov es, ax
    mov fs, ax
    mov gs, ax
    mov ss, ax

    ret