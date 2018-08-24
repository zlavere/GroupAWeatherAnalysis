using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    /// High and low teperature data for a specific day
    /// </summary>
    public class DayTemperature
    {

        #region Properties
        /// <summary>
        /// Gets or sets the high temperature.
        /// </summary>
        /// <value>
        /// The high temperature.
        /// </value>
        public int HighTemp { get; set; }
        /// <summary>
        /// Gets or sets the low temperature.
        /// </summary>
        /// <value>
        /// The low temporary.
        /// </value>
        public int LowTemp { get; set; }
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lowTemp"></param>
        /// <param name="highTemp"></param>
        public DayTemperature(DateTime date, int lowTemp, int highTemp)
        {
            this.Date = date;
            this.LowTemp = lowTemp;
            this.HighTemp = highTemp;
        }
        #endregion


        /// <summary>
        /// Gets the difference between high low.
        /// </summary>
        /// <returns>the difference between high low temperature</returns>
        public int GetDifferenceHighLow()
        {
            return this.HighTemp - this.LowTemp;
        }

    }
}
