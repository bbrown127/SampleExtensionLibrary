// <summary>Implements the argument parser class</summary>

using System;
using System.Collections;

namespace SHCodeExtensionsStandard.Helpers
{
    /// <summary>   An argument parser. </summary>
    public class ArgumentParser
    {
        /// <summary>
        ///     Parses the specified args. Parameters/Arguments should be in pairs of values with an
        ///     equal (=) sign\r\n Example:\r\n \r\n
        ///       (process name) -d=2010-09-10 -t -n="Brent Brown".
        /// </summary>
        /// <param name="args"> The args to process. </param>
        /// <returns>   Hashtable with keys as argument property and value as argument value. </returns>
        public static Hashtable Parse(string[] args)
        {
            var argTable = new Hashtable();

            foreach (var s in args)
            {
                if ((s.StartsWith("-") || s.StartsWith("/")) && !s.Substring(0, 2).Contains("?"))
                {
                    // Strip off - or /
                    var key = s.Substring(1, s.Length - 1);
                    string argumentValue;
                    if (!s.Contains("="))
                    {
                        argumentValue = "true";
                    }
                    else
                    {
                        // split argument on equals sign (=)
                        var keyValue = key.Split('=');

                        // set the key value
                        key = keyValue[0];

                        argumentValue = keyValue[1];

                        char[] charsToTrim = { '\u0022', '\u0027' };

                        // strip double quotes or single quotes off both ends
                        argumentValue = argumentValue.Trim(charsToTrim);
                    }

                    argTable.Add(key, argumentValue);
                }
                else if (s.Contains("?"))
                {
                    argTable.Add("?", "true");
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            @"Supplied argument '{0}' is invalid. Please use '-?' to see available parameters and syntax.",
                            s));
                }
            }

            // return the hashtable with the command line arguments in it.
            return argTable;
        }
    }
}