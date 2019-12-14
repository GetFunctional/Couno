using System;
using System.Collections;
using System.Collections.Generic;

namespace Couno.Shared
{
    public static class ObjectExtensions
    {
        #region - Methoden oeffentlich -

        /// <summary>
        ///   Checks whether the 2 specified objects are equal. This method is better, simple because it also checks boxing so
        ///   2 integers with the same values that are boxed are equal.
        /// </summary>
        /// <param name = "object1">The first object.</param>
        /// <param name = "object2">The second object.</param>
        /// <returns><c>true</c> if the objects are equal; otherwise <c>false</c>.</returns>
        public static bool AreEqual(object object1, object object2)
        {
            var isObject1Null = object1 == null;
            var isObject2Null = object2 == null;

            if (isObject1Null && isObject2Null)
            {
                return true;
            }

            if (isObject1Null || isObject2Null)
            {
                return false;
            }

            if (ReferenceEquals(object1, object2))
            {
                return true;
            }

            var firstTagAsString = object1 as string;
            var secondTagAsString = object2 as string;

            if (firstTagAsString != null && secondTagAsString != null)
            {
                return string.Compare(firstTagAsString, secondTagAsString, StringComparison.Ordinal) == 0;
            }

            if (object1 == object2)
            {
                return true;
            }

            if (object1.Equals(object2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///   Checks whether the 2 specified objects are equal references. This method is better, simple because it also checks boxing so
        ///   2 integers with the same values that are boxed are equal.
        /// <para />
        ///   Two objects are considered equal if one of the following expressions returns true:
        /// <list type="bullet">
        ///   <item><description>Both values are <c>null</c>.</description></item>
        ///   <item><description>Both values have the same reference, checked by <see cref="object.ReferenceEquals"/>.</description></item>
        ///   <item><description>Both values are value types and have the same value.</description></item>
        ///   <item><description>Both values are string type and have the same value.</description></item>
        /// </list>
        /// </summary>
        /// <param name = "object1">The first object.</param>
        /// <param name = "object2">The second object.</param>
        /// <returns><c>true</c> if the objects are equal references; otherwise <c>false</c>.</returns>
        public static bool AreEqualReferences(object object1, object object2)
        {
            var isObject1Null = object1 == null;
            var isObject2Null = object2 == null;

            if (isObject1Null && isObject2Null)
            {
                return true;
            }

            if (isObject1Null || isObject2Null)
            {
                return false;
            }

            if (ReferenceEquals(object1, object2))
            {
                return true;
            }

            var object1Type = object1.GetType();
            var object2Type = object2.GetType();

            if (object1Type.IsValueType && object2Type.IsValueType)
            {
                return object1.Equals(object2);
            }

            var firstTagAsString = object1 as string;
            var secondTagAsString = object2 as string;

            if (firstTagAsString != null && secondTagAsString != null)
            {
                return string.Compare(firstTagAsString, secondTagAsString, StringComparison.Ordinal) == 0;
            }

            return false;
        }

        /// <summary>
        /// Determines whether the specified object is <c>null</c> or <c>DBNull.Value</c>.
        /// </summary>
        /// <param name="obj">The object to chec..</param>
        /// <returns>
        ///   <c>true</c> if the specified object is <c>null</c> or <c>DBNull.Value</c>; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNull(object obj)
        {
            if (obj == null)
            {
                return true;
            }

            if (obj == DBNull.Value)
            {
                return true;
            }

            return false;
        }

        public static void TrimStringFields<T>(this T obj) where T : class
        {
            foreach (var fieldInfo in typeof(T).GetFields())
            {
                var val = fieldInfo.GetValue(obj);
                if (!(val is string))
                {
                    continue;
                }

                fieldInfo.SetValue(obj, ((string)val).Trim());
            }
        }

        public static bool IsList(this object o)
        {
            if(o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        public static bool IsDictionary(this object o)
        {
            if(o == null) return false;
            return o is IDictionary &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
        }

        #endregion
    }
}