using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Format
{
    /// <summary>
    /// Formats Temperature Data
    /// </summary>
    public class TemperatureDataFormatter
    {
        /// <summary>
        /// Formats the string.
        /// </summary>
        /// <param name="dayTemp">The data for the temperature on specified date.</param>
        /// <returns>Formatted for simple display.</returns>
        public string FormatSimpleString(Weather dayTemp)
        {
            return $"Date: {dayTemp.Date.ToShortDateString()} High: {dayTemp.HighTemp} Low: {dayTemp.LowTemp}";
        }
    }
}
