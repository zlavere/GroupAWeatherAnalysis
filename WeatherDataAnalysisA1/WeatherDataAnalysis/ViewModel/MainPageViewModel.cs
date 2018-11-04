using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WeatherDataAnalysis.Annotations;
using WeatherDataAnalysis.Controller;
using WeatherDataAnalysis.Model.Enums;
using WeatherDataAnalysis.View;

namespace WeatherDataAnalysis.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        #region Properties
        private FileOpenPicker FilePicker { get; set; }
        private StorageFile File { get; set; }
        private ImportDialog ImportDialog { get; set; }
        private ContentDialogResult ImportDialogResults { get; set; }

        private List<HistogramBucketSize> HistogramBucketSizes { get; set; }
        private string summaryText;
        public string SummaryText
        {
            get => this.summaryText; set
            {
                this.summaryText = value;
                this.OnPropertyChanged(this.summaryText);
            }
        }

        private string monthFilter;
        public string MonthFilter
        {
            get => this.summaryText; set
            {
                this.summaryText = value;
                this.OnPropertyChanged(monthFilter);
            }
        }
        private string yearFilter;
        public string YearFilter
        {
            get => this.summaryText; set
            {
                this.summaryText = value;
                this.OnPropertyChanged(yearFilter);
            }
        }
        private HistogramSizeComboBoxBindings HistogramSizeComboBoxBindings { get; }
        private string highTempThreshold ;

        public string HighTempThreshold
        {
            get => this.highTempThreshold;
            set
            {
                if (value == this.highTempThreshold) return;
                this.highTempThreshold = value;

                this.OnPropertyChanged(nameof(this.HighTempThreshold));
            }
        }

        private string lowTempThreashold;

        public string LowTempThreshold
        {
            get => this.lowTempThreashold;
            set
            {
                if (value == this.lowTempThreashold) return;
                this.lowTempThreashold = value;
                this.OnPropertyChanged(nameof(this.LowTempThreshold));
            }
        }

        public Button refreshButton;
        #endregion





        #region Constructors

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:WeatherDataAnalysis.MainPage" /> class.
        /// </summary>
        public MainPageViewModel()
        {
            this.HistogramSizeComboBoxBindings = new HistogramSizeComboBoxBindings();

            this.HighTempThreshold = Temperature.HighWarningThreshold.ToString();
            this.LowTempThreshold = Temperature.FreezingFahrenheit.ToString();

            
        }

        #endregion

        #region Methods

        private async void loadFile_Click(object sender, RoutedEventArgs e)
        {
            this.summaryText = "Load file was invoked.";

            try
            {
                var importExecution = await this.executeImport();

                if (this.monthFilter.Length > 0)
                {
                    //TODO month Filter
                    //this.mainPageController.SetMonth(int.Parse(this.monthInput.Text));
                }
                
                if (importExecution)
                {
                    this.setSummaryText();
                }
            }
            catch (ArgumentException ae)
            {
                this.summaryText =
                    $"{ae.Message}{Environment.NewLine}A collection with this name may already exist. Please try again with another name";
            }
            catch (Exception)
            {
                //ignored
            }
        }

        private void setSummaryText()
        {

            //TODO setSummeryText
            var getImportResults = string.Empty;
                //this.mainPageController.SetHighTempThreshold(this.HighTempThreshold);
           // this.mainPageController.SetLowTempThreshold(this.LowTempThreshold);
            if (this.monthFilter.Equals(string.Empty))
            {
               // getImportResults = this.mainPageController.GenerateOutput();
            }
            else if (int.TryParse(this.monthFilter, out _))
            {
               // getImportResults = this.mainPageController.GenerateOutput(int.Parse(this.monthFilter));
            }

            this.summaryText = getImportResults;
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


            if (this.File != null)
            {
                //TODO exeecuteImport
                this.ImportDialog = new ImportDialog();
                this.ImportDialogResults = await this.ImportDialog.ShowAsync();
               // await this.mainPageController.CreateNewFromFile(this.File, this.ImportDialog);
               // this.mainPageController.SetUpFormatter();
                executionSuccess = true;
            }

            return executionSuccess;
        }


        private void c_ClearData(object sender, RoutedEventArgs e)
        {
            this.summaryText = @"Data has been cleared.";

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
                this.summaryText = $"Created New Weather Information Entry{Environment.NewLine}" +
                                           $"Date: {addWeatherInfo.CreatedWeatherInfo.Date}{Environment.NewLine}" +
                                           $"High Temperature: {addWeatherInfo.CreatedWeatherInfo.HighTemp}{Environment.NewLine}" +
                                           $"Low Temperature: {addWeatherInfo.CreatedWeatherInfo.LowTemp}{Environment.NewLine}";
                this.refreshButton.IsEnabled = true;
            }
            else
            {
                this.summaryText = "Failed to create a new Weather Information Entry";
            }
        }

        private void c_Refresh(object sender, RoutedEventArgs e)
        {
            this.setSummaryText();
            this.refreshButton.IsEnabled = false;
        }

        private void change_BucketSize(object sender, SelectionChangedEventArgs e)
        {
            //todo changbucketsize
            //var selection = this.HistogramSizeComboBoxBindings.Sizes[DefaultBucketSizeIndex];
            //this.mainPageController.SetHistogramBucketSize(selection);
            if (ActiveWeatherInfoCollection.Active != null)
            {
                this.refreshButton.IsEnabled = true;
            }
        }

        private async void c_Download(object sender, RoutedEventArgs e)
        {
            //todo c_download
            var directoryPicker = new FolderPicker();
            directoryPicker.FileTypeFilter.Add(".csv");
            directoryPicker.FileTypeFilter.Add(".txt");
            directoryPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            var directoryResult = await directoryPicker.PickSingleFolderAsync();

            if (directoryResult != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", directoryResult);
               // this.mainPageController.WriteActiveInfoToFile(directoryResult);
                this.summaryText =
                    $"{ActiveWeatherInfoCollection.Active.Name} data has been written to {directoryResult.Name}.";
            }
        }

        #endregion
        #region INotifyPropertyChangedImplementation

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}