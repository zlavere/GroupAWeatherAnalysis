using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Format
{
    /// <summary>
    ///     Formats Temperature Data
    /// </summary>
    public class TemperatureDataFormatter
    {
        #region Data members

        private const int TwoPointFloatPrecision = 2;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the weather information collection.
        /// </summary>
        /// <value>
        ///     The weather information collection.
        /// </value>
        public WeatherInfoCollection WeatherInfoCollection { private get; set; }

        private FactoryWeatherInfoCollection GroupedWeatherInfoCollection { get; set; }

        /// <summary>
        /// Gets or sets the low temporary threshold.
        /// </summary>
        /// <value>
        /// The low temporary threshold.
        /// </value>
        public int LowTempThreshold { private get; set; }

        /// <summary>
        /// Gets or sets the high temporary threshold.
        /// </summary>
        /// <value>
        /// The high temporary threshold.
        /// </value>
        public int HighTempThreshold { private get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureDataFormatter"/> class.
        /// </summary>
        public TemperatureDataFormatter()
        {
            this.LowTempThreshold = int.MinValue;
            this.HighTempThreshold = int.MaxValue;
        }

        #region Methods

        /// <summary>
        ///     Generates the grouped weather information collections.
        /// </summary>
        /// <returns>Analytic output of weather data grouped by Month.</returns>
        public string GetOutput()
        {
            this.GroupedWeatherInfoCollection = new FactoryWeatherInfoCollection(this.WeatherInfoCollection);

            var output = this.generateYearOverview();

            return output;
        }

        /// <summary>
        /// Generates the year overview.
        /// </summary>
        /// <returns></returns>
        private string generateYearOverview()
        {
            var masterCollection = this.GroupedWeatherInfoCollection.MasterCollection;
            var years = masterCollection.Select(year => year.Date.Year).ToList().OrderByDescending(year => year)
                                        .Distinct();

            var output = string.Empty;

            foreach (var current in years)
            {
                output += $"{current}{Environment.NewLine}";
                var collection = new WeatherInfoCollection($"{current}",
                    masterCollection.Where(year => year.Date.Year == current).ToList());
                output +=
                    $"Average High Temperature in {current}: {Math.Round(collection.GetAverageHigh(), TwoPointFloatPrecision)}{Environment.NewLine}";
                output +=
                    $"Average Low Temperature in {current}: {Math.Round(collection.GetAverageLow(), TwoPointFloatPrecision)}{Environment.NewLine}";
                output +=
                    $"The Highest Temperature in {current} was {collection.Max(temp => temp.HighTemp)}{Environment.NewLine}Occured on:{Environment.NewLine} {this.getHighestTemps(collection)}";
                output +=
                    $"The Lowest High Temperature in {current} was {collection.Min(temp => temp.HighTemp)}{Environment.NewLine}Occured on:{Environment.NewLine} {this.getLowestHighTemps(collection)}";
                output +=
                    $"The Highest Low Temperature in {current} was {collection.Max(temp => temp.LowTemp)}{Environment.NewLine}Occured on:{Environment.NewLine} {this.getHighestLowTemps(collection)}";
                if (this.LowTempThreshold != int.MinValue)
                {
                    output += $"Dates with temperatures below {this.LowTempThreshold}{Environment.NewLine}";
                    output += $"{this.getTempsBelow(collection)}";
                }

                if (this.HighTempThreshold != int.MaxValue)
                {
                    output += $"Dates with temperatures above {this.HighTempThreshold}{Environment.NewLine}";
                    output += this.getTempsAbove(collection);
                }
                
            }

            output += Environment.NewLine;
            return output;
        }

        private string getHighestTemps(WeatherInfoCollection collection)
        {
            var highest = collection.Max(temp => temp.HighTemp);
            var output = string.Empty;
            foreach (var current in collection.Where(temp => temp.HighTemp == highest))
            {
                output += $"{this.getDateString(current.Date)} {Environment.NewLine}";
            }

            return output;
        }

        private string getLowestHighTemps(WeatherInfoCollection collection)
        {
            var lowest = collection.Min(temp => temp.HighTemp);
            var output = string.Empty;
            foreach (var current in collection.Where(temp => temp.HighTemp == lowest))
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }

        private string getHighestLowTemps(WeatherInfoCollection collection)
        {
            var highest = collection.Max(temp => temp.LowTemp);
            var output = string.Empty;
            foreach (var current in collection.Where(temp => temp.LowTemp >= highest))
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }

        private WeatherInfoCollection getCollectionsByYear(int year)
        {
            var listByYear = new List<WeatherInfo>();

            foreach (var current in this.GroupedWeatherInfoCollection.GroupedByYear.Values)
            {
                listByYear = (List<WeatherInfo>) current.Where(currentYear => currentYear.Date.Year == year);
            }

            var collection = new WeatherInfoCollection($"{year}", listByYear);
            return collection;
        }

        private string getTempsBelow(WeatherInfoCollection collection)
        {
            var output = string.Empty;
            foreach(var current in collection.Where(weather => weather.LowTemp <= this.LowTempThreshold))
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }

        private string getTempsAbove(WeatherInfoCollection collection)
        {
            var output = string.Empty;
            foreach (var current in collection.Where(weather => weather.HighTemp >= this.HighTempThreshold))
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }



        /// <summary>
        ///     Formats the high per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>Returns a string formatted for GUI of highest temperature for the month and date(s) it occurred on.</returns>
        public string FormatHighPerMonth(int month)
        {
            var highestInMonthList = this.WeatherInfoCollection.GetHighestInMonth(month);
            var highestInMonth =
                $"Date(s) with the highest temperature of {highestInMonthList.First().HighTemp} in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} {highestInMonthList[0].Date.Year}:"
                + Environment.NewLine;

            foreach (var current in highestInMonthList)
            {
                if (current != highestInMonthList.Last())
                {
                    highestInMonth += $"{this.getDateString(current.Date)}" + Environment.NewLine;
                }
                else
                {
                    highestInMonth += $"{this.getDateString(current.Date)}";
                }
            }

            return highestInMonth;
        }

        /// <summary>
        ///     Formats the low per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>String for the Lowest Temperature in a given month and Dates that reached that low.</returns>
        public string FormatLowPerMonth(int month)
        {
            var lowestInMonthList = this.WeatherInfoCollection.GetLowestInMonth(month);
            var lowestInMonth =
                $"Date(s) with the Lowest temperature of {lowestInMonthList.First().HighTemp} in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} {lowestInMonthList[0].Date.Year}:"
                + Environment.NewLine;

            foreach (var current in lowestInMonthList)
            {
                if (current != lowestInMonthList.Last())
                {
                    lowestInMonth += $"{this.getDateString(current.Date)}" + Environment.NewLine;
                }
                else
                {
                    lowestInMonth += $"{this.getDateString(current.Date)}";
                }
            }

            return lowestInMonth;
        }

        /// <summary>
        ///     Formats the low average per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>String for Average Low in given month.</returns>
        public string FormatLowAveragePerMonth(int month)
        {
            return
                $"The average average low in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(this.WeatherInfoCollection.GetLowAverageForMonth(month), TwoPointFloatPrecision)}.";
        }

        /// <summary>
        ///     Formats the high average per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>String for Average High in given month.</returns>
        public string FormatHighAveragePerMonth(int month)
        {
            return
                $"The average average high in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(this.WeatherInfoCollection.GetHighAverageForMonth(month), TwoPointFloatPrecision)}.";
        }

        private string getDateString(DateTime date)
        {
            var month = DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
            var ordinalDay = this.getOrdinal(date.Day);
            return $"{month} {ordinalDay}, {date.Year}";
        }

        private string getOrdinal(int day)
        {
            string ordinalDay;
            if (day == 11 || day == 12 || day == 13)
            {
                ordinalDay = day + "th";
            }
            else
            {
                switch (day % 10)
                {
                    case 1:
                        ordinalDay = day + "st";
                        break;
                    case 2:
                        ordinalDay = day + "nd";
                        break;
                    case 3:
                        ordinalDay = day + "rd";
                        break;
                    default:
                        ordinalDay = day + "th";
                        break;
                }
            }

            return ordinalDay;
        }

        #endregion
    }
}