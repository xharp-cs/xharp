# Xharp - simple C# kernel
### **Status**: *early active development*
## About
Xharp is not a *standart* project. Feature of this projects is C# like a *primary language* for bare metal programming.
It works using a [NativeAOT technology](https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/).

The compilation process goes like this:

    --------> c# ----> dotnet build -> ilc -> ld.lld -> xorisso -> output
    source -> plugs -> clang --------> ^
    code---> c-bridges ^

 Using this complicated way we can get c# in bare metal but not without an additional support like c-bridges that helps c# to *'speaks'* with [limine bootloader](https://codeberg.org/Limine/Limine) and asm that helps to not fail at start.

## Build dependecies
- [.Net](https://dotnet.microsoft.com):  
    - minimum: >= 5  ([5](https://dotnet.microsoft.com/download/dotnet/5.0),
[6](https://dotnet.microsoft.com/download/dotnet/6.0),
[7](https://dotnet.microsoft.com/download/dotnet/7.0),
[8](https://dotnet.microsoft.com/download/dotnet/8.0))
    - recomended: >= 9 ([9](https://dotnet.microsoft.com/download/dotnet/9.0), 
[10](https://dotnet.microsoft.com/download/dotnet/10.0))

- [Clang](https://clang.llvm.org)
- [ld.lld](https://lld.llvm.org/)
- [Xorisso](https://www.gnu.org/software/xorriso/)
- [Git](https://git-scm.com/)
- *Optional:* [QEMU](https://www.qemu.org/)

## Building&Compiling
- First run **. ./setup**. This install limine and creates dir structur.
- Second run **. ./build.sh**. This build and compile kernel. Output **.iso** you can find in **'out'** dir.

## Running
- QEMU(Recommended)
    - Run: `qemu-system-x86_64 kernel.iso`