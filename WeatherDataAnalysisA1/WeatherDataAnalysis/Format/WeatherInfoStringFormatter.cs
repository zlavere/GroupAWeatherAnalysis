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
        #region Methods

        /// <summary>
        /// Formats the average high temperature.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns></returns>
        public string FormatAverageHighTemperature(WeatherInfoCollection weatherCollection)
        {
            return $"Average High Temp: {Math.Round(weatherCollection.GetAverageHighTemp(), 2)}";
        }

        /// <summary>
        /// Formats the average low temperature.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of Average Low temperature</returns>
        public string FormatAverageLowTemperature(WeatherInfoCollection weatherCollection)
        {
            return $"Average Low Temp: {Math.Round(weatherCollection.GetAverageLowTemp(), 2)}";
        }


        //TODO Find a way to refactor these to avoid suspect code reuse.
        /// <summary>
        /// Formats the highest temps.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of highest temp data.</returns>
        public string FormatHighestTemps(WeatherInfoCollection weatherCollection)
        {
            var highestTempsList = weatherCollection.GetHighestTemps();
            var highestTemps = $"The highest temperature was: {highestTempsList[0].HighTemp}" +
                               Environment.NewLine +
                               "Date(s) with highest temperature: " + Environment.NewLine;

            foreach (var current in highestTempsList)
            {
                while (current != highestTempsList.Last())
                {
                   highestTemps += $"{current.Date.ToShortDateString()}," + Environment.NewLine;
                }

                highestTemps += $"{current.Date.ToShortDateString()}";
            }
            return highestTemps;
        }

        /// <summary>
        /// Formats the lowest temps.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of lowest temp data.</returns>
        public string FormatLowestTemps(WeatherInfoCollection weatherCollection)
        {
            var lowestTempsList = weatherCollection.GetLowestTemps();

            var lowestTemps = $"The lowest temperature was: {lowestTempsList[0].LowTemp}" +
                               Environment.NewLine +
                               "Date(s) with lowest temperature: " + Environment.NewLine;

            foreach (var current in lowestTempsList)
            {
                while (current != lowestTempsList.Last())
                {
                    lowestTemps += $"{current.Date.ToShortDateString()}," + Environment.NewLine;
                }

                lowestTemps += $"{current.Date.ToShortDateString()}";
            }
            return lowestTemps;
        }

        /// <summary>
        /// Formats the lowest high temps.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of lowest high temp data.</returns>
        public string FormatLowestHighTemps(WeatherInfoCollection weatherCollection)
        {
            var lowestHighTempsList = weatherCollection.GetLowestHighTemps();

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
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of highest low temp data.</returns>
        public string FormatHighestLowTemps(WeatherInfoCollection weatherCollection)
        {
            var highestLowTempsList = weatherCollection.GetHighestLowTemps();

            var highestLowTemps = $"The lowest high temperature was: {highestLowTempsList[0].LowTemp}" +
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

        public string FormatDaysAbove90(WeatherInfoCollection weatherCollection)
        {
            var daysAbove90List = weatherCollection.GetDaysAbove90();

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

        public string FormatDaysBelow32(WeatherInfoCollection weatherCollection)
        {
            var daysBelow32List = weatherCollection.GetDaysBelow32();

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

        public string FormatHighPerMonth(WeatherInfoCollection weatherCollection, int month)
        {
            var highestInMonthList = weatherCollection.GetHighestInMonth(month);
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

        public string FormatLowPerMonth(WeatherInfoCollection weatherCollection, int month)
        {
            var lowestInMonthList = weatherCollection.GetLowestInMonth(month);
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

        public string FormatLowAveragePerMonth(WeatherInfoCollection weatherCollection, int month)
        {
           return $"The average average low in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(weatherCollection.GetLowAverageForMonth(month), 2)}.";
        }

        public string FormatHighAveragePerMonth(WeatherInfoCollection weatherCollection, int month)
        {
            return $"The average average high in {DateTimeFormatInfo.CurrentInfo.GetMonthName(month)} was {Math.Round(weatherCollection.GetHighAverageForMonth(month), 2)}.";
        }

        #endregion
    }
}