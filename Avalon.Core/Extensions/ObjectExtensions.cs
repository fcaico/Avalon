using System;
using System.Reflection;

namespace Avalon.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        public static void SetPropValue(this Object obj, String name, Object value)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return; }

                info.SetValue(obj, value, null);
            }
        }

// ReSharper disable UnusedTypeParameter
        public static void SetPropValue<T>(this Object obj, String name, Object value)
// ReSharper restore UnusedTypeParameter
        {
            SetPropValue(obj, name, value);
        }

        public static bool HasAttribute<TAttribute>(this object caller)
            where TAttribute : Attribute
        {
            return caller.GetType().IsDefined(typeof(TAttribute), true);
        }
    }
}
