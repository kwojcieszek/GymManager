using System;
using System.Linq;
using System.Reflection;

namespace GymManager.Common.Extensions
{
    public static class PropertyInfoExtensions
    {
        public static TValue GetAttributValue<TAttribute, TValue>(this PropertyInfo prop,
            Func<TAttribute, TValue> value)
            where TAttribute : Attribute
        {
            if (prop.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att)
            {
                return value(att);
            }

            return default;
        }
    }
}