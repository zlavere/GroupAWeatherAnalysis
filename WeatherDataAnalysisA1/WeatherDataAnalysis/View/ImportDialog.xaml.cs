using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
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
        #region Data members

        public const ContentDialogResult Submit = ContentDialogResult.Primary;
        public const ContentDialogResult Cancel = ContentDialogResult.Secondary;

        #endregion

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

        public ContentDialogResult Result { get; set; }

        public StorageFile File { get; set; }

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

        public async Task<bool> StartDialog()
        {
            var hasResponded = false;
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".csv");
            filePicker.FileTypeFilter.Add(".txt");
            filePicker.FileTypeFilter.Add(".xml");
            this.File = await filePicker.PickSingleFileAsync();
            StorageApplicationPermissions.FutureAccessList.Add(this.File);

            if (this.File != null)
            {
                hasResponded = await this.runDialog();
            }

            return hasResponded;
        }

        private async Task<bool> runDialog()
        {
            var isComplete = false;

            this.Result = await ShowAsync();

            if (this.Result == Submit)
            {
                isComplete = true;
            }

            return isComplete;
        }

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

            if (!string.IsNullOrEmpty(this.collectionNameInput.Text))
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

//        private FileOpenPicker filePicker { get; set; }
    }
}