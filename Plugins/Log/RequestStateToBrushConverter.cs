using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HZBot
{
    [ValueConversion(typeof(RequestState), typeof(Brush))]
    public class RequestStateToBrushConverter : IValueConverter
    {
        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((RequestState)value)
            {
                case RequestState.Unknown:
                    return Brushes.White;

                case RequestState.Pending:
                    return Brushes.Yellow;

                case RequestState.Success:
                    return Brushes.Green;

                case RequestState.Error:
                    return Brushes.Red;

                default:
                    return Brushes.White;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}