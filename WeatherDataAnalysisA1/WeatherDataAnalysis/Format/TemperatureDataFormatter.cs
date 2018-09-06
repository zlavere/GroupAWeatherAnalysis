using System;
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
        private WeatherInfoCollection weatherInfoCollection;
        const int TwoPointFloatPrecision = 2;

        public TemperatureDataFormatter(WeatherInfoCollection weatherInfoCollection)
        {
            this.weatherInfoCollection = weatherInfoCollection;
        }

        #region Methods

        /// <summary>
        /// Formats the average high temperature.
        /// </summary>
        /// <returns></returns>
        public string FormatAverageHighTemperature()
        {
            return
                $"Average High Temp: {Math.Round(this.weatherInfoCollection.GetAverageHighTemp(), TwoPointFloatPrecision)}";
        }

        /// <summary>
        /// Formats the average low temperature.
        /// </summary>
        /// <returns>String representation of Average Low temperature</returns>
        public string FormatAverageLowTemperature()
        {
            return
                $"Average Low Temp: {Math.Round(this.weatherInfoCollection.GetAverageLowTemp(), TwoPointFloatPrecision)}";
        }

        //TODO Find a way to refactor these to avoid suspect code reuse.
        /// <summary>
        /// Formats the highest temps.
        /// </summary>
        /// <returns>String representation of highest temp data.</returns>
        public string FormatHighestTemps()
        {
            var highestTempsList = this.weatherInfoCollection.GetHighestTemps();
            var highestTemps = $"The highest temperature was: {highestTempsList[0].HighTemp}" +
                               Environment.NewLine +
                               "Date(s) with highest temperature: " + Environment.NewLine;

            foreach (var current in highestTempsList)
            {
                if (current != highestTempsList.Last())
                {
                    highestTemps += $"{current.Date.ToShortDateString()}," + Environment.NewLine;
                }
                else
                {
                    highestTemps += $"{current.Date.ToShortDateString()}";
                }
            }

            return highestTemps;
        }

        /// <summary>
        /// Formats the lowest temps.
        /// </summary>
        /// <returns>String representation of lowest temp data.</returns>
        public string FormatLowestTemps()
        {
            var lowestTempsList = this.weatherInfoCollection.GetLowestTemps();

            var lowestTemps = $"The lowest temperature was: {lowestTempsList[0].LowTemp}" +
                              Environment.NewLine +
                              "Date(s) with lowest temperature: " + Environment.NewLine;

            foreach (var current in lowestTempsList)
            {
                if (current != lowestTempsList.Last())
                {
                    lowestTemps += $"{current.Date.ToShortDateString()}," + Environment.NewLine;
                }
                else
                {
                    lowestTemps += $"{current.Date.ToShortDateString()}";
                }
            }

            return lowestTemps;
        }

        /// <summary>
        /// Formats the lowest high temps.
        /// </summary>
        /// <returns>String representation of lowest high temp data.</returns>
        public string FormatLowestHighTemps()
        {
            var lowestHighTempsList = this.weatherInfoCollection.GetLowestHighTemps();

            var lowestHighTemps = $"The lowest high temperature was: {lowestHighTempsList[0].HighTemp}" +
                                  Environment.NewLine +
                                  "Date(s) with lowest high temperature: " + Environment.NewLine;

            foreach (var current in lowestHighTempsList)
            {
                if (current != lowestHighTempsList.Last())
                {
                    lowestHighTemps += $"{current.Date.ToShortDateString()}," + Environment.NewLine;
                }
                else
                {
                    lowestHighTemps += $"{current.Date.ToShortDateString()}";
                }
            }

            return lowestHighTemps;
        }

        /// <summary>
        /// Formats the highest low temps.
        /// BROKEN! WHY!?
        /// </summary>
        /// <returns>String representation of highest low temp data.</returns>
        public string FormatHighestLowTemps()
        {
            var highestLowTempsList = this.weatherInfoCollection.GetHighestLowTemps();
            var highestLow = highestLowTempsList[0].LowTemp;
            var highestLowTemps = $"The highest low temperature was: {highestLow}" +
                                  Environment.NewLine +
                                  "Date(s) with lowest high temperature: " + Environment.NewLine;

            foreach (var current in highestLowTempsList)
            {
                if (current != highestLowTempsList.Last())
                {
                    highestLowTemps += $"{current.Date.ToShortDateString()}" + Environment.NewLine;
                }
                else
                {
                    highestLowTemps += $"{current.Date.ToShortDateString()}";
                }
            }

            return highestLowTemps;
        }

        public string FormatDaysAbove90()
        {
            var daysAbove90List = this.weatherInfoCollection.GetDaysAbove90();

            var daysAbove90 = "Date(s) with high above 90: " + Environment.NewLine;

            foreach (var current in daysAbove90List)
            {
                if (current != daysAbove90List.Last())
                {
                    daysAbove90 += $"{current.HighTemp} on {current.Date.ToShortDateString()}" + Environment.NewLine;
                }
                else
                {
                    daysAbove90 += $"{current.HighTemp} on {current.Date.ToShortDateString()}";
                }
            }

            return daysAbove90;
        }

        public string FormatDaysBelow32()
        {
            var daysBelow32List = this.weatherInfoCollection.GetDaysBelow32();

            var daysBelow32 = "Date(s) with low below 32: " + Environment.NewLine;

            foreach (var current in daysBelow32List)
            {
                if (current != daysBelow32List.Last())
                {
                    daysBelow32 += $"{current.LowTemp} on {current.Date.ToShortDateString()}" + Environment.NewLine;
                }
                else
                {
                    daysBelow32 += $"{current.LowTemp} on {current.Date.ToShortDateString()}";
                }
            }

            return daysBelow32;
        }

        /// <summary>
        /// Formats the high per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>Returns a string formatted for GUI of highest temperature for the month and date(s) it occurred on.</returns>
        public string FormatHighPerMonth(int month)
        {
            var highestInMonthList = this.weatherInfoCollection.GetHighestInMonth(month);
            var highestInMonth =
                $"Date(s) with the highest temperature of {highestInMonthList[0].HighTemp} in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} {highestInMonthList[0].Date.Year}:"
                + Environment.NewLine;

            foreach (var current in highestInMonthList)
            {
                if (current != highestInMonthList.Last())
                {
                    highestInMonth += $"{current.Date.ToShortDateString()}" + Environment.NewLine;
                }
                else
                {
                    highestInMonth += $"{current.Date.ToShortDateString()}";
                }
            }

            return highestInMonth;
        }

        public string FormatLowPerMonth(int month)
        {
            var lowestInMonthList = this.weatherInfoCollection.GetLowestInMonth(month);
            var lowestInMonth =
                $"Date(s) with the Lowest temperature of {lowestInMonthList[0].HighTemp} in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} {lowestInMonthList[0].Date.Year}:"
                + Environment.NewLine;

            foreach (var current in lowestInMonthList)
            {
                if (current != lowestInMonthList.Last())
                {
                    lowestInMonth += $"{current.Date.ToShortDateString()}" + Environment.NewLine;
                }
                else
                {
                    lowestInMonth += $"{current.Date.ToShortDateString()}";
                }
            }

            return lowestInMonth;
        }

        public string FormatLowAveragePerMonth(int month)
        {
            return
                $"The average average low in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(this.weatherInfoCollection.GetLowAverageForMonth(month), TwoPointFloatPrecision)}.";
        }

        public string FormatHighAveragePerMonth(int month)
        {
            return
                $"The average average high in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(this.weatherInfoCollection.GetHighAverageForMonth(month), TwoPointFloatPrecision)}.";
        }

        #endregion
    }
}