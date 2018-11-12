using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using WeatherDataAnalysis.IO;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.View;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Controller
{
    /// <summary>
    ///     Controller for the Import processes.
    /// </summary>
    public class MainPageController //TODO This class should not be responsible for generating output.
    {
        #region Properties


        private StorageFile File { get; set; }
        private WeatherInfoCollectionsBinding WeatherInfoCollections { get; }
        private ICollection<string> Errors { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainPageController" /> class.
        /// </summary>
        public MainPageController()
        {
            this.WeatherInfoCollections = new WeatherInfoCollectionsBinding();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Writes the active information to file.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public void WriteActiveInfoToFile(StorageFolder directory)
        {
           
        }


        /// <summary>
        ///     Sets the size of the histogram bucket.
        /// </summary>
        /// <param name="size">The size.</param>
        public void SetHistogramBucketSize(int size)
        {
            switch (size)
            {
                case 5:
                    HistogramSizeComboBoxBindings.ActiveSelection = 5;
                    break;
                case 10:
                    HistogramSizeComboBoxBindings.ActiveSelection = 10;
                    break;
                case 20:
                    HistogramSizeComboBoxBindings.ActiveSelection = 20;
                    break;
            }
        }

        private async Task<WeatherInfoCollection> performMergeTypeImportAsync(
            WeatherInfoCollection newWeatherInfoCollection)
        {
            var matchedDates = newWeatherInfoCollection.Where(weatherInfo =>
                ActiveWeatherInfoCollection.Active.Any(activeWeatherInfo =>
                    activeWeatherInfo.Date == weatherInfo.Date));
            var unmatchedDates = newWeatherInfoCollection.Where(weatherInfo =>
                ActiveWeatherInfoCollection.Active.All(activeWeatherInfo =>
                    activeWeatherInfo.Date != weatherInfo.Date));

            await this.requestUserMergePreference(matchedDates);

            foreach (var current in unmatchedDates)
            {
                ActiveWeatherInfoCollection.Active.Add(current);
            }

            return ActiveWeatherInfoCollection.Active;
        }

        private async Task<bool> requestUserMergePreference(IEnumerable<WeatherInfo> matchedDates)
        {
            //var mergeResult = new WeatherInfoCollection("Merge Result", new List<WeatherInfo>());
            foreach (var currentNew in matchedDates)
            {
                var matchingInfo =
                    ActiveWeatherInfoCollection.Active.First(weatherInfo => weatherInfo.Date == currentNew.Date);
                var mergeMatchDialog = new MergeMatchDialog();
                var matchingInfoDate = matchingInfo.Date.ToShortDateString();
                var matchingInfoHigh = matchingInfo.HighTemp.ToString();
                var matchingInfoLow = matchingInfo.LowTemp.ToString();
                var currentNewDate = currentNew.Date.ToShortDateString();
                var currentNewHigh = currentNew.HighTemp.ToString();
                var currentNewLow = currentNew.LowTemp.ToString();

                var data = new[] {
                    matchingInfoDate,
                    matchingInfoHigh,
                    matchingInfoLow,
                    currentNewDate,
                    currentNewHigh,
                    currentNewLow
                };

                var mergeMatchResult = await mergeMatchDialog.ShowDialog(data);
                if (mergeMatchResult == MergeMatchDialog.Replace)
                {
                    ActiveWeatherInfoCollection.Active.Remove(matchingInfo);
                    ActiveWeatherInfoCollection.Active.Add(currentNew);
                }
            }

            return true;
        }


        #endregion
    }
}