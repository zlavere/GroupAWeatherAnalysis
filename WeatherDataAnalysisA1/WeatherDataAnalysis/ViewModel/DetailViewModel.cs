using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WeatherDataAnalysis.Extension;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Utility;

namespace WeatherDataAnalysis.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        #region Data members

        private ObservableCollection<WeatherInfo> weatherInfoMaster;
        private WeatherInfo selectedSelectedWeatherInfo;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties

        public ObservableCollection<WeatherInfo> WeatherInfoMaster
        {
            get => this.weatherInfoMaster;
            set
            {
                this.weatherInfoMaster = value;
                this.OnPropertyChanged();
            }
        }

        public WeatherInfo SelectedWeatherInfoDetail
        {
            get => this.selectedSelectedWeatherInfo;
            set
            {
                this.selectedSelectedWeatherInfo = value;
                this.WeatherInfoMaster = ActiveWeatherInfoCollection.Active.ToObservableCollection();
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public DetailViewModel()
        {
            this.WeatherInfoMaster = ActiveWeatherInfoCollection.Active.ToObservableCollection();
            this.SelectedWeatherInfoDetail = ActiveWeatherInfoCollection.Active.First();
        }

        #endregion

        #region Methods

        

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            
        }

        #endregion
    }
}