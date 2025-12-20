namespace System
{
    public static class GC { }
    public sealed class SuppressFinalizeAttribute : Attribute { }
    public ref struct Span<T> { }
    public ref struct ReadOnlySpan<T> { }

    public interface IEquatable<T> { bool Equals(T other); }

    public unsafe partial struct RuntimeTypeHandle
    {
        internal nint m_type;

        public RuntimeTypeHandle()
        {
            m_type = 0;
        }

        public IntPtr Value => (IntPtr)m_type;

        public bool IsNull => m_type == 0;

        public override bool Equals(object obj)
        {
            if (obj is RuntimeTypeHandle other)
            {
                return m_type == other.m_type;
            }
            return false;
        }

        public override int GetHashCode(){return m_type.GetHashCode();}
    }

    public static class Activator { }
}

namespace System.Collections
{
    public interface IEnumerable { IEnumerator GetEnumerator(); }

    public interface IEnumerator
    {
        object Current { get; }
        bool MoveNext();
        void Reset();
    }
}

namespace System.Collections.Generic
{
    public interface IEnumerable<T> : Collections.IEnumerable { }
    public interface ICollection<T> : IEnumerable<T> { }
    public interface IList<T> : ICollection<T> { }
}

namespace System.Threading { public static class Interlocked { } }
namespace System.Runtime.Serialization { public interface ISerializable { } }