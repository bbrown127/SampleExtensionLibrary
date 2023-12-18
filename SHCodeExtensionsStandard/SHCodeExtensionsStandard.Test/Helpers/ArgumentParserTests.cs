// <summary>Implements the argument parser tests class</summary>

// ReSharper disable InconsistentNaming

using System;
using NUnit.Framework;
using SHCodeExtensionsStandard.Helpers;

namespace SHCodeExtensionsStandard.Test.Helpers
{
    /// <summary>   (Unit Test Fixture) an argument parser tests. </summary>
    [TestFixture]
    public class ArgumentParserTests
    {
        /// <summary>   (Unit Test Method) parse test supply array return value of key. </summary>
        [Test]
        public void ParseTest_SupplyArray_ReturnValueOfKey()
        {
            //// Arrange

            var argumentArray = new[] { "-i=500", "-email=\"BBrowske@livingdirect.com\"", "-userName=BBrowske" };
            var expected = "500";

            //// Act

            var actual = ArgumentParser.Parse(argumentArray)["i"];

            //// Assert
            
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) parse test supply array with one argument quoted return value of
        ///     key.
        /// </summary>
        [Test]
        public void ParseTest_SupplyArrayWithOneArgumentQuoted_ReturnValueOfKey()
        {
            //// Arrange

            var argumentArray = new[] { "-i=500", "-email=\"BBrowske@livingdirect.com\"", "/userName=BBrowske" };
            var expected = "BBrowske@livingdirect.com";

            //// Act

            var actual = ArgumentParser.Parse(argumentArray)["email"];

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) parse test supply array with one argument uses slash return value of
        ///     key.
        /// </summary>
        [Test]
        public void ParseTest_SupplyArrayWithOneArgumentUsesSlash_ReturnValueOfKey()
        {
            //// Arrange

            var argumentArray = new[] { "-i=500", "-email=\"BBrowske@livingdirect.com\"", "/userName=BBrowske" };
            var expected = "BBrowske";

            //// Act

            var actual = ArgumentParser.Parse(argumentArray)["userName"];

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) parse test supply array with one character flag return value of
        ///     true.
        /// </summary>
        [Test]
        public void ParseTest_SupplyArrayWithOneCharacterFlag_ReturnValueOfTrue()
        {
            //// Arrange

            var argumentArray = new[] { "-i=500", "-t", "-email=\"BBrowske@livingdirect.com\"", "/userName=BBrowske" };
            var expected = "true";

            //// Act

            var actual = ArgumentParser.Parse(argumentArray)["t"];

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) parse test supply array with question mark return value question mark
        ///     value true.
        /// </summary>
        [Test]
        public void ParseTest_SupplyArrayWithQuestionMark_ReturnValueQuestionMarkValueTrue()
        {
            //// Arrange

            var argumentArray = new[] { "-i=500", "?" };
            var expected = "true";

            //// Act

            var actual = ArgumentParser.Parse(argumentArray)["?"];

            //// Assert

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///     (Unit Test Method) parse test supply array invalid formatted argument throw argument
        ///     exception.
        /// </summary>
        [Test]
        public void ParseTest_SupplyArrayInvalidFormattedArgument_ThrowArgumentException()
        {
            //// Arrange

            var argumentArray = new[] { "-i=500", "?", "t" };

            //// Act

            //// Assert

            Assert.Throws<ArgumentException>(() => { ArgumentParser.Parse(argumentArray); });
        }
    }
}