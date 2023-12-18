// <summary>Implements the exception extensions tests class</summary>

using System;
using System.Linq;
using NUnit.Framework;
using SHCodeExtensionsStandard.Extensions;

namespace SHCodeExtensionsStandard.Test.Extensions
{
    /// <summary>   (Unit Test Fixture) an exception extensions tests. </summary>
    [TestFixture]
    public class ExceptionExtensionsTests
    {
        /// <summary>   Message describing the inner exception. </summary>
        private readonly string innerExceptionMessage = "Test message for null reference exception.";

        /// <summary>   Message describing the outer exception. </summary>
        private readonly string outerExceptionMessage = "An error occured while processing the sub methods.";

        /// <summary>   The inner stack message prefix. </summary>
        private readonly string innerStackMessagePrefix = "Inner Stack Trace {0}";

        /// <summary>   The inner exception message prefix. </summary>
        private readonly string innerExceptionMessagePrefix = "Inner Exception {0}: ";

        /// <summary>
        ///     (Unit Test Method) gets all exception as string test nested exception list contains inner
        ///     message.
        /// </summary>
        [Test]
        public void GetAllExceptionAsStringTest_NestedException_ListContainsInnerMessage()
        {
            //// Arrange

            var expectedContent = this.innerExceptionMessage;

            //// Act

            var actualMessage = string.Empty;

            try
            {
                this.ThrowOuterException();
            }
            catch (Exception e)
            {
                actualMessage = string.Join("\r\n", e.GetAllExceptionAsString().ToList());
            }

            //// Assert

            Assert.IsTrue(actualMessage.Contains(expectedContent));
        }

        /// <summary>
        ///     (Unit Test Method) gets all exception messages as strings test nested exception message
        ///     contains expected text.
        /// </summary>
        [Test]
        public void GetAllExceptionMessagesAsStringsTest_NestedException_MessageContainsExpectedText()
        {
            //// Arrange

            var expectedContent = string.Format(this.innerExceptionMessagePrefix + this.innerExceptionMessage, 1);

            //// Act

            var actualMessage = string.Empty;

            try
            {
                this.ThrowOuterException();
            }
            catch (Exception e)
            {
                actualMessage = e.GetAllExceptionMessagesAsStrings();
            }

            //// Assert

            Assert.IsTrue(actualMessage.Contains(expectedContent));
        }

        /// <summary>
        ///     (Unit Test Method) gets all exceptions test nested exception match expected exception
        ///     count.
        /// </summary>
        [Test]
        public void GetAllExceptionsTest_NestedException_MatchExpectedExceptionCount()
        {
            //// Arrange

            var expectecExceptionCount = 2;

            //// Act

            var actualExceptionCount = 0;

            try
            {
                this.ThrowOuterException();
            }
            catch (Exception e)
            {
                actualExceptionCount = e.GetAllExceptions().Count();
            }

            //// Assert

            Assert.AreEqual(expectecExceptionCount, actualExceptionCount);
        }

        /// <summary>
        ///     (Unit Test Method) gets all exception stack messages test nested exception stack message
        ///     contains expected content.
        /// </summary>
        [Test]
        public void GetAllExceptionStackMessagesTest_NestedException_StackMessgeContainsExpectedContent()
        {
            //// Arrange

            var expectedContent = string.Format(this.innerStackMessagePrefix, 1);

            //// Act

            var actualMessage = string.Empty;

            try
            {
                this.ThrowOuterException();
            }
            catch (Exception e)
            {
                actualMessage = e.GetAllExceptionStackMessages();
            }

            //// Assert

            Assert.IsTrue(actualMessage.Contains(expectedContent));
        }

        /// <summary>   Throw outer exception. </summary>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        private void ThrowOuterException()
        {
            try
            {
                this.ThrowInnerException();
            }
            catch (Exception e)
            {
                throw new Exception(this.outerExceptionMessage, e);
            }
        }

        /// <summary>   Throw inner exception. </summary>
        /// <exception cref="NullReferenceException">   Thrown when a value was unexpectedly null. </exception>
        private void ThrowInnerException()
        {
            throw new NullReferenceException(this.innerExceptionMessage);
        }
    }
}