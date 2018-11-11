using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherDataAnalysis.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterDetailsWeather : Page
    {
        #region Constructors

        public MasterDetailsWeather()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        private void c_NavigateToMainPage(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage)); //TODO Move to ViewModel
        }

        #endregion
    }
}