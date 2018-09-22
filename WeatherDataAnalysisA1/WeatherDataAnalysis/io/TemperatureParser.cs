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
        private const int DateSegment = 0;
        private const int HighTempSegment = 1;
        private const int LowTempSegment = 2;

        #region Methods
        /// <summary>
        ///     Gets the day temperature list.
        /// </summary>
        /// <param name="tempList">The temporary list.</param>
        /// <returns></returns>
        public WeatherInfoCollection GetWeatherInfoCollection(IList<string> weatherList)
        {
            var data = new List<WeatherInfo>();
            foreach (var currentDateData in weatherList)
            {
                var splitData = currentDateData.Split(',');
                var date = DateTime.ParseExact(splitData[DateSegment], "M/d/yyyy", CultureInfo.InvariantCulture);
                var highTemp = int.Parse(splitData[HighTempSegment]);
                var lowTemp = int.Parse(splitData[LowTempSegment]);

                data.Add(new WeatherInfo(date, highTemp, lowTemp));
            }

            return new WeatherInfoCollection(data);
        }

        #endregion
    }
}