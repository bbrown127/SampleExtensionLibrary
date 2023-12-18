// <summary>Implements the string extension tests class</summary>

using System;
using System.Collections.Generic;
using NUnit.Framework;
using SHCodeExtensionsStandard.Extensions;

namespace SHCodeExtensionsStandard.Test.Extensions
{
    /// <summary>   (Unit Test Fixture) a string extension tests. </summary>
    [TestFixture]
    public class StringExtensionTests
    {
        /// <summary>   Is numeric supply string value return is numeric. </summary>
        /// <param name="value">    The value. </param>
        /// <param name="result">   The result. </param>
        [TestCase("1000", true)]
        [TestCase("bird1000", false)]
        [TestCase("1,000.34", false)]
        [TestCase("1000.34", true)]
        public void IsNumeric_SupplyStringValue_ReturnIsNumeric(string value, bool result)
        {
            //// Arrange

            var expected = result;

            //// Act

            var actual = value.IsNumeric();

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a list test supply two value string return
        ///     list with two values.
        /// </summary>
        [Test]
        public void ToListTest_SupplyTwoValueString_ReturnListWithTwoValues()
        {
            //// Arrange

            var expected = new List<string>() { "item1", "item2" };

            //// Act

            var actual = "item1|item2".ToList("|");

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a list test supply empty string return null
        ///     result.
        /// </summary>
        [Test]
        public void ToListTest_SupplyEmptyString_ReturnNullResult()
        {
            //// Arrange

            List<string> expected = null;

            //// Act

            var actual = string.Empty.ToList("|");

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Clean number string test supply number string return expected number string.
        /// </summary>
        /// <param name="value">            The value. </param>
        /// <param name="expectedValue">    The expected value. </param>
        [TestCase("234.55", "234.55")]
        [TestCase("$234.55", "234.55")]
        [TestCase("$1,234.55", "1234.55")]
        [TestCase(" ", "")]
        public void CleanNumberStringTest_SupplyNumberString_ReturnExpectedNumberString(string value, string expectedValue)
        {
            //// Arrange

            //// Act

            var actual = value.CleanNumberString();

            //// Assert

            Assert.AreEqual(expectedValue, actual);
        }

        /// <summary>   Default value if empty test supply string return expected string. </summary>
        /// <param name="value">                The value. </param>
        /// <param name="considerBlankAsNull">  True to consider blank as null. </param>
        /// <param name="defaultValue">         The default value. </param>
        /// <param name="expectedValue">        The expected value. </param>
        [TestCase("234.55", false, "empty", "234.55")]
        [TestCase("234.55", true, "empty", "234.55")]
        [TestCase("  ", false, "empty", "  ")]
        [TestCase("  ", true, "empty", "empty")]
        [TestCase(null, false, "empty", "empty")]
        [TestCase(null, true, "empty", "empty")]
        public void DefaultValueIfEmptyTest_SupplyString_ReturnExpectedString(string value, bool considerBlankAsNull, string defaultValue, string expectedValue)
        {
            //// Arrange

            //// Act

            var actual = value.DefaultValueIfEmpty(defaultValue, considerBlankAsNull);

            //// Assert

            Assert.AreEqual(expectedValue, actual);
        }

        /// <summary>
        ///     Converts this object to a boolean test supply string value match test case result.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <param name="result">   The result. </param>
        [TestCase("true", true)]
        [TestCase("false", false)]
        [TestCase("bird", null)]
        [TestCase("0", false)]
        [TestCase("1", true)]
        [TestCase("9", null)]
        [TestCase("", null)]
        public void ToBooleanTest_SupplyStringValue_MatchTestCaseResult(string value, bool? result)
        {
            //// Arrange

            var expected = result;

            //// Act

            var actual = value.ToBoolean();

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Converts this object to an integer test supply string value match test case result.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <param name="result">   The result. </param>
        [TestCase("1000", 1000)]
        [TestCase("bird", null)]
        [TestCase("1,000", null)]
        [TestCase("", null)]
        public void ToIntegerTest_SupplyStringValue_MatchTestCaseResult(string value, int? result)
        {
            //// Arrange

            var expected = result;

            //// Act

            var actual = value.ToInteger();

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     Converts this object to a decimal test supply string value match test case result.
        /// </summary>
        /// <param name="value">    The value. </param>
        /// <param name="result">   The result. </param>
        [TestCase("1000.25", 1000.25)]
        [TestCase("bird", null)]
        [TestCase("1,000.25", 1000.25)]
        [TestCase("", null)]
        public void ToDecimalTest_SupplyStringValue_MatchTestCaseResult(string value, decimal? result)
        {
            //// Arrange

            var expected = result;

            //// Act

            var actual = value.ToDecimal();

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a date time test supply string value return
        ///     valid date time.
        /// </summary>
        [Test]
        public void ToDateTimeTest_SupplyStringValue_ReturnValidDateTime()
        {
            //// Arrange

            var expected = new DateTime(2016, 12, 15);

            //// Act

            var actual = "12/15/2016".ToDateTime();

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a date time test supply empty string value
        ///     return null.
        /// </summary>
        [Test]
        public void ToDateTimeTest_SupplyEmptyStringValue_ReturnNull()
        {
            //// Arrange

            var expected = (DateTime?)null;

            //// Act

            var actual = string.Empty.ToDateTime();

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a date time test supply invalid string value
        ///     return null.
        /// </summary>
        [Test]
        public void ToDateTimeTest_SupplyInvalidStringValue_ReturnNull()
        {
            //// Arrange

            var expected = (DateTime?)null;

            //// Act

            var actual = "12/15/sa".ToDateTime();

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>   Is null or empty test supply empty value true. </summary>
        [Test]
        public void IsNullOrEmptyTest_SupplyEmptyValue_True()
        {
            var argument = string.Empty;

            var actual = argument.IsNullOrEmpty();

            Assert.IsTrue(actual);
        }

        /// <summary>   Is null or empty test supply null value true. </summary>
        [Test]
        public void IsNullOrEmptyTest_SupplyNullValue_True()
        {
            string argument = null;

            var actual = argument.IsNullOrEmpty();

            Assert.IsTrue(actual);
        }

        /// <summary>   Is null or empty test supply string value false. </summary>
        [Test]
        public void IsNullOrEmptyTest_SupplyStringValue_False()
        {
            var argument = "     ";

            var actual = argument.IsNullOrEmpty();

            Assert.IsFalse(actual);
        }

        /// <summary>   Is null or white space test supply null string true. </summary>
        [Test]
        public void IsNullOrWhiteSpaceTest_SupplyNullString_True()
        {
            string argument = null;

            var actual = argument.IsNullOrWhiteSpace();

            Assert.IsTrue(actual);
        }

        /// <summary>   Is null or white space test supply string value false. </summary>
        [Test]
        public void IsNullOrWhiteSpaceTest_SupplyStringValue_False()
        {
            var argument = "foo";

            var actual = argument.IsNullOrWhiteSpace();

            Assert.IsFalse(actual);
        }

        /// <summary>   Is null or white space test supply white space string true. </summary>
        [Test]
        public void IsNullOrWhiteSpaceTest_SupplyWhiteSpaceString_True()
        {
            var argument = "     ";

            var actual = argument.IsNullOrWhiteSpace();

            Assert.IsTrue(actual);
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a safe string supply null string is empty
        ///     string.
        /// </summary>
        [Test]
        public void ToSafeString_SupplyNull_StringIsEmptyString()
        {
            object item = null;

            var expected = string.Empty;

            var actual = item.ToSafeString(string.Empty);

            Assert.True(actual.Equals(expected));
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a safe string test supply integer string
        ///     matches true.
        /// </summary>
        [Test]
        public void ToSafeStringTest_SupplyInteger_StringMatchesTrue()
        {
            object item = 6;

            var expected = "6";

            var actual = item.ToSafeString(string.Empty);

            Assert.True(actual.Equals(expected));
        }

        /// <summary>
        ///     (Unit Test Method) converts this object to a safe string test no default supply null
        ///     object is empty string.
        /// </summary>
        [Test]
        public void ToSafeStringTestNoDefault_SupplyNullObject_IsEmptyString()
        {
            object item = null;

            var expected = string.Empty;

            var actual = item.ToSafeString();

            Assert.True(actual.Equals(expected));
        }
    }
}