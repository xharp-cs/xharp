# Downloading&Compiling Limine
git clone https://codeberg.org/Limine/Limine.git limine --branch=v10.x-binary --depth=1
make -C limine


# Creating required dir structur
mkdir -p iso_root/boot
mkdir -p iso_root/boot/limine
cp -v limine.conf limine/limine-bios.sys limine/limine-bios-cd.bin \
      limine/limine-uefi-cd.bin iso_root/boot/limine/

mkdir -p iso_root/EFI/BOOT
cp -v limine/BOOTX64.EFI iso_root/EFI/BOOT/
cp -v limine/BOOTIA32.EFI iso_root/EFI/BOOT/

mkdir out