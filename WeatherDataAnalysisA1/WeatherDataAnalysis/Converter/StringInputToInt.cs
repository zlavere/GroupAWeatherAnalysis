using System;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    public class StringInputToInt : IValueConverter
    {
        #region Methods

        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var isValid = int.TryParse((string) value, out var result);
            if (!isValid)
            {
                throw new FormatException($"The value {value} is not a valid integer.");
            }

            return result;
        }

        #endregion
    }
}