using System;
using System.Collections.Generic;
using System.Globalization;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Factory to create WeatherInfoCollection with common groupings.
    /// </summary>
    public class FactoryWeatherInfoCollection
    {
        #region Properties

        /// <summary>
        ///     Gets the grouped collections.
        /// </summary>
        /// <value>
        ///     The grouped collections.
        /// </value>
        private ICollection<ICollection<WeatherInfo>> GroupedByMonth { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FactoryWeatherInfoCollection" /> class.
        /// </summary>
        public FactoryWeatherInfoCollection()
        {
            this.GroupedByMonth = new List<ICollection<WeatherInfo>>();
            this.groupCollectionsByMonth();
        }

        #endregion

        #region Methods

        private void groupCollectionsByMonth()
        {
            try
            {
                var grouped = ActiveWeatherInfoCollection.Active.GroupByMonth();
                foreach (var current in grouped)
                {
                    var keyYear = $"{current.Key}";

                    foreach (var currentMonths in current.Value)
                    {
                        var keyMonth = $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonths.Key)}";
                        var key = $"{keyMonth} {keyYear}";
                        this.GroupedByMonth.Add(new WeatherInfoCollection(key, currentMonths.Value));
                    }
                }
            }
            catch (Exception)
            {
                //TODO Fix this such that user notified of error
                //ignored
            }
        }

        #endregion
    }
}