using System;
using System.Globalization;
using System.Windows.Data;

namespace GymManager.Common.Converters;

public class IntToHourStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is int v ? EntityMethodsHelper.GetHourFromMinutes(v) : string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return null;
    }
}