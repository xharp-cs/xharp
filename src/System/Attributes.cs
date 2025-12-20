using System;
using System.Reflection;

namespace System
{
    public class Attribute : Object
    {
        protected Attribute() { }

        public override bool Equals(object obj) { return base.Equals(obj); }
        public override int GetHashCode() { return base.GetHashCode(); }
        public virtual object TypeId => this;

        public static Attribute[] GetCustomAttributes(Reflection.Assembly element, Type attributeType, bool inherit)
        {
            if(element == null || attributeType == null) { return null; }

            if (!attributeType.IsSubclassOf(typeof(Attribute)) && attributeType != typeof(Attribute))
                return null;

            return (Attribute[])element.GetCustomAttributes(attributeType, inherit);
        }
        
        public static Attribute GetCustomAttribute(Assembly element, Type attributeType)
        {
            return GetCustomAttribute(element, attributeType, true);
        }

        public static Attribute GetCustomAttribute(Assembly element, Type attributeType, bool inherit)
        {
            Attribute[] attrib = GetCustomAttributes(element, attributeType, inherit);

            if (attrib == null || attrib.Length == 0)
                return null;

            Attribute match = attrib[0];
            if (attrib.Length == 1)
                return match;

            throw new Exception();
        }
        
        ~Attribute() { }
    }

    [AttributeUsage(AttributeTargets.Enum, Inherited = false)]
    public class FlagsAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public sealed class AttributeUsageAttribute : Attribute
    {
        public AttributeUsageAttribute(AttributeTargets validOn) { ValidOn = validOn; }
        public AttributeTargets ValidOn { get; }
        public bool Inherited { get; set; }
        public bool AllowMultiple { get; set; }
        public override object TypeId => null;
    }

    [Flags]
    public enum AttributeTargets
    {
        Assembly = 1,
        Module = 2,
        Class = 4,
        Struct = 8,
        Enum = 16,
        Constructor = 32,
        Method = 64,
        Property = 128,
        Field = 256,
        Event = 512,
        Interface = 1024,
        Parameter = 2048,
        Delegate = 4096,
        ReturnValue = 8192,
        GenericParameter = 16384,
        All = 32767
    }

    public abstract class MulticastDelegate : Delegate { }
}