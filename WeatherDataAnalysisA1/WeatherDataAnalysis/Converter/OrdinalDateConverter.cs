using System;
using Windows.UI.Xaml.Data;
using WeatherDataAnalysis.Extension;

namespace WeatherDataAnalysis.Converter
{
    /// <summary>
    ///     Converts Date string to have an ordinal number for the day of the month.
    ///     Example Format: January 1st, 2019
    /// </summary>
    public class OrdinalDateConverter : IValueConverter
    {
        #region Methods

        /// <summary>
        ///     Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dateValue = (DateTime) value;

            return dateValue.OrdinalDateString();
        }

        /// <summary>Converts value back to a date.</summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var dateTimeOffset = (DateTimeOffset) value;
            return dateTimeOffset.DateTime;
        }

        #endregion
    }
}