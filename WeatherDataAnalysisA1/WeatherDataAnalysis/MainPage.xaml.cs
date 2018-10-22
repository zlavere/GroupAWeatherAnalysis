﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
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

        /// <summary>
        ///     The application height
        /// </summary>
        private const int ApplicationHeight = 480;

        /// <summary>
        ///     The application width
        /// </summary>
        private const int ApplicationWidth = 1080;

        private readonly MainPageController MainPageController;

        #endregion

        #region Properties

        private const int defaultBucketSize = 10;
        public FileOpenPicker FilePicker { get; private set; }
        public StorageFile File { get; private set; }
        public ImportDialog ImportDialog { get; private set; }
        public ContentDialogResult ImportDialogResults { get; private set; }

        private int HighTempThreshold { get; set; }
        private int LowTempThreshold { get; set; }
        private List<HistogramBucketSize> HistogramBucketSizes { get; set; }

        private ComboBoxBindings ComboBoxBindings { get; }

        #endregion

        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:WeatherDataAnalysis.MainPage" /> class.
        /// </summary>
        public MainPage()
        {
            this.ComboBoxBindings = new ComboBoxBindings();
            this.InitializeComponent();
            this.MainPageController = new MainPageController();
            
            this.HighTempThreshold = (int) Temperature.HighWarningThreshold;
            this.LowTempThreshold = (int) Temperature.FreezingFahrenheit;

            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }



        #endregion

        #region Methods

        private async void loadFile_Click(object sender, RoutedEventArgs e)
        {
            this.summaryTextBox.Text = "Load file was invoked.";

            try
            {
                var importExecution = await this.executeImport();

                if (this.MonthInput.MaxLength > 0)
                {
                    this.MainPageController.SetMonth(int.Parse(this.MonthInput.Text));
                }

                if (importExecution)
                {
                    this.setSummaryText();
                }
            }
            catch (ArgumentException ae)
            {
                this.summaryTextBox.Text =
                    $"{ae.Message}{Environment.NewLine}A collection with this name may already exist. Please try again with another name";
            }
            catch (Exception)
            {
                //ignored
            }
        }

        private void setSummaryText()
        {
            var getImportResults = string.Empty;
            this.MainPageController.SetHighTempThreshold(this.HighTempThreshold);
            this.MainPageController.SetLowTempThreshold(this.LowTempThreshold);
            if (this.MonthInput.Text.Equals(string.Empty))
            {
                getImportResults = this.MainPageController.GenerateOutput();
            }
            else if (int.TryParse(this.MonthInput.Text, out _))
            {
                getImportResults = this.MainPageController.GenerateOutput(int.Parse(this.MonthInput.Text));
            }

            this.summaryTextBox.Text = getImportResults;
        }

        private FileOpenPicker createNewFileOpenPicker()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".csv");
            filePicker.FileTypeFilter.Add(".txt");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            return filePicker;
        }

        /// <summary>
        ///     Executes the MainPageController.
        /// </summary>
        /// <returns>True if new WeatherInfoCollection is added.</returns>
        private async Task<bool> executeImport()
        {
            var executionSuccess = false;

            this.FilePicker = this.createNewFileOpenPicker();
            this.File = await this.FilePicker.PickSingleFileAsync();
            StorageApplicationPermissions.FutureAccessList.Add(this.File);
            this.ImportDialog = new ImportDialog();
            this.ImportDialogResults = await this.ImportDialog.ShowAsync();

            if (this.File != null)
            {
                await this.MainPageController.CreateNewFromFile(this.File, this.ImportDialog);
                this.MainPageController.SetUpFormatter();
                executionSuccess = true;
            }

            return executionSuccess;
        }

        private void lostFocus_UpdateHighTempThreshold(UIElement sender, LosingFocusEventArgs args)
        {
            if (this.highTempInput.Text.Length > 0)
            {
                this.HighTempThreshold = int.Parse(this.highTempInput.Text);
                Debug.WriteLine(this.HighTempThreshold);
            }
            else
            {
                this.HighTempThreshold = (int) Temperature.HighWarningThreshold;
            }
        }

        private void lostFocus_UpdateLowTempThreshold(UIElement sender, LosingFocusEventArgs args)
        {
            if (this.lowTempInput.Text.Length > 0)
            {
                this.LowTempThreshold = int.Parse(this.lowTempInput.Text);
            }
            else
            {
                this.LowTempThreshold = (int) Temperature.FreezingFahrenheit;
            }
        }

        private void c_ClearData(object sender, RoutedEventArgs e)
        {
            this.summaryTextBox.Text = @"Data has been cleared.";

            if (ActiveWeatherInfoCollection.Active != null)
            {
                ActiveWeatherInfoCollection.Active.Clear();
            }
        }

        private async void c_CreateWeatherInfo(object sender, RoutedEventArgs e)
        {
            var addWeatherInfo = new AddWeatherInfo();
            var successfullyCreated = await addWeatherInfo.StartDialog();

            if (successfullyCreated)
            {
                this.summaryTextBox.Text = $"Created New Weather Information Entry{Environment.NewLine}" +
                                           $"Date: {addWeatherInfo.CreatedWeatherInfo.Date}{Environment.NewLine}" +
                                           $"High Temperature: {addWeatherInfo.CreatedWeatherInfo.HighTemp}{Environment.NewLine}" +
                                           $"Low Temperature: {addWeatherInfo.CreatedWeatherInfo.LowTemp}{Environment.NewLine}";
                this.RefreshButton.IsEnabled = true;
            }
            else
            {
                this.summaryTextBox.Text = "Failed to create a new Weather Information Entry";
            }
        }

        private void c_Refresh(object sender, RoutedEventArgs e)
        {
            this.setSummaryText();
            this.RefreshButton.IsEnabled = false;
        }

        private void change_BucketSize(object sender, SelectionChangedEventArgs e)
        {
           var selection = this.ComboBoxBindings.Sizes[this.BucketSizeComboBox.SelectedIndex];
           this.MainPageController.SetHistogramBucketSize(selection);
            if (ActiveWeatherInfoCollection.Active != null)
            {
                this.RefreshButton.IsEnabled = true;
            } 
        }

        #endregion


    }
}