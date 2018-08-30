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
        public const int ApplicationHeight = 355;

        /// <summary>
        ///     The application width
        /// </summary>
        public const int ApplicationWidth = 625;

        private WeatherCollection weatherCollection;

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

            var filePicker = this.CreateNewFileOpenPicker();
            var file = await filePicker.PickSingleFileAsync();

            if (file != null)
            {
                var tempParser = new TemperatureParser();
                var content = await FileIO.ReadLinesAsync(file);
                var tempFormatter = new TemperatureDataFormatter();
                var newWeatherCollection = new List<Weather>();

                StorageApplicationPermissions.FutureAccessList.Add(file);
                this.summaryTextBox.Text = string.Empty;

                foreach (var current in tempParser.GetWeatherList(content))
                {
                    newWeatherCollection.Add(current);
                    this.summaryTextBox.Text += tempFormatter.FormatSimpleString(current) + Environment.NewLine;
                }

                this.weatherCollection = new WeatherCollection(newWeatherCollection);
            }
        }

        private FileOpenPicker CreateNewFileOpenPicker()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".csv");
            filePicker.FileTypeFilter.Add(".txt");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            return filePicker;
        }

        #endregion
    }
}