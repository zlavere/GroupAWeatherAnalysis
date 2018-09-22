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
        public WeatherInfoCollection WeatherInfoCollection { get; set; }
        private const int TwoPointFloatPrecision = 2;


        #region Methods

        /// <summary>
        /// Formats the average high temperature.
        /// </summary>
        /// <returns></returns>
        public string FormatAverageHighTemperature()
        {
            return
                $"Average High Temp: {Math.Round(this.WeatherInfoCollection.GetAverageHigh(), TwoPointFloatPrecision)}";
        }

        /// <summary>
        /// Formats the average low temperature.
        /// </summary>
        /// <returns>String representation of Average Low temperature</returns>
        public string FormatAverageLowTemperature()
        {
            return
                $"Average Low Temp: {Math.Round(this.WeatherInfoCollection.GetAverageLow(), TwoPointFloatPrecision)}";
        }

        //TODO Find a way to refactor these to avoid suspect code reuse.
        /// <summary>
        /// Formats the highest temps.
        /// </summary>
        /// <returns>String representation of highest temp data.</returns>
        public string FormatHighestTemps()
        {
            var weatherInfosWithHighestTemp = this.WeatherInfoCollection.FindWithHighest();
            var highestTemp = weatherInfosWithHighestTemp.First().HighTemp;
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
            var lowestTempsList = this.WeatherInfoCollection.GetLowestTemps();

            var lowestTemps = $"The lowest temperature was: {lowestTempsList.First().LowTemp}" +
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
            var lowestHighTempsList = this.WeatherInfoCollection.GetLowestHighTemps();

            var lowestHighTemps = $"The lowest high temperature was: {lowestHighTempsList.First().HighTemp}" +
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
            var highestLowTempsList = this.WeatherInfoCollection.FindWithHighestLow();
            var highestLow = highestLowTempsList.First().LowTemp;
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
        /// Formats the days above90.
        /// </summary>
        /// <returns>Formatted String for Days above 90</returns>
        public string FormatDaysAbove(int highTemp)
        {
            var daysAbove90List = this.WeatherInfoCollection.GetDaysAbove(highTemp);

            var daysAbove90 = "Date(s) with high above 90: " + Environment.NewLine;

            foreach (var current in daysAbove90List)
            {
                if (current != daysAbove90List.Last())
                {
                    daysAbove90 += $"{current.HighTemp} on {this.getDateString(current.Date)}" + Environment.NewLine;
                }
                else
                {
                    daysAbove90 += $"{current.HighTemp} on {this.getDateString(current.Date)}";
                }
            }

            return daysAbove90;
        }

        /// <summary>
        /// Formats the days below32.
        /// </summary>
        /// <returns>String for dates that reached 32 or lower</returns>
        public string FormatDaysBelow(int lowTemp)
        {
            var daysBelow32List = this.WeatherInfoCollection.GetDaysBelow(lowTemp);

            var daysBelow32 = "Date(s) with low below 32: " + Environment.NewLine;

            foreach (var current in daysBelow32List)
            {
                if (current != daysBelow32List.Last())
                {
                    daysBelow32 += $"{current.LowTemp} on {this.getDateString(current.Date)}" + Environment.NewLine;
                }
                else
                {
                    daysBelow32 += $"{current.LowTemp} on {this.getDateString(current.Date)}";
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
        /// Formats the low per month.
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
        /// Formats the low average per month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns>String for Average Low in given month.</returns>
        public string FormatLowAveragePerMonth(int month)
        {
            return
                $"The average average low in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(this.WeatherInfoCollection.GetLowAverageForMonth(month), TwoPointFloatPrecision)}.";
        }

        /// <summary>
        /// Formats the high average per month.
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
            var ordinalDay = string.Empty;
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