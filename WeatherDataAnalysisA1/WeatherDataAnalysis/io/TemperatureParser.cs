using System;
using System.Collections.Generic;
using System.Globalization;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.io
{
    /// <summary>
    ///     Parser for CSV set of Temperature Data where format is date, high, low.
    /// </summary>
    public class TemperatureParser
    {
        #region Methods

        /// <summary>
        ///     Gets the day temperature list.
        /// </summary>
        /// <param name="tempList">The temporary list.</param>
        /// <returns></returns>
        public static List<WeatherInfo> GetWeatherList(IList<string> tempList)
        {
            var data = new List<WeatherInfo>();

            foreach (var currentDateData in tempList)
            {
                var splitData = currentDateData.Split(',');
                var date = DateTime.ParseExact(splitData[0], "M/d/yyyy", CultureInfo.InvariantCulture);
                var highTemp = int.Parse(splitData[1]);
                var lowTemp = int.Parse(splitData[2]);

                data.Add(new WeatherInfo(date, highTemp, lowTemp));
            }

            return data;
        }

        #endregion
    }
}