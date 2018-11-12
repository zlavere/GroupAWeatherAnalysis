namespace WeatherDataAnalysis.Model.Enums
{
    public struct PrecipitationBucketSize
    {
        /// <summary>
        ///     Quarter inch of precipitation per bucket.
        /// </summary>
        public static double TenthInch = .1;

        /// <summary>
        ///     Half inch of precipitation per bucket.
        /// </summary>
        public static double QuarterInch = .25;

        /// <summary>
        ///     Inch of precipitation per bucket.
        /// </summary>
        public static double HalfInch = .5;
    }
}