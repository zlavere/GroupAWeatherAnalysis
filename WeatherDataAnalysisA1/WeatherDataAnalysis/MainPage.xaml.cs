using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage;
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

        private WeatherInfoCollection weatherCollection;

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
                var content = await FileIO.ReadLinesAsync(file);

                var newWeatherCollection = new List<WeatherInfo>();

                StorageApplicationPermissions.FutureAccessList.Add(file);

                foreach (var current in TemperatureParser.GetWeatherList(content))
                {
                    newWeatherCollection.Add(current);
                }

                //TODO Probably want a list of WeatherCollection (eg WeatherCollectionList and add newWeatherCollection to it. Maybe?)
                this.weatherCollection = new WeatherInfoCollection(newWeatherCollection);
                this.setSummaryTextTemps(this.weatherCollection);
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

        //TODO Use List<string> to add all strings to this - maybe idictionary to create a map of data elements multi-select checkbox i want to see: 'x' 'y' 'z' elements
        private void setSummaryTextTemps(WeatherInfoCollection outputCollection)
        {
            var tempFormatter = new TemperatureDataFormatter();
            this.summaryTextBox.Text = string.Empty;
            this.summaryTextBox.Text += tempFormatter.FormatAverageHighTemperature(outputCollection) +
                                        Environment.NewLine;
            this.summaryTextBox.Text +=
                tempFormatter.FormatAverageLowTemperature(outputCollection) +
                Environment.NewLine;
            this.summaryTextBox.Text += tempFormatter.FormatHighestTemps(outputCollection) + 
                                        Environment.NewLine;
            this.summaryTextBox.Text += tempFormatter.FormatLowestTemps(outputCollection) + 
                                        Environment.NewLine;
            this.summaryTextBox.Text +=
                tempFormatter.FormatLowestHighTemps(outputCollection) + 
                Environment.NewLine;
            this.summaryTextBox.Text +=
                tempFormatter.FormatHighestLowTemps(outputCollection) + 
                Environment.NewLine;
            this.summaryTextBox.Text += tempFormatter.FormatDaysAbove90(outputCollection) + 
                                        Environment.NewLine;
            this.summaryTextBox.Text += tempFormatter.FormatDaysBelow32(outputCollection) + Environment.NewLine;
            this.summaryTextBox.Text += this.loadTemperaturesByMonth(outputCollection, 1);
               
        }


        private string loadTemperaturesByMonth(WeatherInfoCollection outputCollection, int month)
        {
            var output = "";
            var tempDataParser = new TemperatureDataFormatter();
            output += tempDataParser.FormatLowAveragePerMonth(outputCollection, month) + Environment.NewLine;
            output += tempDataParser.FormatHighAveragePerMonth(outputCollection, month) + Environment.NewLine;
            output += tempDataParser.FormatLowPerMonth(outputCollection, month) + Environment.NewLine;
            output += tempDataParser.FormatHighPerMonth(outputCollection, month) + Environment.NewLine;
            return output;

        }
        #endregion
    }
}