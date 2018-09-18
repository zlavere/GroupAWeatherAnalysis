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


        private List<WeatherInfo> weatherInfos { get; }

        private List<int> HighTemps { get; }

        private List<int> LowTemps { get; }


        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherInfoCollection" /> class.
        /// </summary>

        /// <param name="weatherWeatherInfos">The weather collection.</param>
        public WeatherInfoCollection(List<WeatherInfo> weatherWeatherInfos)
        {
            this.weatherInfos = weatherWeatherInfos;

            this.LowTemps = (from weather in this.weatherInfos
                             select weather.LowTemp).ToList();

            this.HighTemps = (from weather in this.weatherInfos
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

            var highest = this.weatherInfos.Max(weather => weather.HighTemp);
            var highestTemps =
                this.weatherInfos.Where(temp => temp.HighTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        ///     Gets the highest low temps.
        /// </summary>
        /// <returns>List of Weather with the highest low temps.</returns>
        public List<WeatherInfo> GetHighestLowTemps()
        {

            var highest = this.weatherInfos.Max(weather => weather.LowTemp);
            var highestTemps =
                this.weatherInfos.Where(temp => temp.LowTemp == highest)
=======
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
<<<<<<< HEAD
            var lowest = this.weatherInfos.Min(weather => weather.LowTemp);
            var lowTemps =
                this.weatherInfos.Where(temp => temp.LowTemp == lowest)
=======
            var lowest = this.weatherInfoCollection.Min(weather => weather.LowTemp);
            var lowTemps =
                this.weatherInfoCollection.Where(temp => temp.LowTemp == lowest)
>>>>>>> 23fa0d7f4fe729c9c705db7ab100554d18e2fe7b
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        ///     Gets the lowest high temps.
        /// </summary>
        /// <returns>List of Weather with the lowest high temps.</returns>
        public List<WeatherInfo> GetLowestHighTemps()
        {
<<<<<<< HEAD
            var lowest = this.weatherInfos.Min(weather => weather.HighTemp);
            var lowTemps =
                this.weatherInfos.Where(temp => temp.HighTemp == lowest)
=======
            var lowest = this.weatherInfoCollection.Min(weather => weather.HighTemp);
            var lowTemps =
                this.weatherInfoCollection.Where(temp => temp.HighTemp == lowest)
>>>>>>> 23fa0d7f4fe729c9c705db7ab100554d18e2fe7b
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

        /// <summary>
<<<<<<< HEAD
        ///     Gets the days above 90.
        /// </summary>
        /// <param name="highTemp"></param>
        /// <returns>Weather objects where high above 90</returns>
        public List<WeatherInfo> GetDaysAbove(int highTemp)
        {
            return this.weatherInfos.Where(weather => weather.HighTemp >= highTemp).ToList();
        }

        /// <summary>
        ///     Gets the days below 32.
        /// </summary>
        /// <returns>Weather objects where high below 32</returns>
        public List<WeatherInfo> GetDaysBelow(int lowTemp)
        {
            return this.weatherInfos.Where(weather => weather.LowTemp <= lowTemp).ToList();
=======
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
>>>>>>> 23fa0d7f4fe729c9c705db7ab100554d18e2fe7b
        }

        //TODO return statements docs
        /// <summary>
        ///     Gets the highest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<WeatherInfo> GetHighestInMonth(int month)
        {
<<<<<<< HEAD
            var weatherByMonthList = this.weatherInfos.Where(weather => weather.Date.Month == month).ToList();
=======
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();
>>>>>>> 23fa0d7f4fe729c9c705db7ab100554d18e2fe7b
            var highInMonth = weatherByMonthList.Max(weather => weather.HighTemp);
            var highTempWeatherInfos = weatherByMonthList.Where(weather => weather.HighTemp == highInMonth).ToList();

            return highTempWeatherInfos;
        }

        /// <summary>
        ///     Gets the lowest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<WeatherInfo> GetLowestInMonth(int month)
        {
<<<<<<< HEAD
            var weatherByMonthList = this.weatherInfos.Where(weather => weather.Date.Month == month).ToList();

=======
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();
>>>>>>> 23fa0d7f4fe729c9c705db7ab100554d18e2fe7b
            var lowInMonth = weatherByMonthList.Min(weather => weather.LowTemp);
            var weatherLow = weatherByMonthList.Where(weather => weather.LowTemp == lowInMonth).ToList();

            return weatherLow;
        }

        /// <summary>
        ///     Gets the high average for month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public double GetHighAverageForMonth(int month)
        {
<<<<<<< HEAD
            var weatherByMonthList = this.weatherInfos.Where(weather => weather.Date.Month == month).ToList();

            var highTempsPerMonth = weatherByMonthList.Select(weather => weather.HighTemp);
=======
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();
      
            var highTempsPerMonth = (from weather in weatherByMonthList
                                     select weather.HighTemp).ToList();
>>>>>>> 23fa0d7f4fe729c9c705db7ab100554d18e2fe7b

            var average = highTempsPerMonth.Average();

            return average;
        }

        /// <summary>
        ///     Gets the low average for month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public double GetLowAverageForMonth(int month)
        {
<<<<<<< HEAD
            var weatherByMonthList = this.weatherInfos
                                         .Where(weather => weather.Date.Month == month).ToList();
=======
            var weatherByMonthList = this.weatherInfoCollection.Where(weather => weather.Date.Month == month).ToList();
>>>>>>> 23fa0d7f4fe729c9c705db7ab100554d18e2fe7b

            var lowTempsPerMonth = (from weather in weatherByMonthList
                                    select weather.LowTemp).ToList();

            var average = lowTempsPerMonth.Average();

            return average;
        }

        #endregion
    }
}