using System;
using System.Collections.Generic;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WeatherDataAnalysis.Controller;
using WeatherDataAnalysis.Model.Enums;
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

        private readonly MainPageController mainPageController;

        #endregion

        #region Properties

        private HistogramSizeComboBoxBindings HistogramSizeComboBoxBindings { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:WeatherDataAnalysis.MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.HistogramSizeComboBoxBindings = new HistogramSizeComboBoxBindings();
            this.InitializeComponent();
            this.mainPageController = new MainPageController();
        }

        #endregion

        #region Methods

        private void c_DetailsView(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MasterDetailsWeather));
        }

        #endregion
    }
}