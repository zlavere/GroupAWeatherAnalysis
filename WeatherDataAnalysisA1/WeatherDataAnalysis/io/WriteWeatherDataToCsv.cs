﻿using System;
using System.Collections.Generic;
using Windows.Storage;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.IO
{
    /// <summary>
    ///     Writes Weather Data to a CSV file to save data.
    /// </summary>
    public class WriteWeatherDataToCsv
    {
        #region Data members

        #region Fields

        private StorageFolder directory;

        #endregion

        #endregion

        #region Methods

        /// <summary>
        ///     Writes the active data to CSV.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public async void WriteActiveDataToCsv(StorageFolder directory)
        {
            this.directory = directory;
            var file = await this.directory.CreateFileAsync($"{ActiveWeatherInfoCollection.Active.Name}.csv",
                CreationCollisionOption.GenerateUniqueName);
            await FileIO.WriteLinesAsync(file, this.getSeparatedWeatherInfo());
        }

        private IEnumerable<string> getSeparatedWeatherInfo()
        {
            var commaSeparatedData = new List<string>();
            foreach (var current in ActiveWeatherInfoCollection.Active)
            {
                if (current.Precipitation != null)
                {
                    commaSeparatedData.Add(
                        $"{current.Date.Month}/{current.Date.Day}/{current.Date.Year},{current.HighTemp},{current.LowTemp},{current.Precipitation}");
                }
                else
                {
                    commaSeparatedData.Add(
                        $"{current.Date.Month}/{current.Date.Day}/{current.Date.Year},{current.HighTemp},{current.LowTemp}");
                }
            }

            return commaSeparatedData;
        }

        #endregion
    }
}