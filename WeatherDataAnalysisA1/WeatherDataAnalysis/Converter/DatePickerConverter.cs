using System;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    /// <summary>
    /// Converts Date to DateTimeOffset for DatePicker binding.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Data.IValueConverter" />
    public class DatePickerConverter : IValueConverter
    {
        #region Methods

        object IValueConverter.Convert(object value, Type targetType, object parameter, string language)
        {
            var dateTime = (DateTime) value;
            return new DateTimeOffset(dateTime);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var dateTimeOffset = (DateTimeOffset) value;
            return dateTimeOffset.DateTime;
        }

        #endregion
    }
}