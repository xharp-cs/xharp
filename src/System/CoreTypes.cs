using System;
namespace System
{
    public class Object
    {
        public Object() { }

        ~Object() { }
        
        public virtual Type GetType() => null;
        public virtual bool Equals(object obj) { return this == obj; }
        public static bool Equals(object objA, object objB)
        {
            if (objA == objB) { return true; }
            if (objA == null || objB == null) { return false; }
            return objA.Equals(objB);
        }
        public virtual int GetHashCode() => 42; 
    }

    public class Exception : Object
    {
        public Exception(){}
        ~Exception() { }
    }
    
    public abstract class Type : Reflection.MemberInfo, Reflection.IReflect
    {
        public virtual Type BaseType { get { return null; } }
        public virtual bool IsSubclassOf(Type c)
        {
            Type p = this;
            if (p == c)
                return false;
            while (p != null)
            {
                if (p == c)
                    return true;
                p = p.BaseType;
            }
            return false;
        }
        public static Type GetTypeFromHandle(RuntimeTypeHandle handle) { return null; }
        public static Type GetType(string typeName){return null;}
    }

    public class Delegate : Object 
    { 
        ~Delegate() { }
    }

    public class ValueType : Object 
    { 
        ~ValueType() { }
    }
    
    public class Enum : ValueType { }
    public struct Boolean { }
    public struct Void { }

    public readonly struct Byte { }
    public readonly struct Char { }

    public abstract class Array : Object
    {
        public Array() : base() {}
        public int Length { get { return _length; } }
        private int _length;
    }

    public class String
    {
        public String() { }
        public int Length { get; }
    }
    
    public interface IDisposable { void Dispose(); }

    namespace System.Runtime.Serialization { }

    namespace System.Runtime.InteropServices
    {
        public enum CallingConvention { Cdecl = 2, Winapi = 1, StdCall = 3, ThisCall = 4, FastCall = 5 }
        public sealed class UnmanagedFunctionPointerAttribute : Attribute { public UnmanagedFunctionPointerAttribute(CallingConvention callingConvention) { } }
        public static class Marshal { public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t) => throw null; }
    }
}