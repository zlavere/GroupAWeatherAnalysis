using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Model.Enums;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Format
{
    /// <summary>
    ///     Generates high and low temperature histograms based on a collection of weather data.
    /// </summary>
    public class WeatherHistogramGenerator
    {
        #region Properties

        private HistogramBucketSize HistogramBucketSize { get; set; }
        private double PrecipitationBucketSize { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherHistogramGenerator" /> class.
        /// </summary>
        public WeatherHistogramGenerator()
        {
            this.HistogramBucketSize = HistogramBucketSize.Ten;
            this.PrecipitationBucketSize = Model.Enums.PrecipitationBucketSize.QuarterInch;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Creates the histogram.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        public string CreateTempHistogram(IEnumerable<WeatherInfo> collection)
        {
            var weatherInfos = collection.ToList();
            var highTemps = weatherInfos.Select(temp => temp.HighTemp);
            var lowTemps = weatherInfos.Select(temp => temp.LowTemp);
            this.HistogramBucketSize = (HistogramBucketSize) HistogramSizeComboBoxBindings.ActiveSelection;
            var output = $"High Temperature Histogram {Environment.NewLine}" +
                         $"{this.evaluateTempRanges(highTemps)} {Environment.NewLine}" +
                         $"Low Temperature Histogram {Environment.NewLine}" +
                         $"{this.evaluateTempRanges(lowTemps)}";
            return output;
        }

        public string CreatePrecipitationHistogram(IEnumerable<WeatherInfo> collection)
        {
            var weatherInfos = collection.ToList();
            var precipitations = weatherInfos.Select(precipitation => precipitation.Precipitation);

            //TODO set range for histogram
            var output = $"High Precipitation Histogram {Environment.NewLine}" +
                         $"{this.evaluatePrecipitationRanges(precipitations)} {Environment.NewLine}";
            return output;
        }

        private string evaluateTempRanges(IEnumerable<int> temps)
        {
            var temperatures = temps.ToList();
        
            var lowest = temperatures.Min(temp => temp);
            var highest = temperatures.Max(temp => temp);

            if (lowest % (int) this.HistogramBucketSize != 0)
            {
                lowest = lowest - lowest % (int) this.HistogramBucketSize;
            }

            if (highest % (int) this.HistogramBucketSize != 0)
            {
                highest = highest + (int) this.HistogramBucketSize - highest % (int) this.HistogramBucketSize;
            }

            var lowerBound = lowest;
            var output = string.Empty;

            while (lowerBound <= highest)
            {
                var upperBound = lowerBound + ((int) this.HistogramBucketSize - 1);

                var count = temperatures.Count(temp => temp >= lowerBound && temp <= upperBound);
                output += $"{lowerBound} - {upperBound}: {count}{Environment.NewLine}";

                lowerBound = upperBound + 1;
            }

            return output;
        }

        private string evaluatePrecipitationRanges(IEnumerable<double?> precipitation)
        {
            var precipitations = precipitation.ToList();
            var lowest = precipitations.Min(precip => precip);
            var highest = precipitations.Max(precip => precip);

            if (lowest % this.PrecipitationBucketSize != 0)
            {
                lowest = lowest - lowest % this.PrecipitationBucketSize;
            }

            if (highest % this.PrecipitationBucketSize != 0)
            {
                highest = highest + this.PrecipitationBucketSize - highest % this.PrecipitationBucketSize;
            }

            var lowerBound = lowest;
            var output = string.Empty;

            while (lowerBound <= highest)
            {
                var upperBound = lowerBound + (this.PrecipitationBucketSize - .01);

                var count = precipitations.Count(precip => precip >= lowerBound && precip <= upperBound);
                output += $"{lowerBound} - {upperBound}: {count}{Environment.NewLine}";

                lowerBound = upperBound + .01;
            }

            return output;
        }

        #endregion
    }
}