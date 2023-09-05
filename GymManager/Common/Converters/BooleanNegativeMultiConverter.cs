using System;
using System.Globalization;
using System.Windows.Data;

namespace GymManager.Common.Converters
{
    public class BooleanNegativeMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var result = false;

            foreach(var value in values)
            {
                if(value is bool v)
                {
                    result = result ^ v;
                }
            }

            return !result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("BooleanAndConverter is a OneWay converter.");
        }
    }
}