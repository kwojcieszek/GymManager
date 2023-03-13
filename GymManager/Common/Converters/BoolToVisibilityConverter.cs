﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool v && v ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool v ? !v : null;
        }
    }
}