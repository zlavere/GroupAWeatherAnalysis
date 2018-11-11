using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Foundation.Collections;
using WeatherDataAnalysis.Extension;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    ///     Data bindings between summary and relevant data classes.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class SummaryViewModel : INotifyPropertyChanged
    {
        #region Data members

        private WeatherInfoCollectionsBinding allCollections;
        private WeatherInfoCollection activeCollection;
        private ObservableCollection<WeatherInfo> displayCollection;
        private ObservableCollection<WeatherInfo> highestTempsInActiveCollection;
        private ObservableCollection<WeatherInfo> highestLowTempsInActiveCollection;
        private ObservableCollection<WeatherInfo> lowestTempsInActiveCollection;
        private ObservableCollection<WeatherInfo> lowestHighTempsInActiveCollection;
        private ObservableCollection<WeatherInfo> highTempsAboveThresholdInActiveCollection;
        private ObservableCollection<WeatherInfo> lowTempsBelowThresholdInActiveCollection;
        private ObservableCollection<WeatherInfo> mostPrecipitationInActiveCollection;
        private int highTempThreshold;
        private int lowTempThreshold;
        private double averageHighTemp;
        private double averageLowTemp;
        private double totalPrecipitation;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets all collections.
        /// </summary>
        /// <value>
        ///     All collections.
        /// </value>
        public IObservableMap<string, WeatherInfoCollection> AllCollections
        {
            get => this.allCollections;
            set
            {
                this.allCollections = (WeatherInfoCollectionsBinding) value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the active collection.
        /// </summary>
        /// <value>
        /// The active collection.
        /// </value>
        public WeatherInfoCollection ActiveCollection
        {
            get => this.activeCollection;
            set
            {
                this.activeCollection = value;
                this.DisplayCollection = this.activeCollection.ToObservableCollection();
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the display collection.
        /// </summary>
        /// <value>
        /// The display collection.
        /// </value>
        public ObservableCollection<WeatherInfo> DisplayCollection
        {
            get
            {
                this.displayCollection = this.activeCollection.ToObservableCollection();
                return this.displayCollection;
            }
            set {
                this.displayCollection = value;
                this.OnPropertyChanged();
            }
        }


        /// <summary>
        ///     Gets or sets the highest temps in active collection.
        /// </summary>
        /// <value>
        ///     The highest temps in active collection.
        /// </value>
        public ObservableCollection<WeatherInfo> HighestTempDates
        {
            get
            {
                this.highestTempsInActiveCollection = this.findHighestTempsInActiveCollection();
                return this.highestTempsInActiveCollection;
            }
        }

        /// <summary>
        /// Gets the lowest temps in active collection.
        /// </summary>
        /// <value>
        /// The lowest temps in active collection.
        /// </value>
        public ObservableCollection<WeatherInfo> LowestTempDates
        {
            get
            {
                this.lowestTempsInActiveCollection = this.findLowestTempsInActiveCollection();
                return this.lowestTempsInActiveCollection;
            }
        }

        /// <summary>
        /// Gets the dates with the lowest high temp
        /// </summary>
        /// <value>
        /// The dates with the lowest high temp
        /// </value>
        public ObservableCollection<WeatherInfo> LowestHighTempDates
        {
            get
            {
                this.lowestHighTempsInActiveCollection = this.findLowestHighTempsInActiveCollection();
                return this.lowestHighTempsInActiveCollection;
            }
        }

        /// <summary>
        /// Gets the date(s) with highest low temp.
        /// </summary>
        /// <value>
        /// The date(s) with highest low temp.
        /// </value>
        public ObservableCollection<WeatherInfo> HighestLowTempDates
        {
            get
            {
                this.highestLowTempsInActiveCollection = this.findHighestLowTempsInActiveCollection();
                return this.highestLowTempsInActiveCollection;
            }
        }

        /// <summary>
        /// Gets the high temp above threshold dates.
        /// </summary>
        /// <value>
        /// The high temp above threshold dates.
        /// </value>
        public ObservableCollection<WeatherInfo> HighTempAboveThresholdDates
        {
            get
            {
                this.highTempsAboveThresholdInActiveCollection = this.findAllAboveHighTempThreshold();
                return this.highTempsAboveThresholdInActiveCollection;
            }
        }

        /// <summary>
        /// Gets the low temps below threshold dates.
        /// </summary>
        /// <value>
        /// The low temps below threshold dates.
        /// </value>
        public ObservableCollection<WeatherInfo> LowTempBelowThresholdDates
        {
            get
            {
                this.lowTempsBelowThresholdInActiveCollection = this.findAllBelowLowTempThreshold();
                return this.lowTempsBelowThresholdInActiveCollection;
            }
        }

        /// <summary>
        /// Gets the most precipitation dates.
        /// </summary>
        /// <value>
        /// The most precipitation dates.
        /// </value>
        public ObservableCollection<WeatherInfo> MostPrecipitationDates
        {
            get
            {
                this.mostPrecipitationInActiveCollection = this.findMostPrecipitationInActiveCollection();
                return this.mostPrecipitationInActiveCollection;
            }
        }

        /// <summary>
        /// Gets or sets the high temp threshold.
        /// </summary>
        /// <value>
        /// The high temp threshold.
        /// </value>
        public int HighTempThreshold
        {
            get => this.highTempThreshold;
            set
            {
                this.highTempThreshold = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the low temp threshold.
        /// </summary>
        /// <value>
        /// The low temp threshold.
        /// </value>
        public int LowTempThreshold
        {
            get => this.lowTempThreshold;
            set
            {
                this.lowTempThreshold = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the average high temperature.
        /// </summary>
        /// <value>
        /// The average high temperature.
        /// </value>
        public double AverageHighTemp
        {
            get
            {
                this.averageHighTemp = this.ActiveCollection.GetAverageHigh();
                return this.averageHighTemp;
            }
        }

        /// <summary>
        /// Gets the average low temperature.
        /// </summary>
        /// <value>
        /// The average low temperature.
        /// </value>
        public double AverageLowTemp
        {
            get
            {
                this.averageLowTemp = this.ActiveCollection.GetAverageLow();
                return this.averageLowTemp;
            }
        }

        /// <summary>
        /// Total precipitation in collection.
        /// </summary>
        /// <value>
        /// The total precipitation.
        /// </value>
        public double TotalPrecipitation
        {
            get
            {
                this.totalPrecipitation = this.ActiveCollection.TotalPrecipitation ?? 0;
                return this.totalPrecipitation;
            }
        }
        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SummaryViewModel" /> class.
        /// </summary>
        public SummaryViewModel()
        {
            this.AllCollections = new WeatherInfoCollectionsBinding();
            if (ActiveWeatherInfoCollection.Active != null)
            {
                this.ActiveCollection = ActiveWeatherInfoCollection.Active;
            } 
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<WeatherInfo> findHighestTempsInActiveCollection()
        {
            return this.ActiveCollection.FindWithHighestTemp().ToList().ToObservableCollection();
        }

        private ObservableCollection<WeatherInfo> findLowestTempsInActiveCollection()
        {
            return this.ActiveCollection.FindWithLowestTemp().ToList().ToObservableCollection();
        }

        private ObservableCollection<WeatherInfo> findLowestHighTempsInActiveCollection()
        {
            return this.ActiveCollection.FindLowestHighTemps().ToObservableCollection();
        }

        private ObservableCollection<WeatherInfo> findHighestLowTempsInActiveCollection()
        {
            return this.ActiveCollection.FindHighestLowTemps().ToList().ToObservableCollection();
        }

        private ObservableCollection<WeatherInfo> findMostPrecipitationInActiveCollection()
        {
            return this.ActiveCollection.FindWithMostPrecipitation().ToList().ToObservableCollection();
        }

        private ObservableCollection<WeatherInfo> findAllAboveHighTempThreshold()
        {
            return this.ActiveCollection.FindAllAboveHighTempThreshold(this.HighTempThreshold).ToList()
                                       .ToObservableCollection();
        }

        private ObservableCollection<WeatherInfo> findAllBelowLowTempThreshold()
        {
            return this.ActiveCollection.FindAllBelowLowTempThreshold(this.LowTempThreshold).ToList()
                                              .ToObservableCollection();
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}