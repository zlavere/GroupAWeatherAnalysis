using System.Collections.Generic;

namespace WeatherDataAnalysis.Model
{
    internal class WeatherCollection
    {
        #region Properties

        public List<Weather> Collection { get; set; }

        #endregion

        #region Constructors

        public WeatherCollection(List<Weather> weatherCollection)
        {
            this.Collection = weatherCollection;
        }

        #endregion

        #region Methods
        //TODO Create private methods to get highest and another to get lowest from List<int> pass List<int> generated from all high or low temps for the year to eliminate code reuse that way only one method is created for getting highest and getting lowest - keep names below for public methods.
        //TODO Use linq dummy
        public List<Weather> GetHighestTempDates()
        {
            var highestTemperatureDates = new List<Weather>();
            Weather highest = null;

            foreach (var current in this.Collection)
            {
                if (highest == null)
                {
                    highest = current;
                    highestTemperatureDates.Add(current);
                }
                else if (highest.HighTemp == current.HighTemp)
                {
                    highestTemperatureDates.Add(current);
                }
                else if (highest.HighTemp < current.HighTemp && highestTemperatureDates.Count > 1)
                {
                    highestTemperatureDates.Clear();
                    highestTemperatureDates.Add(current);
                }
                else if (highest.HighTemp < current.HighTemp)
                {
                    highestTemperatureDates.Remove(highest);
                    highestTemperatureDates.Add(current);
                    highest = current;
                }
            }

            return highestTemperatureDates;
        }


        public List<Weather> GetHighestLowTempDates()
        {
            var highestLowTempDates = new List<Weather>();
            Weather highest = null;

            foreach (var current in this.Collection)
            {
                if (highest == null)
                {
                    highest = current;
                    highestLowTempDates.Add(current);
                }
                else if (highest.LowTemp == current.LowTemp)
                {
                    highestLowTempDates.Add(current);
                }
                else if (highest.LowTemp < current.LowTemp && highestLowTempDates.Count > 1)
                {
                    highestLowTempDates.Clear();
                    highestLowTempDates.Add(current);
                }
                else if (highest.LowTemp < current.LowTemp)
                {
                    highestLowTempDates.Remove(highest);
                    highestLowTempDates.Add(current);
                    highest = current;
                }
            }

            return highestLowTempDates;
        }

        public List<Weather> GetLowestTempDates()
        {
            var lowestTempDates = new List<Weather>();
            Weather lowest = null;

            foreach (var current in this.Collection)
            {
                if (lowest == null)
                {
                    lowest = current;
                    lowestTempDates.Add(current);
                }
                else if (lowest.LowTemp == current.LowTemp)
                {
                    lowestTempDates.Add(current);
                }
                else if (lowest.LowTemp > current.HighTemp && lowestTempDates.Count > 1)
                {
                    lowestTempDates.Clear();
                    lowestTempDates.Add(current);
                }
                else if (lowest.LowTemp > current.HighTemp)
                {
                    lowestTempDates.Remove(lowest);
                    lowestTempDates.Add(current);
                    lowest = current;
                }
            }

            return lowestTempDates;
        }

        public List<Weather> GetLowestHighTempDates()
        {
            var lowestHighTempDates = new List<Weather>();
            Weather lowest = null;

            foreach (var current in this.Collection)
            {
                if (lowest == null)
                {
                    lowest = current;
                    lowestHighTempDates.Add(current);
                }
                else if (lowest.HighTemp == current.HighTemp)
                {
                    lowestHighTempDates.Add(current);
                }
                else if (lowest.HighTemp > current.HighTemp && lowestHighTempDates.Count > 1)
                {
                    lowestHighTempDates.Clear();
                    lowestHighTempDates.Add(current);
                }
                else if (lowest.HighTemp > current.HighTemp)
                {
                    lowestHighTempDates.Remove(lowest);
                    lowestHighTempDates.Add(current);
                    lowest = current;
                }
            }

            return lowestHighTempDates;
        }

        #endregion
    }
}