using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherDataAnalysis.View
{
    /// <summary>
    ///     Displays a dialog to manage Merging preferences when attempting
    ///     to import a second or more files.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.ContentDialog" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class MergeMatchDialog
    {
        #region Data members

        /// <summary>
        ///     The replace button
        /// </summary>
        public const ContentDialogResult Replace = ContentDialogResult.Primary;

        private const int CurrentDateIndex = 0;
        private const int CurrentHighIndex = 1;
        private const int CurrentLowIndex = 2;
        private const int NewDateIndex = 3;
        private const int NewHighIndex = 4;
        private const int NewLowIndex = 5;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the input result.
        /// </summary>
        /// <value>
        ///     The input result.
        /// </value>
        private ContentDialogResult InputResult { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MergeMatchDialog" /> class.
        /// </summary>
        public MergeMatchDialog()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Shows the dialog.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public async Task<ContentDialogResult> ShowDialog(string[] data)
        {
            this.activeDateText.Text = $"Date: {data[CurrentDateIndex]}";
            this.newDateText.Text = $"Date: {data[NewDateIndex]}";
            this.activeHighTempText.Text = $"High: {data[CurrentHighIndex]}";
            this.newHighTempText.Text = $"High: {data[NewHighIndex]}";
            this.activeLowTempText.Text = $"Low: {data[CurrentLowIndex]}";
            this.newLowTempText.Text = $"Low: {data[NewLowIndex]}";

            var results = await ShowAsync();
            this.InputResult = results;
            return this.InputResult;
        }

        private void c_Replace(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void c_Keep(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        #endregion
    }
}