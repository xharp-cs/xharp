namespace System
{
    public readonly struct UInt16
    {
        private readonly ushort m_value;
        public const ushort MaxValue = (ushort)0xFFFF;
        public const ushort MinValue = 0;
    }
    public readonly struct UInt32
    {
        private readonly uint m_value;
        public const uint MaxValue = (uint)0xffffffff;
        public const uint MinValue = 0U;
    }
    public readonly struct UInt64
    {
        private readonly ulong m_value;
        public const ulong MaxValue = (ulong)0xffffffffffffffffL;
        public const ulong MinValue = 0x0;
    }
    public readonly struct UInt128 { internal const int Size = 16; }
    public readonly struct UIntPtr
    {
        private readonly nuint _value;
        public static readonly nuint Zero;

        public UIntPtr(uint value)
        {
            _value = value;
        }

        public unsafe UIntPtr(void* value)
        {
            _value = (nuint)value;
        }
    }
}