using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    public class CollectionGroupAndDaysInMonthDataConverter :IValueConverter
    {
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
            var name = (string) value;
            var splitName = name.Split(' ');
            var monthInt = DateTime.ParseExact(splitName[0], "MMMM", CultureInfo.CurrentCulture).Month;
            var parsed = int.TryParse(splitName[1], out var year);

            var totalDaysInMonth = DateTime.DaysInMonth(year, monthInt);

            return
            $" out of {totalDaysInMonth} Days of Data"; 

        }

        /// <summary>
        /// Not Implemented, unnecessary
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
