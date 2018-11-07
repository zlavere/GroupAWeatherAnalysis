using System.Collections.ObjectModel;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Extension
{
    public static class ListExtensions
    {
        public static ObservableCollection<WeatherInfo> ToObservableCollection(this WeatherInfoCollection collection)
        {
            return new ObservableCollection<WeatherInfo>(collection);
        }
    }
}
