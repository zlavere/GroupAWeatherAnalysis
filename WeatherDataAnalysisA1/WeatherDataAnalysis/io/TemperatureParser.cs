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
        /// <summary>
        /// Gets the day temperature list.
        /// </summary>
        /// <param name="tempList">The temporary list.</param>
        /// <returns></returns>
        public List<Weather> GetWeatherList(IList<string> tempList)
        {
            //TODO Change this to GetWeatherCollection returns WeatherCollection
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
