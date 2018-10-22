using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    /// Data binding for the currently active WeatherInformationCollection to be used throughout the application.
    /// </summary>
    public static class ActiveWeatherInfoCollection
    {
        /// <summary>
        /// Gets or sets the active WeatherInformationCollection.
        /// </summary>
        /// <value>
        /// Sets the WeatherInformationCollection used ubiquitously throughout the application.
        /// </value>
        public static WeatherInfoCollection Active { get; set; }

    }
}
