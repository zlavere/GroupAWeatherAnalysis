using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Provides analytic functions for collections of WeatherInfo.
    /// </summary>
    public class WeatherInfoCollection : IList<WeatherInfo>
    {
        #region Properties

        private IList<WeatherInfo> WeatherInfos { get; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        /// <value>
        ///     The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        ///     Gets or sets the key value pair.
        /// </summary>
        /// <value>
        ///     The key value pair.
        /// </value>
        private KeyValuePair<string, WeatherInfoCollection> NameCollectionPair { get; }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count => this.WeatherInfos.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly => this.WeatherInfos.IsReadOnly;

        /// <summary>
        /// Gets or sets the <see cref="WeatherInfo"/> at the specified index.
        /// </summary>
        /// <value>
        /// The <see cref="WeatherInfo"/>.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public WeatherInfo this[int index]
        {
            get => this.WeatherInfos[index];
            set => this.WeatherInfos[index] = value;
        }

        /// <summary>
        /// Gets the highest temperature.
        /// </summary>
        /// <value>
        /// The highest temperature.
        /// </value>
        public int HighestTemp => this.WeatherInfos.Max(temp => temp.HighTemp);

        /// <summary>
        /// Gets the lowest temperature.
        /// </summary>
        /// <value>
        /// The lowest temperature.
        /// </value>
        public int LowestTemp => this.WeatherInfos.Min(temp => temp.LowTemp);

        /// <summary>
        /// Gets the highest precipitation.
        /// </summary>
        /// <value>
        /// The highest precipitation.
        /// </value>
        public double? HighestPrecipitation => this.WeatherInfos.Max(precipitation => precipitation.Precipitation);
        /// <summary>
        /// Gets the total precipitation.
        /// </summary>
        /// <value>
        /// The total precipitation.
        /// </value>
        public double? TotalPrecipitation => this.WeatherInfos.Sum(precipitation => precipitation.Precipitation);
        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Model.WeatherInfoCollection" /> class.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="weatherInfos">The collection of weather information.</param>
        public WeatherInfoCollection(string name, IList<WeatherInfo> weatherInfos)
        {
            this.WeatherInfos = weatherInfos;
            this.Name = name;
            this.NameCollectionPair = new KeyValuePair<string, WeatherInfoCollection>(this.Name, this);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        public void Add(WeatherInfo item)
        {
            this.WeatherInfos.Add(item);
        }
        
        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            this.WeatherInfos.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains(WeatherInfo item)
        {
            return this.WeatherInfos.Contains(item);
        }

        /// <summary>
        ///     Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an
        ///     <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements
        ///     copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see>
        ///     must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(WeatherInfo[] array, int arrayIndex)
        {
            this.WeatherInfos.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>;
        ///     otherwise, false. This method also returns false if item is not found in the original
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        public bool Remove(WeatherInfo item)
        {
            return this.WeatherInfos.Remove(item);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<WeatherInfo> GetEnumerator()
        {
            return this.WeatherInfos.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.WeatherInfos.GetEnumerator();
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"></see>.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"></see>.</param>
        /// <returns>
        /// The index of item if found in the list; otherwise, -1.
        /// </returns>
        public int IndexOf(WeatherInfo item)
        {
            return this.WeatherInfos.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"></see> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"></see>.</param>
        public void Insert(int index, WeatherInfo item)
        {
            this.WeatherInfos.Insert(index, item);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1"></see> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        public void RemoveAt(int index)
        {
            this.WeatherInfos.RemoveAt(index);
        }

        private IDictionary<int, List<WeatherInfo>> groupByYear()
        {
            var years = this.WeatherInfos.Select(weather => weather.Date.Year).Distinct().ToList();
            var dictionary = new Dictionary<int, List<WeatherInfo>>();
            foreach (var current in years)
            {
                var currentList = this.WeatherInfos.Where(weather => weather.Date.Year == current).ToList();
                dictionary.Add(current, currentList);
            }

            return dictionary;
        }

        /// <summary>
        ///     Groups the by month.
        /// </summary>
        /// <returns></returns>
        public IDictionary<int, IDictionary<int, List<WeatherInfo>>> GroupByMonth()
        {
            var groupedByYear = (Dictionary<int, List<WeatherInfo>>) this.groupByYear();

            var dictionary = new Dictionary<int, IDictionary<int, List<WeatherInfo>>>();

            foreach (var year in groupedByYear.Keys)
            {
                var monthDictionary = this.monthDictionary(year);

                dictionary.Add(year, monthDictionary);
            }

            return dictionary;
        }

        private Dictionary<int, List<WeatherInfo>> monthDictionary(int year)
        {
            var monthDictionary = new Dictionary<int, List<WeatherInfo>>();
            for (var month = 1; month <= 12; month++)
            {
                var weatherInfoForMonth = this.WeatherInfos
                                              .Where(weather =>
                                                  weather.Date.Year == year && weather.Date.Month == month)
                                              .ToList();
                monthDictionary.Add(month, weatherInfoForMonth);
            }

            return monthDictionary;
        }

        //TODO Remove or change these to return WeatherInfoCollections - duplicated methods?
        /// <summary>
        ///     Gets the highest temps.
        /// </summary>
        /// <returns>List of Weather with the highest temps.</returns>
        public ICollection<WeatherInfo> FindWithHighestTemp()
        {
            var highest = this.WeatherInfos.Max(weather => weather.HighTemp);

            return this.WeatherInfos.Where(temp => temp.HighTemp == highest)
                       .ToList();
        }

        /// <summary>
        /// Gets the lowest temps.
        /// </summary>
        /// <returns>List of Weather with the lowest temps.</returns>
        public ICollection<WeatherInfo> FindWithLowestTemp()
        {
            var lowest = this.WeatherInfos.Min(weather => weather.LowTemp);
            var lowTemps =
                this.WeatherInfos.Where(temp => temp.LowTemp == lowest).ToList();
            return lowTemps;
        }
        /// <summary>
        ///     Gets the highest precipitation.
        /// </summary>
        /// <returns>List of Weather with the highest temps.</returns>
        public ICollection<WeatherInfo> FindWithHighestPrecipitation()
        {
            var highest = this.WeatherInfos.Max(weather => weather.Precipitation);

            return this.WeatherInfos.Where(precipitation => precipitation.Precipitation.Equals(highest))
                       .ToList();
        }
        /// <summary>
        ///     Gets the highest low temps.
        /// </summary>
        /// <returns>List of Weather with the highest low temps.</returns>
        public ICollection<WeatherInfo> FindHighestLowTemps()
        {
            var highest = this.WeatherInfos.Max(weather => weather.LowTemp);
            var highestTemps =
                this.WeatherInfos.Where(temp => temp.LowTemp == highest).ToList();

            return highestTemps;
        }

        /// <summary>
        ///     Gets the lowest high temps.
        /// </summary>
        /// <returns>List of Weather with the lowest high temps.</returns>
        public List<WeatherInfo> FindLowestHighTemps()
        {
            var lowest = this.WeatherInfos.Min(weather => weather.HighTemp);
            var lowTemps =
                this.WeatherInfos.Where(temp => temp.HighTemp == lowest).ToList();

            return lowTemps;
        }

        /// <summary>
        ///     Gets the average high.
        /// </summary>
        /// <returns>Average High Temperature for WeatherInfoCollection. Returns Max Integer Value on Error.</returns>
        public double GetAverageHigh()
        {
            double averageHigh;
            try
            {
               averageHigh  = this.WeatherInfos.Average(weather => weather.HighTemp);
            }
            catch (Exception)
            {
                averageHigh = int.MaxValue;
            }
            
            return averageHigh;
        }

        /// <summary>
        ///     Gets the average low.
        /// </summary>
        /// <returns>Average High Temperature for WeatherInfoCollection</returns>
        public double GetAverageLow()
        {
            var result = double.MinValue;
            try
            {
                result = this.WeatherInfos.Average(weather => weather.LowTemp);
            }
            catch (Exception)
            {
                //ignored
            }

            return result;
        }

        //TODO return statements docs
        /// <summary>
        ///     Gets the highest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public ICollection<WeatherInfo> GetHighestInMonth(int month)
        {
            var weatherByMonthList = this.WeatherInfos.Where(weather => weather.Date.Month == month).ToList();
            var highInMonth = weatherByMonthList.Max(weather => weather.HighTemp);

            return weatherByMonthList.Where(weather => weather.HighTemp == highInMonth).ToList();
        }

        /// <summary>
        ///     Gets the lowest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public IList<WeatherInfo> GetLowestInMonth(int month)
        {
            var weatherByMonthList = this.WeatherInfos.Where(weather => weather.Date.Month == month).ToList();
            var lowInMonth = weatherByMonthList.Min(weather => weather.LowTemp);

            return weatherByMonthList.Where(weather => weather.LowTemp == lowInMonth).ToList();
        }

        /// <summary>
        ///     Gets the high average for month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public double GetHighAverageForMonth(int month)
        {
            var weatherByMonthList = this.WeatherInfos.Where(weather => weather.Date.Month == month).ToList();

            return weatherByMonthList.Average(weather => weather.HighTemp);
        }

        /// <summary>
        ///     Gets the low average for month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public double GetLowAverageForMonth(int month)
        {
            var weatherByMonth = this.WeatherInfos.Where(weather => weather.Date.Month == month).ToList();

            return weatherByMonth.Average(weather => weather.LowTemp);
        }

        /// <summary>
        /// Finds all above high temperature threshold.
        /// </summary>
        /// <param name="highThreshold">The high threshold.</param>
        /// <returns></returns>
        public IList<WeatherInfo> FindAllAboveHighTempThreshold(int highThreshold)
        {
           return this.WeatherInfos.Where(weatherInfo => weatherInfo.HighTemp >= highThreshold).ToList();
        }

        /// <summary>
        /// Finds all below low temperature threshold.
        /// </summary>
        /// <param name="lowTempThreshold">The low temperature threshold.</param>
        /// <returns></returns>
        public IList<WeatherInfo> FindAllBelowLowTempThreshold(int lowTempThreshold)
        {
            return  this.WeatherInfos.Where(weatherInfo =>
                weatherInfo.LowTemp <= lowTempThreshold).ToList();
        }

        #endregion
    }
}