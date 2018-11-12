﻿using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.View;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Controller
{
    /// <summary>
    ///     Controller for creating a single data point of weather information.
    /// </summary>
    public class AddWeatherInfo
    {
        #region Properties

        /// <summary>
        ///     Gets the created weather information.
        /// </summary>
        /// <value>
        ///     The created weather information.
        /// </value>
        public WeatherInfo CreatedWeatherInfo { get; private set; }

        private NewWeatherInfoDialog NewWeatherInfoDialog { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Starts the dialog to get user input from which new data will be added to the collection.
        /// </summary>
        /// <returns>Returns true if the data element is created successfully.</returns>
        public async Task<bool> StartDialog()
        {
            this.NewWeatherInfoDialog = new NewWeatherInfoDialog();
            var dialogResult = await this.NewWeatherInfoDialog.ShowDialog();
            

            if (dialogResult == NewWeatherInfoDialog.Submit)
            {
                this.CreatedWeatherInfo = new WeatherInfo(this.NewWeatherInfoDialog.Date,
                    this.NewWeatherInfoDialog.HighTemp, this.NewWeatherInfoDialog.LowTemp);
            }

            var isSuccessful = this.isCreatedWeatherInfoAdded();

            return isSuccessful;
        }

        private bool isCreatedWeatherInfoAdded()
        {
            var result = false;

            if (this.NewWeatherInfoDialog.IsOverwriteAllowed() && this.containsWeatherInfoWithSameDate())
            {
                var weatherInfoToReplace =
                    ActiveWeatherInfoCollection.Active.Where(weatherInfo =>
                        weatherInfo.Date ==
                        this.CreatedWeatherInfo
                            .Date); //Cannot be null ReSharper says it can.
                ActiveWeatherInfoCollection.Active.Remove(weatherInfoToReplace.First());
                this.addCreatedWeatherInfo();
                result = true;
            }

            if (!this.containsWeatherInfoWithSameDate())
            {
                this.addCreatedWeatherInfo();
                result = true;
            }

            Debug.WriteLine(result);
            return result;
        }

        private void addCreatedWeatherInfo()
        {
            ActiveWeatherInfoCollection.Active.Add(this.CreatedWeatherInfo);
        }

        private bool containsWeatherInfoWithSameDate()
        {
            return ActiveWeatherInfoCollection.Active.Any(weatherInfo =>
                weatherInfo.Date == this.CreatedWeatherInfo.Date);
        }

        #endregion
    }
}