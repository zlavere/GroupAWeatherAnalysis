using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace WeatherDataAnalysis.Model
{
    /// <summary>
    ///     Provides analytic functions for collections of WeatherInfo.
    /// </summary>
    public class WeatherInfoCollection:ICollection<WeatherInfo>
    {
        #region Properties

        public int Count => this.WeatherInfos.Count;

        public bool IsReadOnly => ((ICollection<WeatherInfo>)this.WeatherInfos).IsReadOnly;

        private List<WeatherInfo> WeatherInfos { get; set; }

        private IEnumerable<int> HighTemps { get; set; }

        private IEnumerable<int> LowTemps { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Model.WeatherInfoCollection" /> class.
        /// </summary>

        /// <param name="weatherInfos">The collection of weather information.</param>
        public WeatherInfoCollection(IEnumerable<WeatherInfo> weatherInfos)
        {
            this.WeatherInfos = (List<WeatherInfo>)weatherInfos;

            this.LowTemps = this.WeatherInfos.Select(temps => temps.LowTemp);

            this.HighTemps = this.WeatherInfos.Select(temps => temps.HighTemp);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the highest temps.
        /// </summary>
        /// <returns>List of Weather with the highest temps.</returns>
        public List<WeatherInfo> FindWithHighest()
        {
            var highest = this.WeatherInfos.Max(weather => weather.HighTemp);

            return this.WeatherInfos.Where(temp => temp.HighTemp == highest)
                    .ToList();
        }

        /// <summary>
        ///     Gets the highest low temps.
        /// </summary>
        /// <returns>List of Weather with the highest low temps.</returns>
        public List<WeatherInfo> FindWithHighestLow()
        {

            var highest = this.WeatherInfos.Max(weather => weather.LowTemp);
            var highestTemps =
                this.WeatherInfos.Where(temp => temp.LowTemp == highest).ToList();

            return highestTemps;
        }

        /// <summary>
        ///     Gets the lowest temps.
        /// </summary>
        /// <returns>List of Weather with the lowest temps.</returns>
        public List<WeatherInfo> GetLowestTemps()
        {

            var lowest = this.WeatherInfos.Min(weather => weather.LowTemp);
            var lowTemps =
                this.WeatherInfos.Where(temp => temp.LowTemp == lowest).ToList();
            return lowTemps;
        }

        public double GetAverageHigh()
        {
            return this.WeatherInfos.Average(weather => weather.HighTemp);
        }

        public double GetAverageLow()
        {
            return this.WeatherInfos.Average(weather => weather.LowTemp);
        }

        /// <summary>
        ///     Gets the lowest high temps.
        /// </summary>
        /// <returns>List of Weather with the lowest high temps.</returns>
        public List<WeatherInfo> GetLowestHighTemps()
        {
            var lowest = this.WeatherInfos.Min(weather => weather.HighTemp);
            var lowTemps =
                this.WeatherInfos.Where(temp => temp.HighTemp == lowest).ToList();

            return lowTemps;
        }


        /// <summary>
        ///     Gets the days above 90.
        /// </summary>
        /// <param name="highTemp"></param>
        /// <returns>Weather objects where high above 90</returns>
        public List<WeatherInfo> GetDaysAbove(int highTemp)
        {
            return this.WeatherInfos.Where(weather => weather.HighTemp >= highTemp).ToList();
        }

        /// <summary>
        ///     Gets the days below 32.
        /// </summary>
        /// <returns>Weather objects where high below 32</returns>
        public List<WeatherInfo> GetDaysBelow(int lowTemp)
        {
            return this.WeatherInfos.Where(weather => weather.LowTemp <= lowTemp).ToList();
        }
        ///<summary>
        /// Finds WeatherInfos with high temps above temp parameter
        /// </summary>
        /// <returns>WeatherInfo collection where high above temp</returns>
        public IEnumerable<WeatherInfo> FindDaysAbove(int temp)
        {
            return this.WeatherInfos.Where(weather => weather.HighTemp >= temp).ToList();
        }

        /// <summary>
        /// Find below temp parameter.
        /// </summary>
        /// <returns>WeatherInfo collection where low below temp parameter</returns>
        public IEnumerable<WeatherInfo> FindDaysBelow(int temp)
        {
            return this.WeatherInfos.Where(weather => weather.LowTemp <= temp).ToList();
        }

        //TODO return statements docs
        /// <summary>
        ///     Gets the highest in month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public List<WeatherInfo> GetHighestInMonth(int month)
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
        public List<WeatherInfo> GetLowestInMonth(int month)
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

        public void Add(WeatherInfo item)
        {
            this.WeatherInfos.Add(item);
        }

        public void Clear()
        {
            this.WeatherInfos.Clear();
        }

        public bool Contains(WeatherInfo item)
        {
            return this.WeatherInfos.Contains(item);
        }

        public void CopyTo(WeatherInfo[] array, int arrayIndex)
        {
            this.WeatherInfos.CopyTo(array, arrayIndex);
        }

        public bool Remove(WeatherInfo item)
        {
            return this.WeatherInfos.Remove(item);
        }

        public IEnumerator<WeatherInfo> GetEnumerator()
        {
            return ((ICollection<WeatherInfo>)this.WeatherInfos).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<WeatherInfo>)this.WeatherInfos).GetEnumerator();
        }

        #endregion
    }
}