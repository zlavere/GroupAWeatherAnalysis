using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherDataAnalysis.View
{
    public sealed partial class MergeMatchDialog : ContentDialog
    {
        private const int currentDateIndex = 0;
        private const int currentHighIndex = 1;
        private const int currentLowIndex = 2;
        private const int newDateIndex = 3;
        private const int newHighIndex = 4;
        private const int newLowIndex = 5;

        public const ContentDialogResult Replace = ContentDialogResult.Primary;
        public const ContentDialogResult Keep = ContentDialogResult.Secondary;
        public ContentDialogResult inputResult { get; private set; }

        public MergeMatchDialog()
        {
            this.InitializeComponent();
        }

        public async Task<ContentDialogResult> ShowDialog(string[] data)
        {
            this.ActiveDateText.Text = $"Date: {data[currentDateIndex]}";
            this.NewDateText.Text = $"Date: {data[newDateIndex]}";
            this.ActiveHighTempText.Text = $"High: {data[currentHighIndex]}";
            this.NewHighTempText.Text = $"High: {data[newHighIndex]}";
            this.ActiveLowTempText.Text = $"Low: {data[currentLowIndex]}";
            this.NewLowTempText.Text = $"Low: {data[newLowIndex]}";

            var results = await this.ShowAsync();
            this.inputResult = results;
            return this.inputResult;
        }

        private void c_Replace(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void c_Keep(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
