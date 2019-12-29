using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CounoGame.Shared.Extensions
{
    public static class CodeGuard
    {
        /// <summary>
        ///     Prüft ob eine IEnumerable NULL oder leer ist und wirft dementsprechend eine Exception.
        /// </summary>
        /// <typeparam name="T">Typ der Enumerable.</typeparam>
        /// <param name="collection">Die Enumerable die geprüft werden sollen.</param>
        /// <param name="parameterName">Der Name des Parameters über den die Enumerable reingegeben wurde.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static void ArgumentNotNullOrEmpty<T>(ICollection<T> collection, string parameterName)
        {
            if (collection == null || !collection.Any())
            {
                throw GetException(parameterName, collection);
            }
        }

        /// <summary>
        ///     Prüft ob eine IEnumerable NULL oder leer ist und wirft dementsprechend eine Exception.
        /// </summary>
        /// <typeparam name="T">Typ der Enumerable.</typeparam>
        /// <param name="collection">Die Enumerable die geprüft werden sollen.</param>
        /// <param name="parameterName">Der Name des Parameters über den die Enumerable reingegeben wurde.</param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="ArgumentException" />
        public static void ArgumentNotNullOrEmpty<T>(IReadOnlyCollection<T> collection, string parameterName)
        {
            if (collection == null || !collection.Any())
            {
                throw GetException(parameterName, collection);
            }
        }

        public static void ArgumentNotNullOrEmpty(string str, string parameterName)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw GetException(parameterName, str);
            }
        }

        public static void ArgumentZero(int argument, string argumentName)
        {
            if (argument == 0)
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static void ArgumentNotNull<T>(T argument, string argumentName)
        {
            if (!ReferenceEquals(argument, null))
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static void ArgumentNotNull(object argument, string argumentName)
        {
            if (!ReferenceEquals(argument, null))
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static void ArgumentNegative(double argument, string argumentName)
        {
            if (argument < 0.0)
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static void ArgumentNegative(float argument, string argumentName)
        {
            if (argument < 0f)
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static void ArgumentNegative(int argument, string argumentName)
        {
            if (argument < 0)
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static void ArgumentNonNegative(int value, string name)
        {
            if (value >= 0)
            {
                return;
            }

            throw GetException(name, value);
        }

        public static void ArgumentNonNegative(float value, string name)
        {
            if (value >= 0)
            {
                return;
            }

            throw GetException(name, value);
        }

        public static void ArgumentNonNegative(double value, string name)
        {
            if (value >= 0)
            {
                return;
            }

            throw GetException(name, value);
        }

        public static void ArgumentPositive(int value, string name)
        {
            if (value > 0)
            {
                return;
            }

            throw GetException(name, value);
        }

        public static void ArgumentPositive(float argument, string argumentName)
        {
            if (argument > 0f)
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static void ArgumentPositive(double argument, string argumentName)
        {
            if (argument > 0.0)
            {
                return;
            }

            throw GetException(argumentName, argument);
        }

        public static TValue ArgumentMatchType<TValue>(object value, string parameterName)
            where TValue : class
        {
            try
            {
                return (TValue) value;
            }
            catch (InvalidCastException e)
            {
                throw GetException(parameterName, value, e);
            }
        }

        public static void ArgumentMatch<TValue>(TValue value, string name, Func<TValue, bool> predicate)
        {
            if (!predicate(value))
            {
                throw GetException(name, value);
            }
        }

        public static void EnumIsDefinded(Type type, int value, string parameterName)
        {
            if (!Enum.IsDefined(type, value))
            {
                throw new InvalidEnumArgumentException(parameterName, value, type);
            }
        }

        private static Exception GetException(string propName, object val, Exception innerException = null)
        {
            if (ReferenceEquals(val, null))
            {
                return GetArgumentNullException(propName, innerException);
            }

            return GetArgumentException(propName, val, innerException);
        }

        private static ArgumentNullException GetArgumentNullException(string propName, Exception innerException = null)
        {
            return new ArgumentNullException(propName, innerException);
        }

        private static ArgumentException GetArgumentException(string propName, object val,
            Exception innerException = null)
        {
            return new ArgumentException(
                string.Format("'{0}' is not a valid value for '{1}'",
                    ReferenceEquals(val, string.Empty)
                        ? "String.Empty"
                        : ReferenceEquals(val, null)
                            ? "null"
                            : val.ToString(), propName), innerException);
        }
    }
}