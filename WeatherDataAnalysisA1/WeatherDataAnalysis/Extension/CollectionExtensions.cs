using System.Collections.Generic;
using System.Collections.ObjectModel;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Extension
{
    /// <summary>
    ///     Extension methods for Collection classes
    /// </summary>
    public static class CollectionExtensions
    {
        #region Methods

        /// <summary>
        ///     Converts <paramref name="collection" /> to an ObservableCollection
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public static ObservableCollection<WeatherInfo> ToObservableCollection(this IList<WeatherInfo> collection)
        {
            return new ObservableCollection<WeatherInfo>(collection);
        }

        public static ObservableCollection<WeatherInfoCollection> ToObservableCollection(
            this IList<WeatherInfoCollection> collection)
        {
            return new ObservableCollection<WeatherInfoCollection>(collection);
        }

        public static ObservableCollection<int> TObservableCollection(this IList<int> collection)
        {
            return new ObservableCollection<int>(collection);
        }

        #endregion
    }
}