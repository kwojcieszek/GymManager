using System;
using System.Globalization;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    [ValueConversion(typeof(string), typeof(string))]
    public class CaseUpperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString().ToUpper();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString().ToUpper();
        }
    }
}