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

        private readonly List<WeatherInfo> weatherInfoCollection;
        private readonly List<int> highTemperatures;
        private readonly List<int> lowTemperatures;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherInfoCollection" /> class.
        /// </summary>
        /// <param name="weatherInfoCollection">The weather collection.</param>
        public WeatherInfoCollection(List<WeatherInfo> weatherInfoCollection)
        {
            this.weatherInfoCollection = weatherInfoCollection;
            this.highTemperatures = this.weatherInfoCollection.Select(weatherInfo => weatherInfo.HighTemp).ToList();
            this.lowTemperatures = this.weatherInfoCollection.Select(weatherInfo => weatherInfo.LowTemp).ToList();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the highest temps.
        /// </summary>
        /// <returns>List of Weather with the highest temps.</returns>
        public List<WeatherInfo> GetHighestTemps()
        {
            var highest = this.weatherInfoCollection.Max(weather => weather.HighTemp);
            var highestTemps =
                this.weatherInfoCollection.Where(weatherInfo => weatherInfo.HighTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        ///     Gets the highest low temps.
        /// </summary>
        /// <returns>List of Weather with the highest low temps.</returns>
        public List<WeatherInfo> GetHighestLowTemps()
        {
            var highest = this.weatherInfoCollection.Max(weatherInfo => weatherInfo.LowTemp);
            var highestTemps =
                this.weatherInfoCollection.Where(weatherInfo => weatherInfo.LowTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        ///     Gets the lowest temps.
        /// </summary>
        /// <returns>List of Weather with the lowest temps.</returns>
        public List<WeatherInfo> GetLowestTemps()
        {
            var lowest = this.weatherInfoCollection.Min(weather => weather.LowTemp);
            var lowTemps =
                this.weatherInfoCollection.Where(temp => temp.LowTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        ///     Gets the lowest high temps.
        /// </summary>
        /// <returns>List of Weather with the lowest high temps.</returns>
        public List<WeatherInfo> GetLowestHighTemps()
        {
            var lowest = this.weatherInfoCollection.Min(weather => weather.HighTemp);
            var lowTemps =
                this.weatherInfoCollection.Where(temp => temp.HighTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        ///     Gets the average high temp.
        /// </summary>
        /// <returns>The average high temp.</returns>
        public double GetAverageHighTemp()
        {
            return this.highTemperatures.Average();
        }

        /// <summary>
        ///     Gets the average low temp.
        /// </summary>
        /// <returns>The average low temp.</returns>
        public double GetAverageLowTemp()
        {
            return this.lowTemperatures.Average();
        }

        //TODO add parameter for temp greater than <temperature> 
        /// <summary>
        /// Finds WeatherInfos with high temps above temp parameter
        /// </summary>
        /// <returns>WeatherInfo collection where high above temp</returns>
        public List<WeatherInfo> FindDaysAbove(int temp)
        {
            return this.weatherInfoCollection.Where(weather => weather.HighTemp >= temp).ToList();
        }

        /// <summary>
        /// Find below temp parameter.
        /// </summary>
        /// <returns>WeatherInfo collection where low below temp parameter</returns>
        public List<WeatherInfo> FindDaysBelow(int temp)
        {
            return this.weatherInfoCollection.Where(weather => weather.LowTemp <= temp).ToList();
        }

        //TODO return statements docs
        /// <summary>
        /// Gets the highest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<WeatherInfo> GetHighestInMonth(int month)
        {
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();
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
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();
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
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();
      
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
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();

            var lowTempsPerMonth = (from weather in weatherByMonthList
                                     select weather.LowTemp).ToList();

            var average = lowTempsPerMonth.Average();

            return average;
        }

        #endregion
    }
}