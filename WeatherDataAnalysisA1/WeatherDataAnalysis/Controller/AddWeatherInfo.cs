using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.View;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Controller
{
    /// <summary>
    /// Controller for creating a single data point of weather information.
    /// </summary>
    public class AddWeatherInfo
    {
        /// <summary>
        /// Gets the created weather information.
        /// </summary>
        /// <value>
        /// The created weather information.
        /// </value>
        public WeatherInfo CreatedWeatherInfo { get; private set; }

        private NewWeatherInfoDialog NewWeatherInfoDialog { get; set; }

        /// <summary>
        /// Starts the dialog to get user input from which new data will be added to the collection.
        /// </summary>
        /// <returns>Returns true if the data element is created successfully.</returns>
        public async Task<bool> StartDialog()
        {
            this.NewWeatherInfoDialog = new NewWeatherInfoDialog();
            var dialogResult = await this.NewWeatherInfoDialog.ShowDialog();
            

            if (dialogResult == NewWeatherInfoDialog.Submit)
            {
                this.CreatedWeatherInfo = new WeatherInfo(this.NewWeatherInfoDialog.Date, this.NewWeatherInfoDialog.HighTemp, this.NewWeatherInfoDialog.LowTemp);
            }
            else
            {
                return false;
            }

            return this.isCreatedWeatherInfoAdded();
        }

        private bool isCreatedWeatherInfoAdded()
        {
            var result = false;

            if (ActiveWeatherInfoCollection.Active == null)
            {
                this.addCreatedWeatherInfoToNewCollection(this.NewWeatherInfoDialog.CollectionName);
                result = true;
            }

            if (this.NewWeatherInfoDialog.IsOverwriteAllowed() && this.checkIfActiveCollectionContainsSameDate())
            {
                this.addCreatedWeatherInfo();
                result = true;
            }

            if (!this.NewWeatherInfoDialog.IsOverwriteAllowed() && !this.checkIfActiveCollectionContainsSameDate())
            {
                this.addCreatedWeatherInfo();
                result = true;
            }

            return result;
        }

        private void addCreatedWeatherInfo()
        {
             ActiveWeatherInfoCollection.Active.Add(this.CreatedWeatherInfo); 
        }

        private void addCreatedWeatherInfoToNewCollection(string name)
        {
            ActiveWeatherInfoCollection.Active = new WeatherInfoCollection(name, new List<WeatherInfo>{this.CreatedWeatherInfo});
        }

        private bool checkIfActiveCollectionContainsSameDate()
        {
            return ActiveWeatherInfoCollection.Active.Any(weatherInfo =>
                weatherInfo.Date == this.CreatedWeatherInfo.Date);
        }
    }
}
