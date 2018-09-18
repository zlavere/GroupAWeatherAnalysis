using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherDataAnalysis
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        #region Data members

        /// <summary>
        ///     The application height
        /// </summary>
        private const int ApplicationHeight = 355;

        /// <summary>
        ///     The application width
        /// </summary>
        private const int ApplicationWidth = 625;

        private readonly DataFormatter dataFormatter;
        private readonly WeatherInfoCollectionsBinding weatherInfoCollections;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:WeatherDataAnalysis.MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.weatherInfoCollections = new WeatherInfoCollectionsBinding();
            this.dataFormatter = new DataFormatter();

            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        #endregion

        #region Methods

        private async void loadFile_Click(object sender, RoutedEventArgs e)
        {
            this.summaryTextBox.Text = "Load file was invoked.";

            var filePicker = createNewFileOpenPicker();
            var file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                StorageApplicationPermissions.FutureAccessList.Add(file);
                var csvReader = new CsvReader();
                var fileLines = await csvReader.GetFileLines(file);
                var newWeatherInfoCollection = this.createWeatherInfoCollection(fileLines);
                this.addWeatherInfoCollection(newWeatherInfoCollection);
                this.setSummaryTextTemps(newWeatherInfoCollection);
            }
        }

        private static FileOpenPicker createNewFileOpenPicker()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".csv");
            filePicker.FileTypeFilter.Add(".txt");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            return filePicker;
        }

        private WeatherInfoCollection createWeatherInfoCollection(IList<string> openedFileLines)
        {
            var newWeatherCollection = new List<WeatherInfo>();

            foreach (var current in TemperatureParser.GetWeatherList(openedFileLines))
            {
                newWeatherCollection.Add(current);
            }

            var weatherInfoCollection = new WeatherInfoCollection(newWeatherCollection);
            return weatherInfoCollection;
        }

        private void addWeatherInfoCollection(WeatherInfoCollection weatherInfoCollection)
        {
            this.weatherInfoCollections.Add(weatherInfoCollection);
        }

        //TODO Move to controller
        //TODO Use List<string> to add all strings to this - maybe idictionary to create a map of data elements multi-select checkbox i want to see: 'x' 'y' 'z' elements
        private void setSummaryTextTemps(WeatherInfoCollection outputCollection)
        {
            this.summaryTextBox.Text = string.Empty;
            this.summaryTextBox.Text += this.loadTemperaturesByYear(outputCollection);
            this.summaryTextBox.Text += this.loadTemperaturesByMonth(outputCollection, 1);
        }

        private string loadTemperaturesByYear(WeatherInfoCollection outputCollection)
        {
            var tempFormatter = this.dataFormatter.TemperatureDataFormatter;

            var output = tempFormatter.FormatAverageHighTemperature() +
                         Environment.NewLine;
            output +=
                tempFormatter.FormatAverageLowTemperature() +
                Environment.NewLine;
            output += tempFormatter.FormatHighestTemps() +
                      Environment.NewLine;
            output += tempFormatter.FormatLowestTemps() +
                      Environment.NewLine;
            output +=
                tempFormatter.FormatLowestHighTemps() +
                Environment.NewLine;
            output +=
                tempFormatter.FormatHighestLowTemps() +
                Environment.NewLine;
            output += tempFormatter.FormatDaysAbove(90) +
                      Environment.NewLine;
            output += tempFormatter.FormatDaysBelow(32) + Environment.NewLine;
            return output;
        }

        private string loadTemperaturesByMonth(WeatherInfoCollection outputCollection, int month)
        {
            var tempDataParser = this.dataFormatter.TemperatureDataFormatter;
            var output = tempDataParser.FormatLowAveragePerMonth(month) + Environment.NewLine;
            output += tempDataParser.FormatHighAveragePerMonth(month) + Environment.NewLine;
            output += tempDataParser.FormatLowPerMonth(month) + Environment.NewLine;
            output += tempDataParser.FormatHighPerMonth(month) + Environment.NewLine;
            return output;
        }

        #endregion
    }
}