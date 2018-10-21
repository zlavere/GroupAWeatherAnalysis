using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WeatherDataAnalysis.ViewModel;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherDataAnalysis.View
{
    public sealed partial class NewWeatherInfoDialog : ContentDialog
    {
        public const ContentDialogResult Submit = ContentDialogResult.Primary;
        public const ContentDialogResult Cancel = ContentDialogResult.Secondary; 

        public int HighTemp { get; private set; }
        public int LowTemp { get; private set; }
        public DateTime Date { get; private set; }

        public ContentDialogResult InputResult { get; private set; }
        public string CollectionName { get; private set; }

        public NewWeatherInfoDialog()
        {
            this.InitializeComponent();
            
        }

        public async Task<ContentDialogResult> ShowDialog()
        {
            if (ActiveWeatherInfoCollection.Active == null)
            {
                this.NoCollectionLabel.Visibility = Visibility.Visible;
                this.NameInput.Visibility = Visibility.Visible;
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
            return this.isValidDate() && this.isValidHigh() && this.isValidLow() && this.HighTemp >= this.LowTemp && this.isCollectionNameValid();
        }

        private bool isCollectionNameValid()
        {
            var result = false;
            if (this.NameInput.Text.Length > 0)
            {
                this.CollectionName = this.NameInput.Text;
                result = true;
            } else if (ActiveWeatherInfoCollection.Active != null)
            {
                result = true;
            } 
            return result; 
        }

        private bool isValidLow()
        {
            var result = false;

            if (int.TryParse(this.LowTempInput.Text, out var lowTempResult))
            {
                this.LowTemp = lowTempResult;
                result = true;
            }

            return result;
        }

        private bool isValidHigh()
        {
            var result = false;

            if (int.TryParse(this.HighTempInput.Text, out var highTempResult))
            {
                this.HighTemp = highTempResult;
                result = true;
            }

            return result;
        }

        private bool isValidDate()
        {
            var result = false;

            if (this.DateInput.Date.Date <= DateTime.Now)
            {
                this.Date = this.DateInput.Date.Date;
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

        public bool IsOverwriteAllowed()
        {
            var isChecked = this.OverwriteCheckBox.IsChecked;

            return isChecked != null && (bool)isChecked;
        }
    }
}
