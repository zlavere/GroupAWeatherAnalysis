using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Utility;

namespace WeatherDataAnalysis.ViewModel
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<WeatherInfo> weatherInfoMaster;
        private WeatherInfo selectedWeatherInfo;

        public ObservableCollection<WeatherInfo> WeatherInfoMaster { get => this.weatherInfoMaster; private set => this.weatherInfoMaster = value; }

        public WeatherInfo WeatherInfoDetail
        {
            get => this.selectedWeatherInfo;
            set
            {
                this.selectedWeatherInfo = value;
                this.OnPropertyChanged(nameof(this.WeatherInfoDetail));
            }
        }

        public DetailViewModel()
        {
            this.WeatherInfoMaster = ActiveWeatherInfoCollection.Active.ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
