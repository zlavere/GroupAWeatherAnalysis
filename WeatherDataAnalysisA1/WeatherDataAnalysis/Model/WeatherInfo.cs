using System;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Data class for Temperature and Precipitation on a specific date.
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
        public int HighTemp { get; set; }

        /// <summary>
        ///     Gets the low temperature.
        /// </summary>
        /// <value>
        ///     The low temperature.
        /// </value>
        public int LowTemp { get; set; }

        /// <summary>
        ///     Gets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        ///     Gets  or sets the precipitation.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public double Precipitation { get; set; }

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
        }

        /// <summary>Initializes a new instance of the <see cref="WeatherInfo" /> class.</summary>
        /// <param name="date">The date.</param>
        /// <param name="highTemp">The high temporary.</param>
        /// <param name="lowTemp">The low temporary.</param>
        /// <param name="precipitation">The measure of precipitation in inches.</param>
        /// <exception cref="System.ArgumentException">Precipitation can't be negative</exception>
        public WeatherInfo(DateTime date, int highTemp, int lowTemp, double precipitation)
            : this(date, highTemp, lowTemp)
        {
            if (precipitation < 0)
            {
                throw new ArgumentException("Precipitation can't be negative");
            }

            this.Date = date;
            this.LowTemp = lowTemp;
            this.HighTemp = highTemp;
            this.Precipitation = precipitation;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Compares to.
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