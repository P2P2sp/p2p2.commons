using System;
using System.Linq;

namespace P2P2.Commons
{
    public static class EnumHelper
    {
        public static TAttribute GetAttribute<TType, TAttribute>(TType value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name) // I prefer to get attributes this way
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        public static bool IsNullableType(this Type type)
        {
            return
                type.IsGenericType &&
                type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}