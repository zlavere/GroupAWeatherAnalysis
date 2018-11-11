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
    public class DetailViewModel : INotifyPropertyChanged
    {
        #region Data members

        private ObservableCollection<WeatherInfo> weatherInfoMaster;
        private WeatherInfo selectedWeatherInfo;

        #endregion

        #region Properties

        public ObservableCollection<WeatherInfo> WeatherInfoMaster
        {
            get => this.weatherInfoMaster.OrderBy(weatherInfo => weatherInfo.Date).ToList().ToObservableCollection();
            set
            {
                this.weatherInfoMaster = value;
                this.OnPropertyChanged();
            }
        }

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

        public RelayCommand RemoveWeatherInfo { get; set; }
        public RelayCommand AddWeatherInfo { get; set; }

        #endregion

        #region Constructors

        public DetailViewModel()
        {
            this.WeatherInfoMaster = ActiveWeatherInfoCollection.Active.ToObservableCollection();
            this.SelectedWeatherInfoDetail = ActiveWeatherInfoCollection.Active.First();
            this.RemoveWeatherInfo = new RelayCommand(this.removeSelectedWeatherInfo, this.canRemoveWeatherInfo);
            this.AddWeatherInfo = new RelayCommand(this.createWeatherInfo, this.canCreateWeatherInfo);
        }

        #endregion

        #region Methods

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

        //TODO Use this method when moving navigation from View to ViewModel
        private bool canNavigateToMainPage(object obj)
        {
            return true;
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

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}