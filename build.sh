dotnet clean
dotnet build -c Release

export PATH="$HOME/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler/9.0.8/tools:$PATH"

ilc bin/Release/net9.0/linux-x64/xharp.dll \
    --systemmodule xharp \
    --out xharp.obj \
    --targetos linux \
    --targetarch x64 \
    --singlemethodtypename Program \
    --singlemethodname KernelMain \
    --verbose

clang -c startup.S -o startup.obj -target x86_64-unknown-linux -ffreestanding
clang -c src/Include/main.c -o c.obj -target x86_64-unknown-linux -ffreestanding
ld.lld \
    -T linker.ld \
    -e _start \
    --build-id=none \
    -nostdlib \
    -o kernel.elf \
    c.obj \
    startup.obj xharp.obj

mv kernel.elf iso_root/boot/kernel.elf

xorriso -as mkisofs -R -r -J -b boot/limine/limine-bios-cd.bin \
        -no-emul-boot -boot-load-size 4 -boot-info-table -hfsplus \
        -apm-block-size 2048 --efi-boot boot/limine/limine-uefi-cd.bin \
        -efi-boot-part --efi-boot-image --protective-msdos-label \
        iso_root -o kernel.iso

./limine/limine bios-install kernel.iso