using WeatherDataAnalysis.Model.Enums;

namespace WeatherDataAnalysis.Controller
{
    /// <summary>
    /// Controller for the Import processes.
    /// </summary>
    public class Import
    {
        #region Properties

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public ImportType Type { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Import"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public Import(ImportType type)
        {
            this.Type = type;
        }

        #endregion
    }
}