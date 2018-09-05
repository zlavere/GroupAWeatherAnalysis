using System.Collections.Generic;
using System.Linq;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Provides analytic functions for sets of Weather objects.
    /// </summary>
    public class TemperatureByDayCollection
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the collection.
        /// </summary>
        /// <value>
        ///     The collection.
        /// </value>
        private List<TemperatureByDay> Collection { get; }

        /// <summary>
        ///     Gets or sets the high temps.
        /// </summary>
        /// <value>
        ///     The high temps.
        /// </value>
        private List<int> HighTemps { get; }

        /// <summary>
        ///     Gets or sets the low temps.
        /// </summary>
        /// <value>
        ///     The low temps.
        /// </value>
        private List<int> LowTemps { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemperatureByDayCollection" /> class.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        public TemperatureByDayCollection(List<TemperatureByDay> weatherCollection)
        {
            this.Collection = weatherCollection;

            this.LowTemps = (from weather in this.Collection
                             select weather.LowTemp).ToList();

            this.HighTemps = (from weather in this.Collection
                              select weather.HighTemp).ToList();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the highest temps.
        /// </summary>
        /// <returns>List of Weather with the highest temps.</returns>
        public List<TemperatureByDay> GetHighestTemps()
        {
            var highest = this.Collection.Max(weather => weather.HighTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.HighTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        ///     Gets the highest low temps.
        /// </summary>
        /// <returns>List of Weather with the highest low temps.</returns>

        //TODO WHY DOESN'T THIS WORK LIKE THE OTHERS!?!?!?!?!?!?!?!?
        public List<TemperatureByDay> GetHighestLowTemps()
        {
            var highest = this.Collection.Max(weather => weather.LowTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.LowTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        ///     Gets the lowest temps.
        /// </summary>
        /// <returns>List of Weather with the lowest temps.</returns>
        public List<TemperatureByDay> GetLowestTemps()
        {
            var lowest = this.Collection.Min(weather => weather.LowTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.LowTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        ///     Gets the lowest high temps.
        /// </summary>
        /// <returns>List of Weather with the lowest high temps.</returns>
        public List<TemperatureByDay> GetLowestHighTemps()
        {
            var lowest = this.Collection.Min(weather => weather.HighTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.HighTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        ///     Gets the average high temp.
        /// </summary>
        /// <returns>The average high temp.</returns>
        public double GetAverageHighTemp()
        {
            return this.HighTemps.Average();
        }

        /// <summary>
        ///     Gets the average low temp.
        /// </summary>
        /// <returns>The average low temp.</returns>
        public double GetAverageLowTemp()
        {
            return this.LowTemps.Average();
        }

        public List<TemperatureByDay> GetDaysAbove90()
        {
            return this.Collection.Where(weather => weather.HighTemp >= 90).ToList();
        }

        public List<TemperatureByDay> GetDaysBelow32()
        {
            return this.Collection.Where(weather => weather.LowTemp <= 32).ToList();
        }

        

        #endregion
    }
}