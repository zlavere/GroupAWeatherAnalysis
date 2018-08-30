using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WeatherDataAnalysis.Model
{
    internal class WeatherCollection
    {
        #region Properties

        public List<Weather> Collection { get; set; }
        public List<int> HighTemps { get; set; }
        public List<int> LowTemps { get; set; }

        #endregion

        #region Constructors

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

        public List<Weather> GetHighestTemps()
        {
            var highestTemps =
                (this.Collection.Where(temp => temp.HighTemp == this.Collection.Max(weather => weather.HighTemp)))
                .ToList();
            return highestTemps;
        }

        public List<Weather> GetHighestLowTemps()
        {
            var highestTemps =
                (this.Collection.Where(temp => temp.LowTemp == this.Collection.Max(weather => weather.LowTemp)))
                .ToList();
            return highestTemps;
        }

        public List<Weather> GetLowestTemps()
        {
            var lowTemps =
                (this.Collection.Where(temp => temp.LowTemp == this.Collection.Min(weather => weather.LowTemp)))
                .ToList();
            return lowTemps;
        }

        public List<Weather> GetLowestHighTemps()
        {
            var lowTemps =
                (this.Collection.Where(temp => temp.HighTemp == this.Collection.Min(weather => weather.HighTemp)))
                .ToList();
            return lowTemps;
        }

        public double GetAverageHighTemp()
        {
            return this.HighTemps.Average();
        }

        public double GetAverageLowTemp()
        {
            return this.LowTemps.Average();
        }

        #endregion
    }
}