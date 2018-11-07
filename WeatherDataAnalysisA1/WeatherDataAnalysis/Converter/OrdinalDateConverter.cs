using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using WeatherDataAnalysis.Extension;
using WeatherDataAnalysis.Utility;

namespace WeatherDataAnalysis.Converter
{
    /// <summary>
    /// Converts Date string to have an ordinal number for the day of the month.
    /// Example Format: January 1st, 2019
    /// </summary>
    public class OrdinalDateConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dateValue = (DateTime) value;

            return dateValue.OrdinalDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var dateTimeOffset = (DateTimeOffset) value;
            return dateTimeOffset.DateTime;
        }
    }
}
