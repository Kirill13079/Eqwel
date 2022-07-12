using System;
using System.Globalization;
using Xamarin.Forms;

namespace Eqwel.Converters
{
    public class StringToBoolConverter : IValueConverter
    {
        public string Mode { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "russian")
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
