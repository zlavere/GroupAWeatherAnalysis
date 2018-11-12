using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WeatherDataAnalysis.Controller;
using WeatherDataAnalysis.Extension;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Utility;

namespace WeatherDataAnalysis.ViewModel
{
    /// <inheritdoc />
    /// <summary>
    /// Data Binding for Master/Details View of Active Collection
    /// </summary>
    /// <seealso cref="T:System.ComponentModel.INotifyPropertyChanged" />
    public class DetailViewModel : INotifyPropertyChanged
    {
        #region Data members

        private ObservableCollection<WeatherInfo> weatherInfoMaster;
        private WeatherInfo selectedWeatherInfo;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the weather information master list for Master/Details pattern.
        /// </summary>
        /// <value>
        /// The weather information master.
        /// </value>
        public ObservableCollection<WeatherInfo> WeatherInfoMaster
        {
            get => this.weatherInfoMaster.OrderBy(weatherInfo => weatherInfo.Date).ToList().ToObservableCollection();
            set
            {
                this.weatherInfoMaster = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the selected weather information detail.
        /// </summary>
        /// <value>
        /// The selected weather information detail.
        /// </value>
        public WeatherInfo SelectedWeatherInfoDetail
        {
            get => this.selectedWeatherInfo;
            set
            {
                this.selectedWeatherInfo = value;
                this.canRemoveWeatherInfo(this.selectedWeatherInfo);
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// RelayCommand to Remove WeatherInfo from active collection.
        /// </summary>
        /// <value>
        /// weather information.
        /// </value>
        public RelayCommand RemoveWeatherInfo { get; }

        /// <summary>
        /// RelayCommand to Add WeatherInfo to active collection.
        /// </summary>
        /// <value>
        /// weather information.
        /// </value>
        public RelayCommand AddWeatherInfo { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailViewModel"/> class.
        /// </summary>
        public DetailViewModel()
        {
            this.WeatherInfoMaster = ActiveWeatherInfoCollection.Active.ToObservableCollection();
            this.SelectedWeatherInfoDetail = ActiveWeatherInfoCollection.Active.First();
            this.RemoveWeatherInfo = new RelayCommand(this.removeSelectedWeatherInfo, this.canRemoveWeatherInfo);
            this.AddWeatherInfo = new RelayCommand(this.createWeatherInfo, this.canCreateWeatherInfo);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if an Active Weather Information collection exists.</returns>
        public event PropertyChangedEventHandler PropertyChanged;

        private bool canCreateWeatherInfo(object obj)
        {
            return ActiveWeatherInfoCollection.Active != null;
        }

        private async void createWeatherInfo(object obj)
        {
            var addWeatherInfoController = new AddWeatherInfo();
            var isCreated = await addWeatherInfoController.StartDialog();
            if (this.canCreateWeatherInfo(isCreated))
            {
                this.WeatherInfoMaster = ActiveWeatherInfoCollection.Active.ToObservableCollection();
            }
        }

        private bool canRemoveWeatherInfo(object obj)
        {
            return this.selectedWeatherInfo != null;
        }

        private void removeSelectedWeatherInfo(object obj)
        {
            ActiveWeatherInfoCollection.Active.Remove(this.selectedWeatherInfo);
            this.WeatherInfoMaster = ActiveWeatherInfoCollection.Active.ToObservableCollection();
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //TODO Use this method when moving navigation from View to ViewModel
        //      private bool canNavigateToMainPage(object obj)
        //      {
        //          return true;
        //      }
        #endregion
    }
}