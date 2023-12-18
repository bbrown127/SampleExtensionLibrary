using NUnit.Framework;
using SHCodeExtensionsStandard.Extensions;

namespace SHCodeExtensionsStandard.Test.Extensions
{
    [TestFixture()]
    public class EnumExtensionsTests
    {
        [TestCase(MyEnum.Val1, "Enum value 1")]
        [TestCase(MyEnum.Val2, "Enum value 2")]
        public void GetDescriptionTest_ProvideEnum_MatchResultDescription(MyEnum enumVal, string expectedResult)
        {
            
            // Arrange
            
            // Act

            var actualResult = enumVal.GetDescription();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    public enum MyEnum
  {
        [System.ComponentModel.Description("Enum value 1")]
        Val1,
        [System.ComponentModel.Description("Enum value 2")]
        Val2
    }

} 