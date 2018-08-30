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
            var highest = this.Collection.Max(weather => weather.HighTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.HighTemp == highest)
                    .ToList();
            return highestTemps;
        }

        public List<Weather> GetHighestLowTemps()
        {
            var highest = this.Collection.Max(weather => weather.LowTemp);
            var highestTemps =
                this.Collection.Where(temp => temp.LowTemp == highest)
                    .ToList();
            return highestTemps;
        }

        public List<Weather> GetLowestTemps()
        {
            var lowest = this.Collection.Min(weather => weather.LowTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.LowTemp == lowest)
                    .ToList();
            return lowTemps;
        }

        public List<Weather> GetLowestHighTemps()
        {
            var lowest = this.Collection.Min(weather => weather.HighTemp);
            var lowTemps =
                this.Collection.Where(temp => temp.HighTemp == lowest)
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