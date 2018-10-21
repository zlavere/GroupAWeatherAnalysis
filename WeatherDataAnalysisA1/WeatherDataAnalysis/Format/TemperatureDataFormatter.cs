﻿using System;
using System.Globalization;
using System.Linq;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Model.Enums;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Format
{
    /// <summary>
    ///     Formats Temperature Data
    /// </summary>
    public class TemperatureDataFormatter
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the weather information collection.
        /// </summary>
        /// <value>
        ///     The weather information collection.
        /// </value>
        public WeatherInfoCollection WeatherInfoCollection { private get; set; }

        private FactoryWeatherInfoCollection FactoryWeatherInfoCollection { get; }

        /// <summary>
        ///     Gets or sets the low temporary threshold.
        /// </summary>
        /// <value>
        ///     The low temporary threshold.
        /// </value>
        public int LowTempThreshold { get; set; }

        /// <summary>
        ///     Gets or sets the high temporary threshold.
        /// </summary>
        /// <value>
        ///     The high temporary threshold.
        /// </value>
        public int HighTempThreshold { get; set; }

        public int Month { private get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemperatureDataFormatter" /> class.
        /// </summary>
        public TemperatureDataFormatter()
        {
            this.FactoryWeatherInfoCollection = new FactoryWeatherInfoCollection();
            this.Month = -1;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Generates the grouped weather information collections.
        /// </summary>
        /// <returns>Analytic output of weather data grouped by Month.</returns>
        public string GetOutput()
        {
            var output = this.generateYearOverview();
            return output;
        }

        /// <summary>
        ///     Generates the year overview.
        /// </summary>
        /// <returns></returns>
        private string generateYearOverview()
        {
            var years = this.WeatherInfoCollection.Select(year => year.Date.Year).ToList()
                            .OrderBy(year => year)
                            .Distinct();

            var output = string.Empty;

            foreach (var currentYear in years)
            {
                var queryYearInActiveCollection =
                    ActiveWeatherInfoCollection.Active.Where(weatherInfo => weatherInfo.Date.Year == currentYear);

                this.WeatherInfoCollection =
                    new WeatherInfoCollection($"{currentYear}", queryYearInActiveCollection.ToList());

                output += $"{currentYear} Data: ({this.WeatherInfoCollection.Count} Days of Data){Environment.NewLine}";
                output +=
                    $"Average High Temperature in {currentYear}: " +
                    $"{Math.Round(this.WeatherInfoCollection.GetAverageHigh(), 2)}{Environment.NewLine}";
                output +=
                    $"Average Low Temperature in {currentYear}: " +
                    $"{Math.Round(this.WeatherInfoCollection.GetAverageLow(), 2)}{Environment.NewLine}";
                output +=
                    $"The Highest Temperature in {currentYear} was " +
                    $"{this.WeatherInfoCollection.HighestTemp}{Environment.NewLine}Occured on:{Environment.NewLine}{this.getHighestTemps()}";
                output +=
                    $"The Lowest Temperature in {currentYear} was " +
                    $"{this.WeatherInfoCollection.LowestTemp}{Environment.NewLine}Occured on:{Environment.NewLine}{this.getLowestTemps()}";
                output +=
                    $"The Lowest High Temperature in {currentYear} was " +
                    $"{this.WeatherInfoCollection.Min(temp => temp.HighTemp)}{Environment.NewLine}Occured on:{Environment.NewLine}{this.getLowestHighTemps()}";
                output +=
                    $"The Highest Low Temperature in {currentYear} was " +
                    $"{this.WeatherInfoCollection.Max(temp => temp.LowTemp)}{Environment.NewLine}Occured on:{Environment.NewLine}{this.getHighestLowTemps()}";

                output += $"Dates with temperatures below {this.LowTempThreshold}{Environment.NewLine}";
                output += $"{this.getTempsBelow()}";

                output += $"Dates with temperatures above {this.HighTempThreshold}{Environment.NewLine}";
                output += this.getTempsAbove();

                output += this.createHighHistogram();
                output += this.createLowHistogram();
                output += Environment.NewLine;
                try
                {
                    output += this.monthOutput(currentYear) + Environment.NewLine;
                }
                catch (InvalidOperationException)
                {
                    //ignored
                }
            }

            output += Environment.NewLine;
            return output;
        }

        private string monthOutput(int currentYear)
        {
            var output = string.Empty;
            for (var currentMonth = 1; currentMonth <= 12; currentMonth++)
            {
                var month = currentMonth;
                var queryByMonthInCurrentYear = ActiveWeatherInfoCollection.Active.Where(weather =>
                    weather.Date.Month == month &&
                    weather.Date.Year == currentYear);

                this.WeatherInfoCollection =
                    new WeatherInfoCollection(
                        $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(currentMonth)} {currentYear}",
                        queryByMonthInCurrentYear.ToList());
                try
                {
                    output +=
                        $"{this.WeatherInfoCollection.Name}: ({this.WeatherInfoCollection.Count} Days of Data){Environment.NewLine}";

                    output +=
                        $"Average High Temperature in {this.WeatherInfoCollection.Name}: " +
                        $"{Math.Round(this.WeatherInfoCollection.GetAverageHigh(), 2)}{Environment.NewLine}";
                    output +=
                        $"Average Low Temperature in {this.WeatherInfoCollection.Name}: " +
                        $"{Math.Round(this.WeatherInfoCollection.GetAverageLow(), 2)}{Environment.NewLine}";
                    output +=
                        $"The Highest Temperature in {this.WeatherInfoCollection.Name} was " +
                        $"{this.WeatherInfoCollection.Max(temp => temp.HighTemp)}" +
                        $"{Environment.NewLine}Occured on:{Environment.NewLine}{this.getHighestTemps()}";
                    output +=
                        $"The Lowest Temperature in {this.WeatherInfoCollection.Name} was " +
                        $"{this.WeatherInfoCollection.Min(temp => temp.LowTemp)}" +
                        $"{Environment.NewLine}Occurred on:{Environment.NewLine}{this.getLowestTemps()}";
                    output +=
                        $"The Lowest High Temperature in {this.WeatherInfoCollection.Name} was " +
                        $"{this.WeatherInfoCollection.Min(temp => temp.HighTemp)}" +
                        $"{Environment.NewLine}Occured on:{Environment.NewLine}{this.getLowestHighTemps()}";
                    output +=
                        $"The Highest Low Temperature in {this.WeatherInfoCollection.Name} was " +
                        $"{this.WeatherInfoCollection.Max(temp => temp.LowTemp)}" +
                        $"{Environment.NewLine}Occured on:{Environment.NewLine}{this.getHighestLowTemps()}";
                    output += Environment.NewLine;
                }
                catch (InvalidOperationException)
                {
                    //ignored
                }
            }

            return output;
        }

        private string getHighestTemps()
        {
            var output = string.Empty;
            foreach (var current in this.WeatherInfoCollection.FindWithHighest())
            {
                output += $"{this.getDateString(current.Date)} {Environment.NewLine}";
            }

            return output;
        }

        private string getLowestTemps()
        {
            var output = string.Empty;
            foreach (var current in this.WeatherInfoCollection.FindWithLowest())
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }

        private string getLowestHighTemps()
        {
            var output = string.Empty;
            foreach (var current in this.WeatherInfoCollection.FindLowestHighTemps())
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }

        private string getHighestLowTemps()
        {
            var output = string.Empty;
            foreach (var current in this.WeatherInfoCollection.FindHighestLow())
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }

        private string getTempsBelow()
        {
            var output = string.Empty;
            foreach (var current in this.WeatherInfoCollection.FindAllBelowLowTempThreshold(this.LowTempThreshold))
            {
                output += $"{this.getDateString(current.Date)}{Environment.NewLine}";
            }

            return output;
        }

        private string getTempsAbove()
        {
            var output = string.Empty;
            foreach (var current in this.WeatherInfoCollection.FindAllAboveHighTempThreshold(this.HighTempThreshold))
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
                $"Date(s) with the highest temperature of {highestInMonthList.First().HighTemp} in " +
                $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} {highestInMonthList.First().Date.Year}: "
                + Environment.NewLine;

            foreach (var current in highestInMonthList)
            {
                if (current != highestInMonthList.Last())
                {
                    highestInMonth += $"{this.getDateString(current.Date)}{Environment.NewLine}";
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
                $"Date(s) with the Lowest temperature of {lowestInMonthList.First().HighTemp} in " +
                $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} {lowestInMonthList[0].Date.Year}:"
                + Environment.NewLine;

            foreach (var current in lowestInMonthList)
            {
                if (current != lowestInMonthList.Last())
                {
                    lowestInMonth += $"{this.getDateString(current.Date)}{Environment.NewLine}";
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
                $"The average average low in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} " +
                $"was {Math.Round(this.WeatherInfoCollection.GetLowAverageForMonth(month), 2)}.";
        }

        /// <summary>
        ///     Formats the high average per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>String for Average High in given month.</returns>
        public string FormatHighAveragePerMonth(int month)
        {
            return
                $"The average average high in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was " +
                $"{Math.Round(this.WeatherInfoCollection.GetHighAverageForMonth(month), 2)}.";
        }

        /// <summary>
        ///     Creates the high Temperatures histogram.
        /// </summary>
        /// <returns>String representation of a histogram for High Temperatures</returns>
        private string createHighHistogram()
        {
            var lowest = this.WeatherInfoCollection.Min(temp => temp.HighTemp);
            var highest = this.WeatherInfoCollection.Max(temp => temp.HighTemp);
            var temps = this.WeatherInfoCollection.Select(temp => temp.HighTemp).ToList();

            if (lowest % 10 != 0)
            {
                lowest = lowest - lowest % 10;
            }

            if (highest % 10 != 0)
            {
                highest = highest + 10 - highest % 10;
            }

            var lowerBound = lowest;
            var output = $"High Temperature Histogram {Environment.NewLine}";
            while (lowerBound < highest)
            {
                var upperBound = lowerBound + 9;

                var count = temps.Count(temp => temp >= lowerBound && temp <= upperBound);
                output += $"{lowerBound}-{upperBound}: {count}{Environment.NewLine}";

                lowerBound = upperBound + 1;
            }

            return output;
        }

        /// <summary>
        ///     Creates the low temperature histogram.
        /// </summary>
        /// <returns>String Representation of the Low Temperature Histogram</returns>
        private string createLowHistogram()
        {
            var lowest = this.WeatherInfoCollection.Min(temp => temp.LowTemp);
            var highest = this.WeatherInfoCollection.Max(temp => temp.LowTemp);
            var temps = this.WeatherInfoCollection.Select(temp => temp.LowTemp).ToList();

            if (lowest % 10 != 0)
            {
                lowest = lowest - lowest % 10;
            }

            if (highest % 10 != 0)
            {
                highest = highest + 10 - highest % 10;
            }

            var lowerBound = lowest;
            var output = $"Low Temperature Histogram {Environment.NewLine}";
            while (lowerBound < highest)
            {
                var topBound = lowerBound + 9;
                var enumerable = temps.ToList();
                var count = enumerable.Count(temp => temp >= lowerBound && temp <= topBound);
                output += $"{lowerBound}-{topBound}: {count}{Environment.NewLine}";

                lowerBound = topBound + 1;
            }

            return output;
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