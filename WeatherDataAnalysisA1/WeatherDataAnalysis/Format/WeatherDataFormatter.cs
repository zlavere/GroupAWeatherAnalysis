using System;
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
        public string FormatAverageHighTemperature(WeatherCollection weatherCollection)
        {
            return $"Average High Temp: {Math.Round(weatherCollection.GetAverageHighTemp(), 2)}";
        }

        /// <summary>
        /// Formats the average low temperature.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of Average Low temperature</returns>
        public string FormatAverageLowTemperature(WeatherCollection weatherCollection)
        {
            return $"Average Low Temp: {Math.Round(weatherCollection.GetAverageLowTemp(), 2)}";
        }


        //TODO Find a way to refactor these to avoid suspect code reuse.
        /// <summary>
        /// Formats the highest temps.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of highest temp data.</returns>
        public string FormatHighestTemps(WeatherCollection weatherCollection)
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
        public string FormatLowestTemps(WeatherCollection weatherCollection)
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
        public string FormatLowestHighTemps(WeatherCollection weatherCollection)
        {
            var lowestHighTempsList = weatherCollection.GetLowestHighTemps();

            var lowestHighTemps = $"The lowest high temperature was: {lowestHighTempsList[0].HighTemp}" +
                              Environment.NewLine +
                              "Date(s) with lowest high temperature: " + Environment.NewLine;

            foreach (var current in lowestHighTempsList)
            {
                while (current != lowestHighTempsList.Last())
                {
                    lowestHighTemps += $"{current.Date.ToShortDateString()}," + Environment.NewLine;
                }

                lowestHighTemps += $"{current.Date.ToShortDateString()}";
            }
            return lowestHighTemps;
        }

        /// <summary>
        /// Formats the highest low temps.
        /// BROKEN! WHY!?
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        /// <returns>String representation of highest low temp data.</returns>
        //TODO FIGURE OUT WHY THIS IS BROKEN!
        public string FormatHighestLowTemps(WeatherCollection weatherCollection)
        {
            var highestLowTempsList = weatherCollection.GetHighestLowTemps();

            var highestLowTemps = $"The lowest high temperature was: {highestLowTempsList[0].LowTemp}" +
                                  Environment.NewLine +
                                  "Date(s) with lowest high temperature: " + Environment.NewLine;

            foreach (var current in highestLowTempsList)
            {
                while (current != highestLowTempsList.Last())
                {
                    Console.WriteLine(current.LowTemp);
                    highestLowTemps += $"{current.Date.ToShortDateString()}," + Environment.NewLine;
                }

                highestLowTemps += $"{current.Date.ToShortDateString()}";
            }
            return highestLowTemps;
        }


        #endregion
    }
}