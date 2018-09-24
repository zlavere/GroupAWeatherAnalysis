using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Creates a series of grouped collections.
    /// </summary>
    public class FactoryWeatherInfoCollection
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the master collection.
        /// </summary>
        /// <value>
        ///     The master collection.
        /// </value>
        public WeatherInfoCollection MasterCollection { get; }

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
        public IDictionary<int, WeatherInfoCollection> GroupedByYear { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FactoryWeatherInfoCollection" /> class.
        /// </summary>
        /// <param name="masterCollection">The master collection.</param>
        public FactoryWeatherInfoCollection(WeatherInfoCollection masterCollection)
        {
            this.MasterCollection = masterCollection;
            this.GroupedByMonth = new List<ICollection<WeatherInfo>>();
            this.GroupedByYear = new Dictionary<int, WeatherInfoCollection>();
            this.factoryWeatherInfoCollection();
        }

        #endregion

        #region Methods

        private void factoryWeatherInfoCollection()
        {
            var grouped = this.MasterCollection.GroupByMonth();

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

        private void GroupByYear()
        {
            var groupByYear = this.MasterCollection.GroupBy(weather => weather.Date.Year);

            foreach (var current in groupByYear)
            {
                this.GroupedByYear.Add(current.Key, new WeatherInfoCollection($"{current.Key}", current.ToList()));
            }
        }

        #endregion
    }
}