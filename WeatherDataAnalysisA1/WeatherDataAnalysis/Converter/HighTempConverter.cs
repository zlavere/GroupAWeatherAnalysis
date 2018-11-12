using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace WeatherDataAnalysis.Converter
{
    public class HighTempConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var conversion = $"The highest temperature of {(int) value} occurred on:";
            return conversion;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
