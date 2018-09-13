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
        private readonly WeatherInfoCollection weatherInfoCollection;
        private const int TwoPointFloatPrecision = 2;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureDataFormatter"/> class.
        /// </summary>
        /// <param name="weatherInfoCollection">The WeatherInfoCollection.</param>
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
            var weatherInfosWithHighestTemp = this.weatherInfoCollection.GetHighestTemps();
            var highestTemp = weatherInfosWithHighestTemp[0].HighTemp;
            var highestTemps = $"The highest temperature was: {highestTemp}" +
                               Environment.NewLine +
                               "Date(s) with highest temperature: " + Environment.NewLine;

            foreach (var current in weatherInfosWithHighestTemp)
            {
                if (current != weatherInfosWithHighestTemp.Last())
                {
                    highestTemps += $"{this.getDateString(current.Date)}," + Environment.NewLine;
                }
                else
                {
                    highestTemps += $"{this.getDateString(current.Date)}";
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
                    lowestTemps += $"{this.getDateString(current.Date)}," + Environment.NewLine;
                }
                else
                {
                    lowestTemps += $"{this.getDateString(current.Date)}";
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
                    lowestHighTemps += $"{this.getDateString(current.Date)}," + Environment.NewLine;
                }
                else
                {
                    lowestHighTemps += $"{this.getDateString(current.Date)}";
                }
            }

            return lowestHighTemps;
        }

        /// <summary>
        /// Formats the highest low temps.
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
                    highestLowTemps += $"{this.getDateString(current.Date)}" + Environment.NewLine;
                }

                else
                {
                    highestLowTemps += $"{this.getDateString(current.Date)}";
                }
            }

            return highestLowTemps;
        }

        /// <summary>
        /// Formats string for GUI for the days above given temperature.
        /// </summary>
        /// <param name="temp">The temperature that WeatherInfos HighTemp must be above.</param>
        /// <returns>Formatted string for GUI with information about days above given temp</returns>
        public string FormatDaysAbove(int temp)
        {
            var weatherInfos = this.weatherInfoCollection.FindDaysAbove(90);

            var output = $"Date(s) with high above {temp}: " + Environment.NewLine;

            foreach (var current in weatherInfos)
            {
                if (current != weatherInfos.Last())
                {
                    output += $"{current.HighTemp} on {this.getDateString(current.Date)}" + Environment.NewLine;
                }
                else
                {
                    output += $"{current.HighTemp} on {this.getDateString(current.Date)}";
                }
            }

            return output;
        }

        /// <summary>
        /// Formats string for GUI for the days below given temperature.
        /// </summary>
        /// <param name="temp">The temperature that WeatherInfos LowTemp must be below.</param>
        /// <returns>Formatted string for GUI with information about days below given temp</returns>
        public string FormatDaysBelow(int temp)
        {
            var weatherInfos = this.weatherInfoCollection.FindDaysBelow(temp);

            var output = $"Date(s) with low below {temp}: " + Environment.NewLine;

            foreach (var current in weatherInfos)
            {
                if (current != weatherInfos.Last())
                {
                    output += $"{current.LowTemp} on {this.getDateString(current.Date)}" + Environment.NewLine;
                }
                else
                {
                    output += $"{current.LowTemp} on {this.getDateString(current.Date)}";
                }
            }

            return output;
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
        /// Formats the low per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>Formatted string for given month with date(s) reaching lowest temperature</returns>
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
        /// Formats the low average per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>Formatted string for average low temperature in given month</returns>
        public string FormatLowAveragePerMonth(int month)
        {
            return
                $"The average average low in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(this.weatherInfoCollection.GetLowAverageForMonth(month), TwoPointFloatPrecision)}.";
        }

        /// <summary>
        /// Formats the high average per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>Formatted string for average high temperature in given month</returns>
        public string FormatHighAveragePerMonth(int month)
        {
            return
                $"The average average high in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(this.weatherInfoCollection.GetHighAverageForMonth(month), TwoPointFloatPrecision)}.";
        }

        private string getDateString(DateTime date)
        {
            var month = DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
            var ordinalDay = this.getOrdinal(date.Day);
            return $"{month} {ordinalDay}, {date.Year}";
        }

        private string getOrdinal(int day)
        {
            var ordinalDay = string.Empty; //BUG Resharper claims this is not used in any path
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