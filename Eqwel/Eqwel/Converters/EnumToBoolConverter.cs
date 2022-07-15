using System;
using System.Globalization;
using Xamarin.Forms;

namespace Eqwel.Converters
{
    public class EnumToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = value as Enum;

            if (enumValue != null)
            { 
            
            }
            //if ((string)value == "russian")
            //{
            //    return true;
            //}

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
