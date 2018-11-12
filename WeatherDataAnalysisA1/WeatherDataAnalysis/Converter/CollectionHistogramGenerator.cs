using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using WeatherDataAnalysis.Format;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Converter
{
    public class CollectionHistogramGenerator :IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var collection = (List<WeatherInfo>) value;
            var histogramGenerator = new WeatherHistogramGenerator();

            return $"{histogramGenerator.CreateTempHistogram(collection)}{Environment.NewLine}" + 
                   $"{histogramGenerator.CreatePrecipitationHistogram(collection)}";

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
