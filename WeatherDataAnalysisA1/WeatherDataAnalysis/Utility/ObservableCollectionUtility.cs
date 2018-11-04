using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Utility
{
    public static class ObservableCollectionUtility
    {
        public static ObservableCollection<WeatherInfo> ToObservableCollection(this WeatherInfoCollection collection)
        {
            return new ObservableCollection<WeatherInfo>(collection);
        }
    }
}
