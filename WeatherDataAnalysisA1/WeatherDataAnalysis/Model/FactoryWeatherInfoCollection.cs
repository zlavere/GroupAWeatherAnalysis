using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Creates a series of grouped collections.
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

        /// <summary>
        /// Gets the grouped by year.
        /// </summary>
        /// <value>
        /// The grouped by year.
        /// </value>
        private IDictionary<int, WeatherInfoCollection> GroupedByYear { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FactoryWeatherInfoCollection" /> class.
        /// </summary>
        /// <param name="masterCollection">The master collection.</param>
        public FactoryWeatherInfoCollection()
        {
            this.GroupedByMonth = new List<ICollection<WeatherInfo>>();
            this.GroupedByYear = new Dictionary<int, WeatherInfoCollection>();
            this.factoryWeatherInfoCollection();
        }

        #endregion

        #region Methods

        private void factoryWeatherInfoCollection()
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