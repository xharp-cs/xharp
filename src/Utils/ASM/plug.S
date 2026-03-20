.intel_syntax noprefix
.section .text
.global Hcf

Hcf:
    cli
    hlt
    jmp Hcf
