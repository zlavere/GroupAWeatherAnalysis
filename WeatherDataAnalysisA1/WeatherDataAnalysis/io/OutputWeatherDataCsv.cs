using System;
using System.Collections.Generic;
using Windows.Storage;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.IO
{
    /// <summary>
    /// Writes Weather Data to a CSV file to save data.
    /// </summary>
    public class OutputWeatherDataCsv
    {
        #region Properties

        private StorageFolder Directory { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Writes the active data to CSV.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public async void WriteActiveDataToCsv(StorageFolder directory)
        {
            this.Directory = directory;
            var file = await this.Directory.CreateFileAsync($"{ActiveWeatherInfoCollection.Active.Name}.csv",
                CreationCollisionOption.GenerateUniqueName);
            await FileIO.WriteLinesAsync(file, this.getSeparatedWeatherInfo());
        }

        private IEnumerable<string> getSeparatedWeatherInfo()
        {
            var commaSeparatedData = new List<string>();
            foreach (var current in ActiveWeatherInfoCollection.Active)
            {
                commaSeparatedData.Add(
                    $"{current.Date.Month}/{current.Date.Day}/{current.Date.Year},{current.HighTemp},{current.LowTemp}");
            }

            return commaSeparatedData;
        }

        #endregion
    }
}