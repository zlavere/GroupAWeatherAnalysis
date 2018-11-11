namespace WeatherDataAnalysis.Model.Enums
{
    /// <summary>
    ///     Enum for the various bucket sizes that histogram can be.
    /// </summary>
    public enum HistogramBucketSize
    {
        /// <summary>
        ///     5 degrees per bucket.
        /// </summary>
        Five = 5,

        /// <summary>
        ///     10 degrees per bucket
        /// </summary>
        Ten = 10,

        /// <summary>
        ///     20 degrees per bucket
        /// </summary>
        Twenty = 20
    }
}