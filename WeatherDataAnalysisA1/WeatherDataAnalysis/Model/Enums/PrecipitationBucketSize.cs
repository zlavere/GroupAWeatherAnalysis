using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAnalysis.Model.Enums
{
    public struct PrecipitationBucketSize
    {
        /// <summary>
        ///     Quarter inch of precitipation per bucket.
        /// </summary>
        public static double TenthInch = .1;

        /// <summary>
        ///     Half inch of precitipation per bucket.
        /// </summary>
        public static double QuarterInch = .25;

        /// <summary>
        ///     Inch of precitipation per bucket.
        /// </summary>
        public static double HalfInch = .5;
    }
}
