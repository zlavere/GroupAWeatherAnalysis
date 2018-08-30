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
        /// Initializes a new instance of the <see cref="TemperatureParser" /> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public TemperatureParser()
        {
            //var dataFile = new WeatherDataInput(filePath);
        }

        /// <summary>
        /// Gets all high low temperature data.
        /// </summary>
        /// <returns></returns>
        public List<Weather> GetAllHighLowTempData()
        {
            var data = new List<Weather>();

            var formats = new string[] {"MM/dd/yyyy", "M/d/yyyy", "M/dd/yyyy", "MM/d/yyyy"};

            foreach (var currentDateData in this.TemperatureData)
            {
                var splitData = currentDateData.Split(',');
                var date = DateTime.ParseExact(splitData[0], "M/d/yyyy", CultureInfo.InvariantCulture);
                var highTemp = int.Parse(splitData[1]);
                var lowTemp = int.Parse(splitData[2]);

                data.Add(new Weather(date, highTemp, lowTemp));
            }

            return data;
        }


        public List<Weather> GetDayTemperatureList(IList<string> tempList)
        {
            var tempDataList = new List<Weather>();

            foreach (var currentDateData in tempList)
            {
                var splitData = currentDateData.Split(',');
                var date = DateTime.ParseExact(splitData[0], "M/d/yyyy", CultureInfo.InvariantCulture);
                var highTemp = int.Parse(splitData[1]);
                var lowTemp = int.Parse(splitData[2]);

                tempDataList.Add(new Weather(date, highTemp, lowTemp));

                
            }
            return tempDataList;
        }
    }

}
