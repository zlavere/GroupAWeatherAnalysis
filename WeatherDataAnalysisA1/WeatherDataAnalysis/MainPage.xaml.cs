using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using WeatherDataAnalysis.Controller;

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
        private const int ApplicationHeight = 480;

        /// <summary>
        ///     The application width
        /// </summary>
        private const int ApplicationWidth = 1080;

        private readonly Import import;

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:WeatherDataAnalysis.MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();
            this.import = new Import();

            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        #endregion

        #region Methods

        private async void loadFile_Click(object sender, RoutedEventArgs e)
        {
            this.summaryTextBox.Text = "Load file was invoked.";

            var importExecution = await this.import.ExecuteImport();

            if (importExecution)
            {
                this.setSummaryText();
            }

            if (!this.HighTempInput.Text.Equals(string.Empty))
            {
                this.import.SetHighTempThreshold(int.Parse(this.HighTempInput.Text));
            }

            if (!this.lowTempInput.Text.Equals(string.Empty))
            {
                this.import.SetLowTempThreshold(int.Parse(this.lowTempInput.Text));
            }
        }

        private void setSummaryText()
        {
            var getImportResults = string.Empty;
            if (this.MonthInput.Text.Equals(string.Empty))
            {
                getImportResults = this.import.GenerateOutput();
            }
            else if (int.TryParse(this.MonthInput.Text, out _))
            {
                getImportResults = this.import.GenerateOutput(int.Parse(this.MonthInput.Text));
            }

            this.summaryTextBox.Text = getImportResults;
        }

        #endregion
    }
}