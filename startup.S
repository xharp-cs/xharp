.section .text
.global _start

_start:
    mov $0x200000, %rsp 
    call xharp_Program__KernelMain
    jmp .hang
    
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

.global xharp_System_Runtime_CompilerServices_RuntimeHelpers__get_OffsetToStringData
.global IntPtr__ToPointer