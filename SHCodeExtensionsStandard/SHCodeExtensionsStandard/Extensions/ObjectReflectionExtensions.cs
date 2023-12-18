// <summary>Implements the object reflection extensions class</summary>

using System;
using System.Reflection;

namespace SHCodeExtensionsStandard.Extensions
{
    /// <summary>   An object reflection extensions. </summary>
    public static class ObjectReflectionExtensions
    {
        /// <summary>   An object extension method that gets property value. </summary>
        /// <param name="obj">  The obj to act on. </param>
        /// <param name="name"> The name. </param>
        /// <returns>   The property value. </returns>
        public static object GetPropValue(this object obj, string name)
        {
            foreach (string part in name.Split('.'))
            {
                if (obj == null)
                {
                    throw new NullReferenceException("Could not get property value because calling object is null.");
                }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);

                if (info == null)
                {
                    return null;
                }

                obj = info.GetValue(obj, null);
            }

            return obj;
        }

        /// <summary>   An object extension method that gets property value. </summary>
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="obj">  The obj to act on. </param>
        /// <param name="name"> The name. </param>
        /// <returns>   The property value. </returns>
        public static T GetPropValue<T>(this object obj, string name)
        {
            object retval = GetPropValue(obj, name);
            if (retval == null)
            {
                return default(T);
            }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }

        /// <summary>   An object extension method that gets a property. </summary>
        /// <param name="obj">  The obj to act on. </param>
        /// <param name="name"> The name. </param>
        /// <returns>   The property. </returns>
        public static PropertyInfo GetProperty(this object obj, string name)
        {
            PropertyInfo result = null;

            foreach (string part in name.Split('.'))
            {
                if (obj == null)
                {
                    return null;
                }

                Type type = obj.GetType();
                result = type.GetProperty(part);
            }

            return result;
        }
    }
}
