using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using WeatherDataAnalysis.Format;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.IO;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Model.Enums;
using WeatherDataAnalysis.View;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Controller
{
    /// <summary>
    ///     Controller for the Import processes.
    /// </summary>
    public class MainPageController //TODO This class should not be responsible for generating output.
    {
        #region Data members

        private DataFormatter DataFormatter { get; set; }

        #endregion

        #region Properties

        private StorageFile File { get; set; }
        private WeatherInfoCollectionsBinding WeatherInfoCollections { get; }
        private TemperatureDataFormatter TempFormatter { get; set; }
        private ICollection<string> Errors { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainPageController" /> class.
        /// </summary>
        public MainPageController()
        {
            this.WeatherInfoCollections = new WeatherInfoCollectionsBinding();
        }



        #endregion

        #region Methods

        /// <summary>
        /// Writes the active information to file.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public void WriteActiveInfoToFile(StorageFolder directory)
        {
            var output = new WriteWeatherDataToCsv();
            output.WriteActiveDataToCsv(directory);
        }

        /// <summary>
        /// Sets up TemperatureDataFormatter.
        /// </summary>
        public void SetUpFormatter()
        {
            if (this.DataFormatter == null)
            {
                this.DataFormatter = new DataFormatter();
                this.TempFormatter = this.DataFormatter.TemperatureDataFormatter;
            } 
        }

        /// <summary>
        /// Sets the size of the histogram bucket.
        /// </summary>
        /// <param name="size">The size.</param>
        public void SetHistogramBucketSize(int size)
        {
            this.SetUpFormatter();
            switch (size)
            {
                case 5:
                    HistogramSizeComboBoxBindings.ActiveSelection = 5;
                    break;
                case 10:
                    HistogramSizeComboBoxBindings.ActiveSelection = 10;
                    break;
                case 20:
                    HistogramSizeComboBoxBindings.ActiveSelection = 20;
                    break;
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
            if (this.File != null)
            {
                results += this.getErrorMessages();
            }
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
            if (this.File != null)
            {
                results += this.getErrorMessages();
            }
            return results;
        }

        private string getErrorMessages()
        {
            var result = $"{Environment.NewLine} The following errors occurred on import from {this.File.Name}:" +
                         $"{Environment.NewLine}";

            foreach (var current in this.Errors)
            {
                if (current != this.Errors.Last())
                {
                    result += $"{current}{Environment.NewLine}";
                }
                else
                {
                    result += current;
                }
            }

            return result;
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
            var newWeatherInfoCollection = temperatureParser.GetWeatherInfoCollection(importDialog.CollectionName, fileLines);

            if (importDialog.ImportType == ImportType.Merge && ActiveWeatherInfoCollection.Active.Count > 0)
            {
                newWeatherInfoCollection = await this.performMergeTypeImportAsync(newWeatherInfoCollection);
            }
            else
            {
                this.WeatherInfoCollections.Add(importDialog.CollectionName, newWeatherInfoCollection);
                ActiveWeatherInfoCollection.Active = newWeatherInfoCollection;
            }

            this.clearAndAddErrorMessages(temperatureParser);

            return newWeatherInfoCollection;
        }

        private void clearAndAddErrorMessages(TemperatureParser temperatureParser)
        {
            if (this.Errors == null)
            {
                this.Errors = new List<string>();
            }
            else
            {
                this.Errors.Clear();
            }
            
            foreach (var current in temperatureParser.ErrorMessages)
            {
                this.Errors.Add(current);
            }
        }

        private async Task<WeatherInfoCollection> performMergeTypeImportAsync(WeatherInfoCollection newWeatherInfoCollection)
        {
            var matchedDates = newWeatherInfoCollection.Where(weatherInfo =>
                ActiveWeatherInfoCollection.Active.Any(activeWeatherInfo => activeWeatherInfo.Date == weatherInfo.Date));
            var unmatchedDates = newWeatherInfoCollection.Where(weatherInfo =>
                ActiveWeatherInfoCollection.Active.All(activeWeatherInfo =>
                    activeWeatherInfo.Date != weatherInfo.Date));

            await this.requestUserMergePreference(matchedDates);

            foreach (var current in unmatchedDates)
            {
                ActiveWeatherInfoCollection.Active.Add(current);
            }
            return ActiveWeatherInfoCollection.Active;
        }

        private async Task<bool> requestUserMergePreference(IEnumerable<WeatherInfo> matchedDates)
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

                var data = new[] {
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
            //TODO This is why import should not be responsible for building output. Remove this if-statement and move building output to the output classes
            this.SetUpFormatter();
            this.TempFormatter.HighTempThreshold = highTemp;
        }

        /// <summary>
        /// Sets the low temperature threshold.
        /// </summary>
        /// <param name="lowTemp">The low temperature.</param>
        public void SetLowTempThreshold(int lowTemp)
        {
            
            this.TempFormatter.LowTempThreshold = lowTemp;
        }

        /// <summary>
        /// Sets the month to run analysis on.
        /// </summary>
        /// <param name="month">The month.</param>
        public void SetMonth(int month)
        {
            this.TempFormatter.Month = month;
        }

        #endregion
    }
}