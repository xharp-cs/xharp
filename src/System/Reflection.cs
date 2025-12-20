namespace System.Reflection
{
    public interface ICustomAttributeProvider { }
    public interface ICustomTypeProvider { }
    public interface IReflect { }
    public interface IReflectableType { }

    public struct CustomAttributeNamedArgument { }
    public readonly struct CustomAttributeTypedArgument : IEquatable<CustomAttributeTypedArgument>
    {
        private readonly Type _argumentType;
        private readonly Object _value;

        public bool Equals(CustomAttributeTypedArgument other)
        {
            return _argumentType == other._argumentType &&
                   _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (obj is CustomAttributeTypedArgument other) { return Equals(other); }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                if (_argumentType != null) { hash = (hash * 31) + _argumentType.GetHashCode(); }
                if (_value != null) { hash = (hash * 31) + _value.GetHashCode(); }
                return hash;
            }
        }
    }

    public struct InterfaceMapping { }
    public readonly struct ParameterModifier { }
    public abstract class Assembly : ICustomAttributeProvider, Runtime.Serialization.ISerializable { public virtual object[] GetCustomAttributes(Type attributeType, bool inherit) { return null; } }

    public abstract class MemberInfo : Object, ICustomAttributeProvider {}
}