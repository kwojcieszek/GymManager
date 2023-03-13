using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    public class NullToVisibilityNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}