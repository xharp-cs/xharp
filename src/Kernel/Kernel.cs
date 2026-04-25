using System;
using Utils;
class Kernel
{
    public static void KError(String msg)
    {
        Console.WriteLine(msg, 0xfc0303);
        ASM.Hcf();
    }
}
