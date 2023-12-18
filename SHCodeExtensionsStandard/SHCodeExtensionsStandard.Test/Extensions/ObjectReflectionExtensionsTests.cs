// <summary>Implements the object reflection extensions tests class</summary>

using System;
using System.Reflection;
using NUnit.Framework;
using SHCodeExtensionsStandard.Extensions;

namespace SHCodeExtensionsStandard.Test.Extensions
{
    /// <summary>   (Unit Test Fixture) an object reflection extensions tests. </summary>
    [TestFixture]
    public class ObjectReflectionExtensionsTests
    {
        /// <summary>
        ///     (Unit Test Method) gets property value test supply object match property 1.
        /// </summary>
        [Test]
        public void GetPropValueTest_SupplyObject_MatchProperty1()
        {
            //// Arrange

            var myObject = new TestObject()
            {
                Property1 = "TestValue",
                Property2 = 100
            };

            var expectedValue = "TestValue";

            //// Act

            var actualValue = myObject.GetPropValue("Property1");

            //// Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        ///     (Unit Test Method) gets property value test supply test object match property 2.
        /// </summary>
        [Test]
        public void GetPropValueTest_SupplyTestObject_MatchProperty2()
        {
            //// Arrange

            var myObject = new TestObject()
            {
                Property1 = "TestValue",
                Property2 = 100
            };

            var expectedValue = 100;

            //// Act

            var actualValue = myObject.GetPropValue<int>("Property2");

            //// Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        ///     (Unit Test Method) gets property value test supply test object return default of type
        ///     integer.
        /// </summary>
        [Test]
        public void GetPropValueTest_SupplyTestObject_ReturnDefaultOfTypeInt()
        {
            //// Arrange

            var myObject = new TestObject()
            {
                Property1 = "TestValue",
                Property2 = 100
            };

            var expectedValue = 0;

            //// Act

            var actualValue = myObject.GetPropValue<int>("Property3");

            //// Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        ///     (Unit Test Method) gets property test supply test object return matching property
        ///     information.
        /// </summary>
        [Test]
        public void GetPropTest_SupplyTestObject_ReturnMatchingPropertyInfo()
        {
            //// Arrange

            var myObject = new TestObject()
            {
                Property1 = "TestValue",
                Property2 = 100
            };

            var type = myObject.GetType();
            var expectedValue = type.GetProperty("Property1");

            //// Act

            var actualValue = myObject.GetProperty("Property1");

            //// Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        ///     (Unit Test Method) gets property test supply null test object return null.
        /// </summary>
        [Test]
        public void GetPropTest_SupplyNullTestObject_ReturnNull()
        {
            //// Arrange

            TestObject myObject = null;

            var expectedValue = (PropertyInfo)null;

            //// Act

            var actualValue = myObject.GetProperty("Property1");

            //// Assert

            Assert.AreEqual(expectedValue, actualValue);
        }

        /// <summary>
        ///     (Unit Test Method) gets property value test supply null test object throw null reference
        ///     exception.
        /// </summary>
        [Test]
        public void GetPropValueTest_SupplyNullTestObject_ThrowNullReferenceException()
        {
            //// Arrange

            TestObject myObject = null;

            //// Act

            //// Assert

            Assert.Throws<NullReferenceException>(() => { myObject.GetPropValue<int>("Property1"); });
        }

        /// <summary>   (Unit Test Fixture) a test object. </summary>
        public class TestObject
        {
            /// <summary>   Gets or sets the property 1. </summary>
            /// <value> The property 1. </value>
            public string Property1 { get; set; }

            /// <summary>   Gets or sets the property 2. </summary>
            /// <value> The property 2. </value>
            public int Property2 { get; set; }
        }
    }
}