// <summary>Implements the string extension class</summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SHCodeExtensionsStandard.Extensions
{
    /// <summary>   A string extension. </summary>
    public static class StringExtension
    {
        /// <summary>
        ///     Values that represent RemainingCharacterTypes: Alpha, Numeric or AlphaNumeric.
        /// </summary>
        /// <remarks>   BBrowske, 4/3/2013. </remarks>
        public enum RemainingCharacterTypes
        {
            /// <summary>   An enum constant representing the alpha only option. </summary>
            AlphaOnly,

            /// <summary>   An enum constant representing the numeric only option. </summary>
            NumericOnly,

            /// <summary>   An enum constant representing the alpha and numeric only option. </summary>
            AlphaAndNumericOnly
        }

        /// <summary>   returns default value if string is null or empty or white spaces string. </summary>
        /// <remarks>   BBrowske, 1/27/2015. </remarks>
        /// <param name="str">                          The str to act on. </param>
        /// <param name="defaultValue">                 The default value. </param>
        /// <param name="considerWhiteSpaceIsEmpty">
        ///     (Optional) true if consider white space is empty.
        ///     Default: false.
        /// </param>
        /// <returns>   A string. </returns>
        /// <example>
        ///     <para>Source: http://extensionmethod.net/csharp/string/defaultifempty</para>
        ///     <code>
        ///                string str = null;
        ///     str.DefaultIfEmpty("I'm nil") // return "I'm nil"
        ///     
        ///     string str1 = string.Empty;
        ///     str1.DefaultIfEmpty("I'm Empty") // return "I'm Empty!"
        ///     
        ///     string str1 = "     ";
        ///     str1.DefaultIfEmpty("I'm WhiteSpaces strnig!", true) // return "I'm WhiteSpaces strnig!"
        ///                 </code>
        /// </example>
        public static string DefaultValueIfEmpty(
            this string str,
            string defaultValue,
            bool considerWhiteSpaceIsEmpty = false)
        {
            return (considerWhiteSpaceIsEmpty ? string.IsNullOrWhiteSpace(str) : string.IsNullOrEmpty(str))
                       ? defaultValue
                       : str;
        }

        /// <summary>   A string extension method that queries if a null or is empty. </summary>
        /// <param name="value">    The string to act on. </param>
        /// <returns>   true if the null or is empty, false if not. </returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>   A string extension method that query if 'value' is null or white space. </summary>
        /// <param name="value">    The string to act on. </param>
        /// <returns>   true if null or white space, false if not. </returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        ///     An object extension method that query if ToString 'value' of object is numeric.
        /// </summary>
        /// <remarks>   BBrowske, 9/9/2015. </remarks>
        /// <param name="value">    The value to act on. </param>
        /// <returns>   true if numeric, false if not or NULL. </returns>
        public static bool IsNumeric(this object value)
        {
            var regex = new Regex(@"^\d+\.?\d*$");
            var isNumeric = regex.IsMatch(value.ToSafeString(string.Empty));

            return isNumeric;
        }

        /// <summary>   A string extension method that converts a value to a boolean. </summary>
        /// <remarks>   BBrowske, 6/2/2014. </remarks>
        /// <param name="value">    The value to act on. </param>
        /// <returns>   value as a Boolean? </returns>
        public static bool? ToBoolean(this string value)
        {
            bool? result = null;
            var tempBool = false;
            byte tempByte = 9;

            if (string.IsNullOrWhiteSpace(value))
            {
                result = null;
            }
            else if (bool.TryParse(value, out tempBool))
            {
                result = tempBool;
            }
            else if (byte.TryParse(value, out tempByte))
            {
                switch (tempByte)
                {
                    case 0:
                        result = false;
                        break;

                    case 1:
                        result = true;
                        break;

                    default:
                        result = null;
                        break;
                }
            }

            return result;
        }

        /// <summary>
        ///     A string extension method that converts a value to a date time, but is very basic. Assums
        ///     english culture using DateTimeFormatInfo Class (see msdn). This can be extended if
        ///     greater flexibility is needed.
        /// </summary>
        /// <remarks>   BBrowske, 6/2/2014. </remarks>
        /// <param name="value">    The value to act on. </param>
        /// <returns>   value as a DateTime? </returns>
        public static DateTime? ToDateTime(this string value)
        {
            // This can be expanded upon to include formats in the future
            // we can use either this one method or include an additional parameter
            // for format. Or even allow for Regex entry if we want as a
            // format layout validator

            // you can throw an exception or return a default value here
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            DateTime d;

            // you could throw an exception or return a default value on failure
            if (!DateTime.TryParse(value, out d))
            {
                return null;
            }

            return d;
        }

        /// <summary>   A string extension method that converts a value to a decimal. </summary>
        /// <remarks>   BBrowske, 4/3/2013. </remarks>
        /// <param name="value">    The value to act on. </param>
        /// <returns>   value as a decimal? </returns>
        public static decimal? ToDecimal(this string value)
        {
            // you can throw an exception or return a default value here
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            decimal d;

            var cleanValue = value.CleanNumberString();

            // you could throw an exception or return a default value on failure
            if (!decimal.TryParse(cleanValue, out d))
            {
                return null;
            }

            return d;
        }

        /// <summary>   A string extension method that converts a value to a integer. </summary>
        /// <remarks>   BBrowske, 4/18/2014. </remarks>
        /// <param name="value">    The value to act on. </param>
        /// <returns>   value as a int? </returns>
        public static int? ToInteger(this string value)
        {
            // you can throw an exception or return a default value here
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            int d;

            var cleanValue = CleanNumberString(value);

            // you could throw an exception or return a default value on failure
            if (!int.TryParse(value, out d))
            {
                return null;
            }

            return d;
        }

        /// <summary>   A string extension method that converts this object to a list. </summary>
        /// <param name="value">        The value to act on. </param>
        /// <param name="separator">    The separator. </param>
        /// <returns>   The given data converted to a List&lt;string&gt; </returns>
        public static List<string> ToList(this string value, string separator)
        {
            if (string.IsNullOrWhiteSpace(separator) || string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            var list = new List<string>();

            if (!value.IsNullOrWhiteSpace())
            {
                string[] s = { separator };
                list = value.Split(s, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return list.ToList();
        }

        /// <summary>
        ///     An object extension method that convert this object into a string representation. Created
        ///     this to override ToString so it can try to handle null references and allow for a default
        ///     to be supplied in case it is null.
        /// </summary>
        /// <remarks>   BBrowske, 4/23/2015. </remarks>
        /// <param name="value">        The value to act on. </param>
        /// <param name="defaultValue"> The default value. </param>
        /// <returns>
        ///     A String that represents this object. <see cref="defaultValue" /> will be returned for
        ///     null reference objects or an empty string is no <see cref="defaultValue" /> is supplied.
        /// </returns>
        public static string ToSafeString(this object value, string defaultValue)
        {
            var result = defaultValue ?? string.Empty;

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return result;
            }

            return value.ToString();
        }

        /// <summary>
        ///     An object extension method that convert this object into a string representation. Created
        ///     this to override ToString so it can try to handle null references and allow for a default
        ///     to be supplied in case it is null.
        /// </summary>
        /// <remarks>   BBrowske, 4/23/2015. </remarks>
        /// <param name="value">    The value to act on. </param>
        /// <returns>
        ///     A String that represents this object. And empty string will be returned if object is null.
        /// </returns>
        public static string ToSafeString(this object value)
        {
            return value.ToSafeString(string.Empty);
        }

        /// <summary>
        ///     Removes commas, dollar signs, percent symbol, spaces, and dashes from numeric strings.
        /// </summary>
        /// <param name="value">    The string to act on. </param>
        /// <returns>   Perged string or empty string. </returns>
        public static string CleanNumberString(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            var tempStr = Regex.Replace(value, "[,$% ]*", string.Empty);

            return tempStr;
        }
    }
}