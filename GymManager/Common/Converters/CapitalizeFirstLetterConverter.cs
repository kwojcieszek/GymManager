using System;
using System.Globalization;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class CapitalizeFirstLetterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // this will be called after getting the value from your backing property
            // and before displaying it in the textbox, so we just pass it as-is
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // this will be called after the textbox loses focus (in this case) and
            // before its value is passed to the property setter, so we make our
            // change here
            if(value is string v && v.Length > 0)
            {
                var castValue = (string)value;

                return char.ToUpper(castValue[0]) + castValue.Substring(1);
            }

            return value;
        }
    }
}