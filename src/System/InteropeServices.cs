namespace System.Runtime.InteropServices
{
    [AttributeUsage(AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
    public sealed class UnmanagedFunctionPointerAttribute : Attribute
    {
        public UnmanagedFunctionPointerAttribute(CallingConvention callingConvention)
        {
            CallingConvention = callingConvention;
        }

        public CallingConvention CallingConvention { get; }

        public bool BestFitMapping;
        public bool SetLastError;
        public bool ThrowOnUnmappableChar;
        public CharSet CharSet;
    }

    public enum CallingConvention
    {
        Cdecl = 2,
        FastCall = 5,
        StdCall = 3,
        ThisCall = 4,
        Winapi = 1
    }

    public enum CharSet
    {
        Ansi = 2,
        Auto = 4,
        None = 1,
        Unicode = 3
    }

    public abstract class CriticalHandle : IDisposable
    {
        protected CriticalHandle(IntPtr invalidHandleValue) { }
        public void Dispose() { }
        protected abstract bool ReleaseHandle();
    }

    public abstract class SafeHandle : CriticalHandle
    {
        protected SafeHandle(IntPtr invalidHandleValue) : base(invalidHandleValue) { }
        public override int GetHashCode() { return 0; }
        public override bool Equals(object obj) { return false; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class UnmanagedCallersOnlyAttribute : Attribute
    {
        public string EntryPoint;
        public Type[] CallConvs;
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public sealed class DllImportAttribute : Attribute
    {
        public DllImportAttribute(string dllName)
        {
            Value = dllName;
        }

        public string Value { get; }

        public string EntryPoint;
        public CharSet CharSet;
        public bool SetLastError;
        public bool ExactSpelling;
        public CallingConvention CallingConvention;
        public bool BestFitMapping;
        public bool PreserveSig;
        public bool ThrowOnUnmappableChar;
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class StructLayoutAttribute : Attribute
    {
        public StructLayoutAttribute(LayoutKind layoutKind)
        {
            Value = layoutKind;
        }

        public StructLayoutAttribute(short layoutKind)
        {
            Value = (LayoutKind)layoutKind;
        }

        public LayoutKind Value { get; }

        public int Pack;
        public int Size;
        public CharSet CharSet;
    }

    public enum LayoutKind
    {
        Auto = 3,
        Explicit = 2,
        Sequential = 0
    }
}