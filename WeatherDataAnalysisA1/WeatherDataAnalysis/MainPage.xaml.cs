using System;
using Windows.Foundation;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WeatherDataAnalysis.View;
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
            var importDialog = new ImportDialog();
            var importDialogResults = await importDialog.ShowAsync();

            if (importDialogResults.Equals(ContentDialogResult.Secondary))
            {
                return;
            }

            if (file != null)
            {
                StorageApplicationPermissions.FutureAccessList.Add(file);
                var weatherInfoCollection =
                    await this.weatherInfoCollections.CreateNewFromFile(file, importDialog.Name);
                this.weatherInfoCollections.Active = weatherInfoCollection;
                this.setSummaryTextTemps();
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

        //TODO Move to controller
        //TODO Use List<string> to add all strings to this - maybe IDictionary to create a map of data elements multi-select checkbox i want to see: 'x' 'y' 'z' elements
        private void setSummaryTextTemps()
        {
            this.summaryTextBox.Text = string.Empty;
            this.summaryTextBox.Text += this.loadTemperaturesByYear();
            this.summaryTextBox.Text += this.loadTemperaturesByMonth(1);
        }

        private string loadTemperaturesByYear()
        {
            var tempFormatter = this.dataFormatter.TemperatureDataFormatter;
            tempFormatter.WeatherInfoCollection = this.weatherInfoCollections.Active;
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

        private string loadTemperaturesByMonth(int month)
        {
            var tempDataFormatter = this.dataFormatter.TemperatureDataFormatter;
            tempDataFormatter.WeatherInfoCollection = this.weatherInfoCollections.Active;
            var output = tempDataFormatter.FormatLowAveragePerMonth(month) + Environment.NewLine;
            output += tempDataFormatter.FormatHighAveragePerMonth(month) + Environment.NewLine;
            output += tempDataFormatter.FormatLowPerMonth(month) + Environment.NewLine;
            output += tempDataFormatter.FormatHighPerMonth(month) + Environment.NewLine;
            return output;
        }

        #endregion
    }
}