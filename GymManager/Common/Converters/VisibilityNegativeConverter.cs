using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    public class VisibilityNegativeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility v && v == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Visibility v && v == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            ;
        }
    }
}