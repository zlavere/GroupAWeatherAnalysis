using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WeatherDataAnalysis.ViewModel;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherDataAnalysis.View
{
    /// <summary>
    ///     Prompt for a specific day's weather information
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.ContentDialog" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class NewWeatherInfoDialog
    {
        #region Data members

        /// <summary>
        ///     Submit Button
        /// </summary>
        public const ContentDialogResult Submit = ContentDialogResult.Primary;

        private const ContentDialogResult Cancel = ContentDialogResult.Secondary;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the high temporary.
        /// </summary>
        /// <value>
        ///     The high temporary.
        /// </value>
        public int HighTemp { get; private set; }

        /// <summary>
        ///     Gets the low temporary.
        /// </summary>
        /// <value>
        ///     The low temporary.
        /// </value>
        public int LowTemp { get; private set; }

        /// <summary>
        ///     Gets the date.
        /// </summary>
        /// <value>
        ///     The date.
        /// </value>
        public DateTime Date { get; private set; }

        private ContentDialogResult InputResult { get; set; }

        /// <summary>
        ///     Gets the name of the collection.
        /// </summary>
        /// <value>
        ///     The name of the collection.
        /// </value>
        public string CollectionName { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="NewWeatherInfoDialog" /> class.
        /// </summary>
        public NewWeatherInfoDialog()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Shows the dialog.
        /// </summary>
        /// <returns>ContentDialogResult asynchronously</returns>
        public async Task<ContentDialogResult> ShowDialog()
        {
            if (ActiveWeatherInfoCollection.Active == null)
            {
                this.noCollectionLabel.Visibility = Visibility.Visible;
                this.nameInput.Visibility = Visibility.Visible;
            }

            var inputResults = await ShowAsync();
            this.InputResult = inputResults;
            return this.InputResult;
        }

        private void c_Submit(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.InputResult = Submit;
        }

        private void c_Cancel(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.InputResult = Cancel;
        }

        private bool isAllDataValid()
        {
            return this.isValidDate() && this.isValidHigh() && this.isValidLow() && this.HighTemp >= this.LowTemp &&
                   this.isCollectionNameValid();
        }

        private bool isCollectionNameValid()
        {
            var result = false;
            if (this.nameInput.Text.Length > 0)
            {
                this.CollectionName = this.nameInput.Text;
                result = true;
            }
            else if (ActiveWeatherInfoCollection.Active != null)
            {
                result = true;
            }

            return result;
        }

        private bool isValidLow()
        {
            var result = false;

            if (int.TryParse(this.lowTempInput.Text, out var lowTempResult))
            {
                this.LowTemp = lowTempResult;
                result = true;
            }

            return result;
        }

        private bool isValidHigh()
        {
            var result = false;

            if (int.TryParse(this.highTempInput.Text, out var highTempResult))
            {
                this.HighTemp = highTempResult;
                result = true;
            }

            return result;
        }

        private bool isValidDate()
        {
            var result = false;

            if (this.dateInput.Date.Date <= DateTime.Now)
            {
                this.Date = this.dateInput.Date.Date;
                result = true;
            }

            return result;
        }

        private void lostFocus_InputField(object sender, RoutedEventArgs e)
        {
            if (this.isAllDataValid())
            {
                IsPrimaryButtonEnabled = true;
            }
        }

        /// <summary>
        ///     Determines whether [is overwrite allowed].
        /// </summary>
        /// <returns>
        ///     <c>true</c> if [is overwrite allowed]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsOverwriteAllowed()
        {
            var checkBoxValue = this.overwriteCheckBox.IsChecked;
            var isAllowed = false;

            if (checkBoxValue != null && checkBoxValue == true)
            {
                isAllowed = true;
            }

            return isAllowed;
        }

        #endregion
    }
}