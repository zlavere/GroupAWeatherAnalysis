using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.Foundation.Collections;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Extension
{
    /// <summary>
    /// Extension methods for Collection classes
    /// </summary>
    public static class CollectionExtensions
    {
        #region Methods

        /// <summary>
        /// Converts <paramref name="collection"/> to an ObservableCollection
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static ObservableCollection<WeatherInfo> ToObservableCollection(this IList<WeatherInfo> collection) => new ObservableCollection<WeatherInfo>(collection);
        public static ObservableCollection<WeatherInfoCollection> ToObservableCollection(this IList<WeatherInfoCollection> collection) => new ObservableCollection<WeatherInfoCollection>(collection);

        #endregion
    }
}