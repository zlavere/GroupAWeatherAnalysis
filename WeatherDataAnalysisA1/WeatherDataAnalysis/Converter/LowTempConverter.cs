using System;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    /// <summary>
    /// Converts the value to a friendly LowTemp header for UI.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Data.IValueConverter" />
    public class LowTempConverter: IValueConverter
    {
        /// <summary>
        /// Converts the value to a friendly LowTemp header for UI.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var conversion = $"The lowest temperature of {(int) value} occurred on:";
            return conversion;
        }

        /// <summary>
        /// Not Required
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
