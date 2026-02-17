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
ilc bin/Release/net9.0/linux-x64/xharp.dll \
    --systemmodule xharp \
    --out xharp.obj \
    --targetos linux \
    --targetarch x64 \
    --nativelib \
    --verbose
# Compiling plugs and c-bridges
clang -c startup.S -o startup.obj -target x86_64-unknown-linux -ffreestanding
clang -c src/Include/main.c -o c.obj -target x86_64-unknown-linux -ffreestanding
# Linking
ld.lld \
    -T linker.ld \
    -e _start \
    --build-id=none \
    -nostdlib \
    -o kernel.elf \
    c.obj \
    startup.obj xharp.obj
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