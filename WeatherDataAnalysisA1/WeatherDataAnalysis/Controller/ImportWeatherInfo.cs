using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.View;

namespace WeatherDataAnalysis.Controller
{
    /// <summary>
    /// Controller to handle Import of Weather data from file format
    /// </summary>
    public class ImportWeatherInfo
    {
        #region Properties

        /// <summary>
        /// Gets or sets the error message list.
        /// </summary>
        /// <value>
        /// The error message list.
        /// </value>
        public IList<string> ErrorMessageList { get; set; }
        
        /// <summary>
        /// Creates new Weather Data Collection.
        /// </summary>
        /// <value>
        /// The new weather information collection.
        /// </value>
        private WeatherInfoCollection NewWeatherInfoCollection { get; set; }

        private ImportDialog ImportDialog { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportWeatherInfo"/> class.
        /// </summary>
        public ImportWeatherInfo()
        {
            this.ErrorMessageList = new List<string>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the new weather information collection.
        /// </summary>
        /// <returns></returns>
        public async Task<WeatherInfoCollection> CreateNewWeatherInfoCollection()
        {
            this.ImportDialog = new ImportDialog();
            var dialogComplete = await this.ImportDialog.StartDialog();

            if (dialogComplete)
            {
                this.NewWeatherInfoCollection = await this.getData();
            }

            return this.NewWeatherInfoCollection;
        }

        private async Task<WeatherInfoCollection> getData()
        {
            var fileReader = new FileLineGenerator();
            var lines = await fileReader.GetFileLines(this.ImportDialog.File);
            var weatherDataParser = new TemperatureParser();
            this.NewWeatherInfoCollection =
                weatherDataParser.GetWeatherInfoCollection(this.ImportDialog.CollectionName, lines);
            this.ErrorMessageList = weatherDataParser.ErrorMessages.ToList();

            return this.NewWeatherInfoCollection;
        }

        #endregion
    }
}