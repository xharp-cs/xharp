using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Utils
{
    class ASM
    {
        [DoesNotReturn]
        [DllImport("*", EntryPoint = "Hcf")]
        public static extern void Hcf();
    }
}