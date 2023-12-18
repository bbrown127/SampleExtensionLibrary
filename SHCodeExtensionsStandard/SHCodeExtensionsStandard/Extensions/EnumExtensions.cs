using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SHCodeExtensionsStandard.Extensions
{
    /// <summary>
    /// Summary Extension relating to use with enumerator values
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>   An Enum extension method that gets a description attribute
        ///             Added to the enum element. You will need to import 
        ///             System.ComponentModel.DescriptionAttribute into the using
        ///             class containing the ENUM definition. Then you can use
        ///             the description attributes to display a friendly name
        ///             for the current enum.
        ///             
        ///             public enum MyEnum
        ///             {
        ///                 [Description("Enum value 1")]
        ///                 VAL_1,
        ///                 [Description("Enum value 2")]
        ///                 VAL_2
        ///             }
        ///             
        ///             Then using the extension like this:
        ///             
        ///             lblEnumVal.Text = MyEnum.VAL_2.GetDescription();
        ///             
        ///             Sets the label text to "Enum Value 2".
        ///             
        ///             
        ///             Author: Brent Browske
        ///             Date: 03/01/2021
        ///             </summary>
        /// 
        /// <param name="value">    The value to act on. </param>
        /// <returns>   The description. </returns>
        public static string GetDescription(this Enum value)
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(
                value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(x => x.GetValue(null).Equals(value)),
                typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        }
    }
}