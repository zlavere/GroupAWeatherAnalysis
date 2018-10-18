using System;
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
    public class Import
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

        private FileOpenPicker FilePicker { get; set; }
        private StorageFile File { get; set; }
        private ImportDialog ImportDialog { get; set; }
        private ContentDialogResult ImportDialogResults { get; set; }
        private WeatherInfoCollectionsBinding WeatherInfoCollections { get; }
        private TemperatureDataFormatter TempFormatter { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Import" /> class.
        /// </summary>
        public Import()
        {
            this.WeatherInfoCollections = new WeatherInfoCollectionsBinding();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Import" /> class.
        /// </summary>
        /// <param name="type">The type of import process to execute.</param>
        public Import(ImportType type) : this()
        {
            this.Type = type;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Executes the import.
        /// </summary>
        /// <returns>True if new WeatherInfoCollection is added.</returns>
        public async Task<bool> ExecuteImport()
        {
            var executionSuccess = false;

            this.FilePicker = this.createNewFileOpenPicker();
            this.File = await this.FilePicker.PickSingleFileAsync();
            this.ImportDialog = new ImportDialog();
            this.ImportDialogResults = await this.ImportDialog.ShowAsync();

            if (this.File != null)
            {
                await this.createNewFromFile();
                this.setUpFormatter();
                executionSuccess = true;
            }

            return executionSuccess;
        }

        private void setUpFormatter()
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

        private FileOpenPicker createNewFileOpenPicker()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".csv");
            filePicker.FileTypeFilter.Add(".txt");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            return filePicker;
        }

        //TODO IDictionary<> to create a map of data elements multi-select checkbox. User input, checkboxes for analytic functions to run.
        private string loadTemperaturesByYear()
        {
            
            this.TempFormatter.WeatherInfoCollection = ActiveWeatherInfoCollection.Active;

            var output = this.TempFormatter.GetOutput();
            output += $"{this.TempFormatter.HighTempThreshold} {Environment.NewLine}";
            output += $"{this.TempFormatter.LowTempThreshold} {Environment.NewLine}";
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

        private async Task<WeatherInfoCollection> createNewFromFile()
        {
            var csvFileReader = new CsvReader();
            var temperatureParser = new TemperatureParser();
            var fileLines = await csvFileReader.GetFileLines(this.File);
            var newWeatherInfoCollection =
                temperatureParser.GetWeatherInfoCollection(this.ImportDialog.CollectionName, fileLines);
            this.WeatherInfoCollections.Add(this.ImportDialog.CollectionName, newWeatherInfoCollection);
            ActiveWeatherInfoCollection.Active = newWeatherInfoCollection;
            return newWeatherInfoCollection;
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