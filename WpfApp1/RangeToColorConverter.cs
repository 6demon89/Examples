using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp1
{
    public class RangeToColorConverter : IMultiValueConverter
    {
        public object Convert(
            object[] value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            Color result = new Color();
            if (value is null)
                return Brushes.Violet;
            try
            {
                result.G = ConvertStringToByte(value[0] as string);
                result.A = ConvertStringToByte(value[1] as string);
                result.R = ConvertStringToByte(value[2] as string);
                result.B = ConvertStringToByte(value.Last() as string);
                return new SolidColorBrush(result);
            }
            catch
            {
                return Brushes.GhostWhite;
            }
        }

        private byte ConvertStringToByte(string _in)
        {
            if (byte.TryParse(_in, out byte val))
                return val;
            return 255;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return (value as string).Split(' ');
        }
    }
}
