using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    public class EnumDisplayConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var myEnum = (Enum)value;
            var display = GetEnumDisplay(myEnum);
            return display;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Empty;
        }

        private string GetEnumDisplay(Enum enumObj)
        {
            var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            var attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return enumObj.ToString();
            }

            var attrib = attribArray[0] as DisplayAttribute;
            return attrib.Name;
        }
    }
}