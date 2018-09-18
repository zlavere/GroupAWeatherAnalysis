using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataAnalysis.Format;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    /// All Formatters for WeatherInfo
    /// </summary>
    public class DataFormatter
    {
        /// <summary>
        /// Gets or sets the temperature data formatter.
        /// </summary>
        /// <value>
        /// The temperature data formatter.
        /// </value>
        public TemperatureDataFormatter TemperatureDataFormatter { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataFormatter"/> class.
        /// </summary>
        public DataFormatter()
        {
            this.TemperatureDataFormatter = new TemperatureDataFormatter();
        }
    }
}
