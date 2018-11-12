using System.Collections.Generic;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    ///     Data binding for the currently active WeatherInformationCollection to be used throughout the application.
    /// </summary>
    public static class ActiveWeatherInfoCollection
    {
        #region Data members

        private static WeatherInfoCollection active;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the active WeatherInformationCollection.
        /// </summary>
        /// <value>
        ///     Sets the WeatherInformationCollection used ubiquitously throughout the application.
        /// </value>
        public static WeatherInfoCollection Active
        {
            get
            {
                if (active == null)
                {
                    active = new WeatherInfoCollection(string.Empty, new List<WeatherInfo>());
                }

                return active;
            }
            set => active = value;
        }

        #endregion
    }
}