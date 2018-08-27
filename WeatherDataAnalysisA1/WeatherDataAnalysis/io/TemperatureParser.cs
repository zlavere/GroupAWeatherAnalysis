using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.io
{
    /// <summary>
    /// Parser for CSV set of Temperature Data where format is date, high, low.
    /// </summary>
    public class TemperatureParser
    {
        private List<string> TemperatureData { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureParser"/> class.
        /// </summary>
        /// <param name="temperatureData">The temperature data.</param>
        public TemperatureParser(List<string> temperatureData)
        {
            this.TemperatureData = temperatureData;
        }

        public List<DayTemperature> GetAllHighLowTempData()
        {
            var data = new List<DayTemperature>();

            var formats = new string[] { "MM/dd/yyyy", "M/d/yyyy","M/dd/yyyy", "MM/d/yyyy"};

            foreach (var currentDateData in this.TemperatureData)
            {
                var splitData = currentDateData.Split(',');
                var date = DateTime.ParseExact(splitData[0], "M/d/yyyy", CultureInfo.InvariantCulture);
                var highTemp = int.Parse(splitData[1]);
                var lowTemp = int.Parse(splitData[2]);
           
                data.Add(new DayTemperature(date, highTemp, lowTemp));
            }
            return data;
        }

        
    }
}
