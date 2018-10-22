using System;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     High and low temperature data for a specific day
    /// </summary>
    public class WeatherInfo : IComparable<WeatherInfo>
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
        ///     Gets the low temperature.
        /// </summary>
        /// <value>
        ///     The low temperature.
        /// </value>
        public int LowTemp { get; }

        /// <summary>
        ///     Gets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherInfo" /> class.
        /// </summary>
        /// <precondition>High Temp Must be >= lowTemp</precondition>
        /// <precondition>Date Must be on or before today.</precondition>
        /// <param name="date">The date.</param>
        /// <param name="highTemp">The high temperature.</param>
        /// <param name="lowTemp">The low temperature.</param>
        public WeatherInfo(DateTime date, int highTemp, int lowTemp)
        {
            if (highTemp < lowTemp)
            {
                throw new ArgumentException("highTemp must be >= lowTemp.");
            }

            if (date > DateTime.Today)
            {
                throw new ArgumentException("Date must be on or before Today.");
            }
            this.Date = date;
            this.LowTemp = lowTemp;
            this.HighTemp = highTemp;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public int CompareTo(WeatherInfo other)
        {
            return this.Date.CompareTo(other.Date);
        }

        #endregion
    }
}