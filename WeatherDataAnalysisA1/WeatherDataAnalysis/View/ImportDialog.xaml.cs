using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WeatherDataAnalysis.Model.Enums;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherDataAnalysis.View
{
    /// <summary>
    ///     Dialog to collect user input for the file selected for import.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.ContentDialog" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class ImportDialog
    {
        #region Properties

        /// <summary>
        ///     Gets the name of the collection.
        /// </summary>
        /// <value>
        ///     The name of the collection.
        /// </value>
        public string CollectionName { get; private set; }

        /// <summary>
        ///     Gets the type of the import.
        /// </summary>
        /// <value>
        ///     The type of the import.
        /// </value>
        public ImportType ImportType { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImportDialog" /> class.
        /// </summary>
        public ImportDialog()
        {
            this.InitializeComponent();
            IsPrimaryButtonEnabled = false;
        }

        #endregion

        #region Methods

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.CollectionName = this.collectionNameInput.Text;
            this.setImportType();
        }

        private void setImportType()
        {
            if (this.isOverwriteChecked())
            {
                this.ImportType = ImportType.Overwrite;
            }
            else if (this.isMergeChecked())
            {
                this.ImportType = ImportType.Merge;
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private bool isRequiredDataAvailable()
        {
            var dataAvailable = false;
            var hasName = false;
            var hasImportType = false;
            if (!this.collectionNameInput.Equals(null))
            {
                hasName = true;
            }

            if (this.isOverwriteChecked() || this.isMergeChecked())
            {
                hasImportType = true;
            }

            if (hasName && hasImportType)
            {
                dataAvailable = true;
            }

            return dataAvailable;
        }

        private bool isMergeChecked()
        {
            var mergeButtonIsChecked = this.mergeButton.IsChecked;
            var mergeChecked = mergeButtonIsChecked != null && (bool) mergeButtonIsChecked;
            return mergeChecked;
        }

        private bool isOverwriteChecked()
        {
            var overwriteButtonIsChecked = this.overwriteButton.IsChecked;
            var overwriteChecked = overwriteButtonIsChecked != null && (bool) overwriteButtonIsChecked;
            return overwriteChecked;
        }

        private void overwriteChecked(object sender, RoutedEventArgs e)
        {
            this.tryEnablePrimaryButton();
        }

        private void checkAllRequiredOnNameInput(object sender, KeyRoutedEventArgs e)
        {
            this.tryEnablePrimaryButton();
        }

        private void tryEnablePrimaryButton()
        {
            if (this.isRequiredDataAvailable())
            {
                IsPrimaryButtonEnabled = true;
            }
        }

        private void mergeChecked(object sender, RoutedEventArgs e)
        {
            this.tryEnablePrimaryButton();
        }

        #endregion
    }
}