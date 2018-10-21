using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherDataAnalysis.View
{
    public sealed partial class MergeMatchDialog : ContentDialog
    {
        private const int CurrentDateIndex = 0;
        private const int CurrentHighIndex = 1;
        private const int CurrentLowIndex = 2;
        private const int NewDateIndex = 3;
        private const int NewHighIndex = 4;
        private const int NewLowIndex = 5;

        public const ContentDialogResult Replace = ContentDialogResult.Primary;
        public const ContentDialogResult Keep = ContentDialogResult.Secondary;
        public ContentDialogResult InputResult { get; private set; }

        public MergeMatchDialog()
        {
            this.InitializeComponent();
        }

        public async Task<ContentDialogResult> ShowDialog(string[] data)
        {
            this.ActiveDateText.Text = $"Date: {data[CurrentDateIndex]}";
            this.NewDateText.Text = $"Date: {data[NewDateIndex]}";
            this.ActiveHighTempText.Text = $"High: {data[CurrentHighIndex]}";
            this.NewHighTempText.Text = $"High: {data[NewHighIndex]}";
            this.ActiveLowTempText.Text = $"Low: {data[CurrentLowIndex]}";
            this.NewLowTempText.Text = $"Low: {data[NewLowIndex]}";

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
    }
}
