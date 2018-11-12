using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAnalysis.ViewModel
{
    public class MainPageViewModel :INotifyPropertyChanged
    {
        public int tempHistogramBucketSize;
        public double precipitationHistogramBucketSize;
        public int year;

        public int YearSelected
        {
            get
            {
                return this.year;
            }

            set
            {
                this.year = value;
                this.OnPropertyChanged();
            }
        }

        public int TempHistogramBucketSize
        {
            get
            {
                return this.tempHistogramBucketSize;
            }

            set
            {
                this.tempHistogramBucketSize = value;
                this.OnPropertyChanged();
            }
        }

        public double PrecipitationHistogramBucketSize
        {
            get
            {
                return this.precipitationHistogramBucketSize;
            }

            set
            {
                this.precipitationHistogramBucketSize = value;
                this.OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
    }


