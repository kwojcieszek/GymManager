using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    public class StringToVisibilityNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string && string.IsNullOrEmpty((string)value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool ? !(bool)value : null;
        }
    }
}