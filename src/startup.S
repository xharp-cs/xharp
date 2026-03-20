.intel_syntax noprefix

.section .text
.global _start

_start:
    mov rsp, 0x200010 

    mov rax, cr0
    and ax, 0xFFFB
    or  ax, 0x2
    mov cr0, rax

    mov rax, cr4
    or  eax, 3 << 9
    mov cr4, rax

    call xharp_Program__KernelMain

    
.hang:
    cli
    hlt
    jmp .hang

.global RhpReversePInvoke
RhpReversePInvoke:
    ret

.global RhpReversePInvokeReturn
RhpReversePInvokeReturn:
    ret 
    
.global RhpPInvoke
RhpPInvoke:
    ret

.global RhpPInvokeReturn
RhpPInvokeReturn:
    ret

.global RhpFallbackFailFast
RhpFallbackFailFast:
    ret

.global __security_cookie
__security_cookie:
    ret 

.global RhpNewArray
RhpNewArray:
    ret

.global RhpAssignRef
RhpAssignRef:
    ret

    
.global xharp_System_Runtime_CompilerServices_RuntimeHelpers__get_OffsetToStringData
.global IntPtr__ToPointer