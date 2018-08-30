using System;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    /// High and low temperature data for a specific day
    /// </summary>
    public class Weather
    {
        #region Properties
        /// <summary>
        /// Gets or sets the high temperature.
        /// </summary>
        /// <value>
        /// The high temperature.
        /// </value>
        public int HighTemp { get; }
        
        /// <summary>
        /// Gets or sets the low temperature.
        /// </summary>
        /// <value>
        /// The low temporary.
        /// </value>
        public int LowTemp { get; }        
        
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; }
        #endregion
        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lowTemp"></param>
        /// <param name="highTemp"></param>
        public Weather(DateTime date, int highTemp, int lowTemp)
        {
            this.Date = date;
            this.LowTemp = lowTemp;
            this.HighTemp = highTemp;
        }
        #endregion

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public string ToString()
        {
            return $"Date = {this.Date} High = {this.HighTemp} Low = {this.LowTemp}";
        }
    }
}
