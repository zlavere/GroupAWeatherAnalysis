using System;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     High and low temperature data for a specific day
    /// </summary>
    public class TemperatureByDay
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the high temperature.
        /// </summary>
        /// <value>
        ///     The high temperature.
        /// </value>
        public int HighTemp { get; }

        /// <summary>
        ///     Gets or sets the low temperature.
        /// </summary>
        /// <value>
        ///     The low temporary.
        /// </value>
        public int LowTemp { get; }

        /// <summary>
        ///     Gets or sets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemperatureByDay" /> class.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="highTemp">The high temporary.</param>
        /// <param name="lowTemp">The low temporary.</param>
        public TemperatureByDay(DateTime date, int highTemp, int lowTemp)
        {
            this.Date = date;
            this.LowTemp = lowTemp;
            this.HighTemp = highTemp;
        }

        #endregion
    }
}