using System.Collections.Generic;
using System.Linq;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Provides analytic functions for sets of Weather objects.
    /// </summary>
    public class WeatherCollection
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the collection.
        /// </summary>
        /// <value>
        ///     The collection.
        /// </value>
        private List<Weather> Collection { get; }

        /// <summary>
        ///     Gets or sets the high temps.
        /// </summary>
        /// <value>
        ///     The high temps.
        /// </value>
        private List<int> HighTemps { get; }

        /// <summary>
        ///     Gets or sets the low temps.
        /// </summary>
        /// <value>
        ///     The low temps.
        /// </value>
        private List<int> LowTemps { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherCollection" /> class.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        public WeatherCollection(List<Weather> weatherCollection)
        {
            this.Collection = weatherCollection;

            this.LowTemps = (from weather in this.Collection
                             select weather.LowTemp).ToList();

            this.HighTemps = (from weather in this.Collection
                              select weather.HighTemp).ToList();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the highest temps.
        /// </summary>
        /// <returns>List of Weather with the highest temps.</returns>
        public List<Weather> GetHighestTemps()
        {
            var highest = this.Collection.Max(weather => weather.HighTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.HighTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        ///     Gets the highest low temps.
        /// </summary>
        /// <returns>List of Weather with the highest low temps.</returns>
        public List<Weather> GetHighestLowTemps()
        {
            var highest = this.Collection.Max(weather => weather.LowTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.LowTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        ///     Gets the lowest temps.
        /// </summary>
        /// <returns>List of Weather with the lowest temps.</returns>
        public List<Weather> GetLowestTemps()
        {
            var lowest = this.Collection.Min(weather => weather.LowTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.LowTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        ///     Gets the lowest high temps.
        /// </summary>
        /// <returns>List of Weather with the lowest high temps.</returns>
        public List<Weather> GetLowestHighTemps()
        {
            var lowest = this.Collection.Min(weather => weather.HighTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.HighTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        ///     Gets the average high temp.
        /// </summary>
        /// <returns>The average high temp.</returns>
        public double GetAverageHighTemp()
        {
            return this.HighTemps.Average();
        }

        /// <summary>
        ///     Gets the average low temp.
        /// </summary>
        /// <returns>The average low temp.</returns>
        public double GetAverageLowTemp()
        {
            return this.LowTemps.Average();
        }

        /// <summary>
        /// Gets the days above 90.
        /// </summary>
        /// <returns>Weather objects where high above 90</returns>
        public List<Weather> GetDaysAbove90()
        {
            return this.Collection.Where(weather => weather.HighTemp >= 90).ToList();
        }

        /// <summary>
        /// Gets the days below32.
        /// </summary>
        /// <returns>Weather objects where high below 32</returns>
        public List<Weather> GetDaysBelow32()
        {
            return this.Collection.Where(weather => weather.LowTemp <= 32).ToList();
        }
        
        //TODO Complete Method docs
        /// <summary>
        /// Gets the highest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<Weather> GetHighestInMonth(int month)
        {
            var weatherByMonthList = this.Collection.Where(weather => weather.Date.Month == month).ToList();

            var highInMonth = weatherByMonthList.Max(weather => weather.HighTemp);

            var weatherHigh = weatherByMonthList.Where(weather => weather.HighTemp == highInMonth).ToList();

            return weatherHigh;
        }

        /// <summary>
        /// Gets the lowest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<Weather> GetLowestInMonth(int month)
        {
            var weatherByMonthList = this.Collection.Where(weather => weather.Date.Month == month).ToList();

            var lowInMonth = weatherByMonthList.Min(weather => weather.LowTemp);

            var weatherLow = weatherByMonthList.Where(weather => weather.LowTemp == lowInMonth).ToList();

            return weatherLow;
        }

        /// <summary>
        /// Gets the high average for month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public double GetHighAverageForMonth(int month)
        {
            var weatherByMonthList = this.Collection.Where(weather => weather.Date.Month == month).ToList();
      
            var highTempsPerMonth = (from weather in weatherByMonthList
                                     select weather.HighTemp).ToList();

            var average = highTempsPerMonth.Average();

            return average;
        }

        /// <summary>
        /// Gets the low average for month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public double GetLowAverageForMonth(int month)
        {
            var weatherByMonthList = this.Collection.Where(weather => weather.Date.Month == month).ToList();

            var lowTempsPerMonth = (from weather in weatherByMonthList
                                     select weather.LowTemp).ToList();

            var average = lowTempsPerMonth.Average();

            return average;
        }

        #endregion
    }
}