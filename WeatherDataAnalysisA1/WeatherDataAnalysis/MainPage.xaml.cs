using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using WeatherDataAnalysis.Format;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;

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

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        #endregion

        #region Methods

        private async void loadFile_Click(object sender, RoutedEventArgs e)
        {
            this.summaryTextBox.Text = "Load file was invoked.";

            var filePicker = this.createNewFileOpenPicker();
            var file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                StorageApplicationPermissions.FutureAccessList.Add(file);
                var csvReader = new CsvReader();
                var fileLines = await csvReader.GetFileLines(file);
                this.setSummaryTextTemps(
                    this.createWeatherInfoCollection(fileLines)
                );
            }
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

        private WeatherInfoCollection createWeatherInfoCollection(IList<string> openedFileLines)
        {
            var newWeatherCollection = new List<WeatherInfo>();

            foreach (var current in TemperatureParser.GetWeatherList(openedFileLines))
            {
                newWeatherCollection.Add(current);
            }

            //TODO Probably want a List of WeatherInfoCollection (eg WeatherInfoCollectionList and add newWeatherInfoCollection to it. Maybe?)
            var weatherInfoCollection = new WeatherInfoCollection(newWeatherCollection);
            return weatherInfoCollection;
        }

        //TODO Use List<string> to add all strings to this - maybe iDictionary to create a map of data elements multi-select checkbox i want to see: 'x' 'y' 'z' elements
        private void setSummaryTextTemps(WeatherInfoCollection outputCollection)
        {
            this.summaryTextBox.Text = string.Empty;
            this.summaryTextBox.Text += this.loadTemperaturesByYear(outputCollection);
            this.summaryTextBox.Text += this.loadTemperaturesByMonth(outputCollection, 1);
        }

        private string loadTemperaturesByYear(WeatherInfoCollection outputCollection)
        {
            var tempFormatter = new TemperatureDataFormatter(outputCollection);

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
            //TODO Change to get user input when relevant to assignment.
            output += tempFormatter.FormatDaysBelow(32) + Environment.NewLine;
            output += this.loadTemperaturesByMonth(outputCollection, 1);
            return output;
        }

        private string loadTemperaturesByMonth(WeatherInfoCollection outputCollection, int month)
        {
            var tempDataParser = new TemperatureDataFormatter(outputCollection);
            var output = tempDataParser.FormatLowAveragePerMonth(month) + Environment.NewLine;
            output += tempDataParser.FormatHighAveragePerMonth(month) + Environment.NewLine;
            output += tempDataParser.FormatLowPerMonth(month) + Environment.NewLine;
            output += tempDataParser.FormatHighPerMonth(month) + Environment.NewLine;
            return output;
        }

        #endregion
    }
}