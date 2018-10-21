using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using WeatherDataAnalysis.Format;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Model.Enums;
using WeatherDataAnalysis.View;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Controller
{
    /// <summary>
    ///     Controller for the Import processes.
    /// </summary>
    public class ImportWeatherInfo
    {
        #region Data members

        private DataFormatter DataFormatter { get; set; }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        private ImportType Type { get; }
        private StorageFile File { get; set; }
        private WeatherInfoCollectionsBinding WeatherInfoCollections { get; }
        private TemperatureDataFormatter TempFormatter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImportWeatherInfo" /> class.
        /// </summary>
        public ImportWeatherInfo()
        {
            this.WeatherInfoCollections = new WeatherInfoCollectionsBinding();
        }

        #endregion

        #region Methods

        public void SetUpFormatter()
        {
            if (this.DataFormatter == null)
            {
                this.DataFormatter = new DataFormatter();
                this.TempFormatter = this.DataFormatter.TemperatureDataFormatter;
            } 
        }

        /// <summary>
        ///     Generates the output.
        /// </summary>
        /// <returns>Generates output for the Active WeatherInfoCollection</returns>
        public string GenerateOutput()
        {
            var results = ActiveWeatherInfoCollection.Active.Name + Environment.NewLine +
                          this.loadTemperaturesByYear();
            return results;
        }

        /// <summary>
        ///     Generates the output with additional analytic functions for month
        /// </summary>
        /// <param name="month">The month to analyze</param>
        /// <returns></returns>
        public string GenerateOutput(int month)
        {
            var results = this.GenerateOutput();
            results += this.loadTemperaturesByMonth(month);
            return results;
        }



        //TODO IDictionary<> to create a map of data elements multi-select checkbox. User input, checkboxes for analytic functions to run.
        private string loadTemperaturesByYear()
        {
            
            this.TempFormatter.WeatherInfoCollection = ActiveWeatherInfoCollection.Active;

            var output = this.TempFormatter.GetOutput();
            return output;
        }

        /// <summary>
        /// Loads the temperatures by month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        private string loadTemperaturesByMonth(int month)
        {
            

            this.TempFormatter.WeatherInfoCollection = ActiveWeatherInfoCollection.Active;
            var output = this.TempFormatter.FormatLowAveragePerMonth(month) + Environment.NewLine;
            output += this.TempFormatter.FormatHighAveragePerMonth(month) + Environment.NewLine;
            output += this.TempFormatter.FormatLowPerMonth(month) + Environment.NewLine;
            output += this.TempFormatter.FormatHighPerMonth(month) + Environment.NewLine;
            return output;
        }

        /// <summary>
        /// Creates the new WeatherInfoCollection from selected file asynchronously.
        /// </summary>
        /// <param name="file">The file selected by user.</param>
        /// <param name="importDialog">The import dialog.</param>
        /// <returns>Asynchronously returns a new WeatherInfoCollection from file data based on user selected preferences.</returns>
        public async Task<WeatherInfoCollection> CreateNewFromFile(StorageFile file, ImportDialog importDialog)
        {
            this.File = file;
            var csvFileReader = new CsvReader();
            var temperatureParser = new TemperatureParser();
            var fileLines = await csvFileReader.GetFileLines(this.File);
            var newWeatherInfoCollection = temperatureParser.GetWeatherInfoCollection(importDialog.CollectionName, fileLines); ;

            if (importDialog.ImportType == ImportType.Merge && ActiveWeatherInfoCollection.Active.Count > 0)
            {
                newWeatherInfoCollection = await this.performMergeTypeImportAsync(newWeatherInfoCollection);
            }
            else
            {
                this.WeatherInfoCollections.Add(importDialog.CollectionName, newWeatherInfoCollection);
                ActiveWeatherInfoCollection.Active = newWeatherInfoCollection;
            }

            return newWeatherInfoCollection;
        }

        private async Task<WeatherInfoCollection> performMergeTypeImportAsync(WeatherInfoCollection newWeatherInfoCollection)
        {
            var matchedDates = newWeatherInfoCollection.Where(weatherInfo =>
                ActiveWeatherInfoCollection.Active.Any(activeWeatherInfo => activeWeatherInfo.Date == weatherInfo.Date));
            var unmatchedDates = newWeatherInfoCollection.Where(weatherInfo =>
                ActiveWeatherInfoCollection.Active.All(activeWeatherInfo =>
                    activeWeatherInfo.Date != weatherInfo.Date));
            foreach (var current in unmatchedDates)
            {
                ActiveWeatherInfoCollection.Active.Add(current);
            }

            await this.RequestUserMergePreference(matchedDates);
            return ActiveWeatherInfoCollection.Active;
        }

        private async Task<bool> RequestUserMergePreference(IEnumerable<WeatherInfo> matchedDates)
        {
            //var mergeResult = new WeatherInfoCollection("Merge Result", new List<WeatherInfo>());
            foreach (var currentNew in matchedDates)
            {
                var matchingInfo = ActiveWeatherInfoCollection.Active.First(weatherInfo => weatherInfo.Date == currentNew.Date);
                var mergeMatchDialog = new MergeMatchDialog();
                var matchingInfoDate = matchingInfo.Date.ToShortDateString();
                var matchingInfoHigh = matchingInfo.HighTemp.ToString();
                var matchingInfoLow = matchingInfo.LowTemp.ToString();
                var currentNewDate = currentNew.Date.ToShortDateString();
                var currentNewHigh = currentNew.HighTemp.ToString();
                var currentNewLow = currentNew.LowTemp.ToString();

                var data = new string[] {
                    matchingInfoDate,
                    matchingInfoHigh,
                    matchingInfoLow,
                    currentNewDate,
                    currentNewHigh,
                    currentNewLow
                };
                
                var mergeMatchResult = await mergeMatchDialog.ShowDialog(data);
                if (mergeMatchResult == MergeMatchDialog.Replace)
                {

                    ActiveWeatherInfoCollection.Active.Remove(matchingInfo);
                    ActiveWeatherInfoCollection.Active.Add(currentNew);
                }
            }

            return true;
        }

        /// <summary>
        /// Sets the high temporary threshold.
        /// </summary>
        /// <param name="highTemp">The highTemp.</param>
        public void SetHighTempThreshold(int highTemp)
        {
            this.TempFormatter.HighTempThreshold = highTemp;
        }

        public void SetLowTempThreshold(int lowTemp)
        {
            this.TempFormatter.LowTempThreshold = lowTemp;
        }

        public void SetMonth(int month)
        {
            this.TempFormatter.Month = month;
        }

        #endregion
    }
}