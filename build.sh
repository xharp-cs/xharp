# Building with dotnet
dotnet clean
dotnet build -c Release

# Exporting ILC
ILC_PATH=$(find "$HOME/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler" -type d -name "tools" 2>/dev/null | sort -V | tail -n 1)

if [ -n "$ILC_PATH" ]; then
    ILC_VERSION=$(basename "$(dirname "$ILC_PATH")")
    
    export PATH="$ILC_PATH:$PATH"
    
    echo "Found ILCompiler version: $ILC_VERSION"
else
    echo "Warning: ILCompiler not found in ~/.nuget/packages"
fi

# Compiling 
ilc bin/Release/net10.0/linux-x64/xharp.dll \
    --systemmodule xharp \
    --out xharp.obj \
    --targetos linux \
    --targetarch x64 \
    --nativelib \
    --verbose
# Compiling plugs and c-bridges
clang -c src/Limine/limine.c -o tmp/limine.obj -target x86_64-unknown-linux -ffreestanding
clang -c src/Utils/IO/io.c -o tmp/io.obj -target x86_64-unknown-linux -ffreestanding
clang -c src/Kernel/GDT/gdt.c -o tmp/gdtc.obj -target x86_64-unknown-linux -ffreestanding

clang -c src/startup.S -o tmp/startup.obj -target x86_64-unknown-linux -ffreestanding -masm=intel
clang -c src/Utils/ASM/plug.S -o tmp/plug.obj -target x86_64-unknown-linux -ffreestanding -masm=intel
clang -c src/Kernel/GDT/gdt.S -o tmp/gdt.obj -target x86_64-unknown-linux -ffreestanding -masm=intel

mv xharp.obj tmp/xharp.obj

# Linking
ld.lld \
    -T linker.ld \
    -e _start \
    --build-id=none \
    -nostdlib \
    -o kernel.elf \
    tmp/limine.obj tmp/startup.obj tmp/plug.obj tmp/io.obj tmp/gdtc.obj tmp/xharp.obj tmp/gdt.obj
# Moving to iso_root dir
mv kernel.elf iso_root/boot/kernel.elf
# Making .iso
xorriso -as mkisofs -R -r -J -b boot/limine/limine-bios-cd.bin \
        -no-emul-boot -boot-load-size 4 -boot-info-table -hfsplus \
        -apm-block-size 2048 --efi-boot boot/limine/limine-uefi-cd.bin \
        -efi-boot-part --efi-boot-image --protective-msdos-label \
        iso_root -o kernel.iso
./limine/limine bios-install kernel.iso

mv kernel.iso out/kernel.iso