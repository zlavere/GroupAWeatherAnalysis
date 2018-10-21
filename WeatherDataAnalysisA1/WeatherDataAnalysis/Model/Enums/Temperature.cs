using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAnalysis.Model.Enums
{
    /// <summary>
    /// Enum for important temperature values.
    /// </summary>
    public enum Temperature
    {
        /// <summary>
        /// The freezing point fahrenheit
        /// </summary>
        FreezingFahrenheit = 32,

        /// <summary>
        /// The high temperature warning threshold
        /// </summary>
        HighWarningThreshold = 90
    }
}
