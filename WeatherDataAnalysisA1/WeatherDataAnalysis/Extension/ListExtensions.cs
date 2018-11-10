using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Extension
{
    public static class ListExtensions
    {
        public static ObservableCollection<WeatherInfo> ToObservableCollection(this IList<WeatherInfo> collection)
        {
            return new ObservableCollection<WeatherInfo>(collection);
        }

    }
}
