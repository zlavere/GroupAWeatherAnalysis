﻿using System.Collections.Generic;
using System.Linq;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    /// Provides analytic functions for sets of Weather objects.
    /// </summary>
    internal class WeatherCollection
    {
        #region Properties

        public List<Weather> Collection { get; set; }
        public List<int> HighTemps { get; set; }
        public List<int> LowTemps { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherCollection"/> class.
        /// </summary>
        /// <param name="weatherCollection">The weather collection.</param>
        public WeatherCollection(List<Weather> weatherCollection)
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
        /// Gets the highest temps.
        /// </summary>
        /// <returns>List of Weather with the highest temps.</returns>
        public List<Weather> GetHighestTemps()
        {
            var highest = this.Collection.Max(weather => weather.HighTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.HighTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        /// Gets the highest low temps.
        /// </summary>
        /// <returns>List of Weather with the highest low temps.</returns>
        public List<Weather> GetHighestLowTemps()
        {
            var highest = this.Collection.Max(weather => weather.LowTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.LowTemp == highest)
                    .ToList();
            return highestTemps;
        }

        /// <summary>
        /// Gets the lowest temps.
        /// </summary>
        /// <returns>List of Weather with the lowest temps.</returns>
        public List<Weather> GetLowestTemps()
        {
            var lowest = this.Collection.Min(weather => weather.LowTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.LowTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        /// Gets the lowest high temps.
        /// </summary>
        /// <returns>List of Weather with the lowest high temps.</returns>
        public List<Weather> GetLowestHighTemps()
        {
            var lowest = this.Collection.Min(weather => weather.HighTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.HighTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        /// <summary>
        /// Gets the average high temp.
        /// </summary>
        /// <returns>The average high temp.</returns>
        public double GetAverageHighTemp()
        {
            return this.HighTemps.Average();
        }

        /// <summary>
        /// Gets the average low temp.
        /// </summary>
        /// <returns>The average low temp.</returns>
        public double GetAverageLowTemp()
        {
            return this.LowTemps.Average();
        }

        #endregion
    }
}