using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherDataAnalysis.Controller;
using WeatherDataAnalysis.Extension;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Utility;

namespace WeatherDataAnalysis.ViewModel
{
    /// <inheritdoc />
    /// <summary>
    ///     Data bindings between summary and relevant data classes.
    /// </summary>
    /// <seealso cref="T:System.ComponentModel.INotifyPropertyChanged" />
    public class SummaryViewModel : INotifyPropertyChanged
    {
        #region Data members

        private WeatherInfoCollectionsBinding allCollections;
        private WeatherInfoCollection activeCollection;
        private ObservableCollection<WeatherInfoCollection> activeCollectionGroupedByYear;
        private int highTempThreshold;
        private int lowTempThreshold;

        #endregion

        #region Properties

        /// <summary>
        /// RelayCommand to import weather information.
        /// </summary>
        /// <value>
        /// RelayCommand import weather information.
        /// </value>
        public RelayCommand ImportWeatherInfo { get; private set; }

        /// <summary>
        /// Gets the active collection grouped by year.
        /// </summary>
        /// <value>
        /// The active collection grouped by year.
        /// </value>
        public ObservableCollection<WeatherInfoCollection> ActiveCollectionGroupedByYear
        {
            get => this.activeCollectionGroupedByYear;
            private set
            {
                this.activeCollectionGroupedByYear = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets all collections.
        /// </summary>
        /// <value>
        ///     All collections.
        /// </value>
        private WeatherInfoCollectionsBinding AllCollections
        {
            get => this.allCollections;
            set
            {
                this.allCollections = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the active collection.
        /// </summary>
        /// <value>
        ///     The active collection.
        /// </value>
        private WeatherInfoCollection ActiveCollection
        {
            get => this.activeCollection;
            set
            {
                this.activeCollection = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the high temp threshold.
        /// </summary>
        /// <value>
        ///     The high temp threshold.
        /// </value>
        public int HighTempThreshold
        {
            get => this.highTempThreshold;
            set
            {
                this.highTempThreshold = value;
                ActiveWeatherInfoCollection.Active.HighTempThreshold = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets or sets the low temp threshold.
        /// </summary>
        /// <value>
        ///     The low temp threshold.
        /// </value>
        public int LowTempThreshold
        {
            get => this.lowTempThreshold;
            set
            {
                this.lowTempThreshold = value;
                ActiveWeatherInfoCollection.Active.LowTempThreshold = value;
                this.OnPropertyChanged();
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
            this.HighTempThreshold = 90;
            this.LowTempThreshold = 32;

            if (ActiveWeatherInfoCollection.Active != null)
            {
                this.ActiveCollection = ActiveWeatherInfoCollection.Active;
            }

            this.initializeCommands();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        private void initializeCommands()
        {
            this.ImportWeatherInfo = new RelayCommand(this.executeImport, canExecuteImport);
        }

        private async void executeImport(object obj)
        {
            var importController = new ImportWeatherInfo();
            var newCollection = await importController.CreateNewWeatherInfoCollection();

            if (newCollection != null)
            {
                this.allCollections.Add(newCollection.Name, newCollection);
                this.ActiveCollectionGroupedByYear = this.AllCollections.CollectionsByYear.ToObservableCollection();
                ActiveWeatherInfoCollection.Active = newCollection;
            }
        }

        private static bool canExecuteImport(object obj)
        {
            return true;
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}