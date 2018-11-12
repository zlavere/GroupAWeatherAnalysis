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

        private const int DefaultBucketSizeIndex = 2;

        private const int DefaultBucketSize = 10;

        private readonly MainPageController mainPageController;

        #endregion

        #region Properties

        
        private ImportDialog ImportDialog { get; set; }
        private ContentDialogResult ImportDialogResults { get; set; }

        private List<HistogramBucketSize> HistogramBucketSizes { get; set; }

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



        private async void c_Download(object sender, RoutedEventArgs e)
        {
            var directoryPicker = new FolderPicker();
            directoryPicker.FileTypeFilter.Add(".csv");
            directoryPicker.FileTypeFilter.Add(".txt");
            directoryPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            var directoryResult = await directoryPicker.PickSingleFolderAsync();

            if (directoryResult != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", directoryResult);
                this.mainPageController.WriteActiveInfoToFile(directoryResult);
            }
        }

        private void c_DetailsView(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MasterDetailsWeather));
        }

        #endregion
    }
}