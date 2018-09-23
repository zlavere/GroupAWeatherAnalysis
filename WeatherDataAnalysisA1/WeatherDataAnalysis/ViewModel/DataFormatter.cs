using WeatherDataAnalysis.Format;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    ///     All Formatters for WeatherInfo
    /// </summary>
    public class DataFormatter
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the temperature data formatter.
        /// </summary>
        /// <value>
        ///     The temperature data formatter.
        /// </value>
        public TemperatureDataFormatter TemperatureDataFormatter { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataFormatter" /> class.
        /// </summary>
        public DataFormatter()
        {
            this.TemperatureDataFormatter = new TemperatureDataFormatter();
        }

        #endregion
    }
}