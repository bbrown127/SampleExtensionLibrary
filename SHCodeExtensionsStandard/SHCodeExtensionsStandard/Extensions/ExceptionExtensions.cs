// <summary>Implements the exception extensions class</summary>

using System;
using System.Collections.Generic;
using System.Text;

namespace SHCodeExtensionsStandard.Extensions
{
    /// <summary>   An exception extensions. </summary>
    /// <remarks>   BBrowske, 9/12/2014. </remarks>
    public static class ExceptionExtensions
    {
        /// <summary>   Gets all exception types, including inner, as strings in this collection. </summary>
        /// <remarks>   BBrowske, 9/12/2014. </remarks>
        /// <param name="ex">   The ex to act on. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all exception as strings in this
        ///     collection.
        /// </returns>
        public static IEnumerable<string> GetAllExceptionAsString(this Exception ex)
        {
            var currentEx = ex;
            yield return currentEx.ToString();
            while (currentEx.InnerException != null)
            {
                currentEx = currentEx.InnerException;
                yield return currentEx.ToString();
            }
        }

        /// <summary>
        ///     An Exception extension method that gets all exception messages including, inner
        ///     exceptions, and resturns them as one string.
        /// </summary>
        /// <remarks>   BBrowske, 9/12/2014. </remarks>
        /// <param name="ex">   The ex to act on. </param>
        /// <returns>   all exception messages as a string. </returns>
        public static string GetAllExceptionMessagesAsStrings(this Exception ex)
        {
            var result = new StringBuilder();

            var currentEx = ex;
            result.AppendLine(currentEx.Message);

            var i = 0;

            while (currentEx.InnerException != null)
            {
                i++;
                currentEx = currentEx.InnerException;
                result.AppendLine(string.Format("\r\nInner Exception {0}: {1}", i, currentEx.Message));
            }

            return result.ToString();
        }

        /// <summary>   Gets all exceptions, including inner, in this collection. </summary>
        /// <remarks>   BBrowske, 9/12/2014. </remarks>
        /// <param name="ex">   The ex to act on. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all exceptions in this collection.
        /// </returns>
        public static IEnumerable<Exception> GetAllExceptions(this Exception ex)
        {
            var currentEx = ex;
            yield return currentEx;
            while (currentEx.InnerException != null)
            {
                currentEx = currentEx.InnerException;
                yield return currentEx;
            }
        }

        /// <summary>
        ///     An Exception extension method that gets all exception stack messages including inner
        ///     exception stack trace messages.
        /// </summary>
        /// <remarks>   BBrowske, 5/18/2015. </remarks>
        /// <param name="ex">   The ex to act on. </param>
        /// <returns>   all exception stack messages. </returns>
        public static string GetAllExceptionStackMessages(this Exception ex)
        {
            var result = new StringBuilder();

            var currentEx = ex;
            result.AppendLine(currentEx.StackTrace);

            var i = 0;

            while (currentEx.InnerException != null)
            {
                i++;
                currentEx = currentEx.InnerException;
                result.AppendLine(string.Format("Inner Stack Trace {0}: {1}", i, currentEx.StackTrace));
            }

            return result.ToString();
        }
    }
}