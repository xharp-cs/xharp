namespace System.Runtime.CompilerServices
{
    public sealed class UnmanagedCallersOnlyAttribute : Attribute { public string EntryPoint; }
    public static class RuntimeHelpers
    {
        public static void InitializeArray(Array array, IntPtr fldHandle) { }
        public static int OffsetToStringData => 2;
        public static void RunClassConstructor(RuntimeTypeHandle type) { }
    }

    public class CallConvCdecl : Object { }
    public class CallConvStdcall : Object {}
    public enum MethodImplOptions : short
    {
        AggressiveInlining = 256,
        InternalCall = 4096,
    }

    public sealed class MethodImplAttribute : Attribute
    { 
        public MethodImplAttribute(MethodImplOptions value) { }
        public MethodImplAttribute(short value) { } 
    }

    [AttributeUsage(AttributeTargets.Struct)]
    public sealed class IsByRefLikeAttribute : Attribute { }

    public sealed class IsUnmanagedAttribute : Attribute { }

    public static class Unsafe 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TTo As<TFrom, TTo>(ref TFrom source) => 
            ref Runtime.CompilerServices.Unsafe.As<TFrom, TTo>(ref source);
    }
}