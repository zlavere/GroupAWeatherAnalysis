using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.View;

namespace WeatherDataAnalysis.Controller
{
    public class ImportWeatherInfo
    {
        #region Properties

        public IList<string> ErrorMessageList { get; set; }
        public WeatherInfoCollection NewWeatherInfoCollection { get; private set; }

        private ImportDialog ImportDialog { get; set; }

        #endregion

        #region Constructors

        public ImportWeatherInfo()
        {
            this.ErrorMessageList = new List<string>();
        }

        #endregion

        #region Methods

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