using System;
using System.Collections.Generic;
using System.Linq;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.Model.Enums;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.Format
{
    public class WeatherHistogramGenerator
    {
        public HistogramBucketSize BucketSize { get; set; }
        

        public WeatherHistogramGenerator()
        {
            this.BucketSize = HistogramBucketSize.Ten;
        }

        public string CreateHistogram(IEnumerable<WeatherInfo> collection)
        {
            var weatherInfos = collection.ToList();
            var highTemps = weatherInfos.Select(temp => temp.HighTemp);
            var lowTemps = weatherInfos.Select(temp => temp.LowTemp);
            this.BucketSize = (HistogramBucketSize)ComboBoxBindings.ActiveSelection;
            var output = $"High Temperature Histogram {Environment.NewLine}" +
                         $"{this.evaluateRanges(highTemps)} {Environment.NewLine}" +
                         $"Low Temperature Histogram {Environment.NewLine}" +
                         $"{this.evaluateRanges(lowTemps)}";
            return output;
        }

        private string evaluateRanges(IEnumerable<int> temps)
        {
            var temperatures = temps.ToList();
            var lowest = temperatures.Min(temp => temp);
            var highest = temperatures.Max(temp => temp);

            if (lowest % (int) this.BucketSize != 0)
            {
                lowest = lowest - lowest % (int) this.BucketSize;
            }

            if (highest % (int) this.BucketSize != 0)
            {
                highest = highest + (int) this.BucketSize - highest % (int) this.BucketSize;
            }

            var lowerBound = lowest;
            var output = string.Empty;

            while (lowerBound <= highest)
            {
                var upperBound = lowerBound + ((int) this.BucketSize - 1);

                var count = temperatures.Count(temp => temp >= lowerBound && temp <= upperBound);
                output += $"{lowerBound}-{upperBound}: {count}{Environment.NewLine}";

                lowerBound = upperBound + 1;
            }

            return output;
        }
        
    }
}
