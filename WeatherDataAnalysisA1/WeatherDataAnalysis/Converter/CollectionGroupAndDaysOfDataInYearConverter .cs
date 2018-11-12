using System;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    public class CollectionGroupAndDaysInYearDataConverter :IValueConverter
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
            var collection = (string) value;

            var numberOfDays = 0;
            var parse = int.TryParse(collection, out var year);

            if (DateTime.IsLeapYear(year))
            {
                numberOfDays = 366;
            }
            else
            {
                numberOfDays = 365;
            }
     
            return
                $" out of {numberOfDays} Days of Data";
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
