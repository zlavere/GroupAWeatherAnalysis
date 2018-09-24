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

        private readonly DataFormatter dataFormatter;

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

        /// <summary>
        /// Gets the temporary formatter.
        /// </summary>
        /// <value>
        /// The temporary formatter.
        /// </value>
        private TemperatureDataFormatter tempFormatter { get;  }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Import" /> class.
        /// </summary>
        public Import()
        {
            this.WeatherInfoCollections = new WeatherInfoCollectionsBinding();
            this.dataFormatter = new DataFormatter();
            this.tempFormatter = this.dataFormatter.TemperatureDataFormatter;
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

            if (this.ImportDialogResults == ContentDialogResult.Secondary)
            {
                executionSuccess = false;
            }

            if (this.File != null)
            {
                await this.createNewFromFile();
                executionSuccess = true;
            }

            return executionSuccess;
        }

        /// <summary>
        ///     Generates the output.
        /// </summary>
        /// <returns>Generates output for the Active WeatherInfoCollection</returns>
        public string GenerateOutput()
        {
            var results = this.WeatherInfoCollections.Active.Name + Environment.NewLine +
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
            
            this.tempFormatter.WeatherInfoCollection = this.WeatherInfoCollections.Active;

            var output = this.tempFormatter.GetOutput();
            return output;
        }

        /// <summary>
        /// Loads the temperatures by month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        private string loadTemperaturesByMonth(int month)
        {
            

            this.tempFormatter.WeatherInfoCollection = this.WeatherInfoCollections.Active;
            var output = this.tempFormatter.FormatLowAveragePerMonth(month) + Environment.NewLine;
            output += this.tempFormatter.FormatHighAveragePerMonth(month) + Environment.NewLine;
            output += this.tempFormatter.FormatLowPerMonth(month) + Environment.NewLine;
            output += this.tempFormatter.FormatHighPerMonth(month) + Environment.NewLine;
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
            this.WeatherInfoCollections.Active = newWeatherInfoCollection;
            return newWeatherInfoCollection;
        }

        /// <summary>
        /// Sets the high temporary threshold.
        /// </summary>
        /// <param name="parse">The parse.</param>
        public void SetHighTempThreshold(int parse)
        {
            this.tempFormatter.HighTempThreshold = parse;
        }

        public void SetLowTempThreshold(int parse)
        {
            this.tempFormatter.LowTempThreshold = parse;
        }

        #endregion
    }
}