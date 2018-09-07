using System.Collections.Generic;
using System.Linq;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Provides analytic functions for collections of WeatherInfo.
    /// </summary>
    public class WeatherInfoCollection
    {
        #region Properties

        public List<WeatherInfo> Collection { get; }

        public List<int> HighTemps { get; }

        public List<int> LowTemps { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherInfoCollection" /> class.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        public WeatherInfoCollection(List<WeatherInfo> weatherCollection)
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
        public List<WeatherInfo> GetHighestTemps()
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
        public List<WeatherInfo> GetHighestLowTemps()
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
        public List<WeatherInfo> GetLowestTemps()
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
        public List<WeatherInfo> GetLowestHighTemps()
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

        //TODO add parameter for temp greater than <temperature> 
        /// <summary>
        /// Gets the days above 90.
        /// </summary>
        /// <returns>Weather objects where high above 90</returns>
        public List<WeatherInfo> GetDaysAbove90()
        {
            return this.Collection.Where(weather => weather.HighTemp >= 90).ToList();
        }

        //TODO add parameter for temp less than <temperature> 
        /// <summary>
        /// Gets the days below 32.
        /// </summary>
        /// <returns>Weather objects where high below 32</returns>
        public List<WeatherInfo> GetDaysBelow32()
        {
            return this.Collection.Where(weather => weather.LowTemp <= 32).ToList();
        }
        
        //TODO return statements docs
        /// <summary>
        /// Gets the highest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<WeatherInfo> GetHighestInMonth(int month)
        {
            var weatherByMonthList = this.Collection.Where(weather => weather.Date.Month == month).ToList();
            var highInMonth = weatherByMonthList.Max(weather => weather.HighTemp);
            var highTempWeatherInfos = weatherByMonthList.Where(weather => weather.HighTemp == highInMonth).ToList();

            return highTempWeatherInfos;
        }

        /// <summary>
        /// Gets the lowest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<WeatherInfo> GetLowestInMonth(int month)
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