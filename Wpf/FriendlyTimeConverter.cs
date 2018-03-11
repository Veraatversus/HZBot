using System;
using System.Globalization;
using System.Windows.Data;

namespace HZBot
{
    public class FriendlyTimeConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ts = TimeSpan.FromSeconds((int)value);
            return $"{ts.Minutes}:{ts.Seconds:D2}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}