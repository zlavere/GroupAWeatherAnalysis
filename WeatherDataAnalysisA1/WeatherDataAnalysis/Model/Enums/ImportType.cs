namespace WeatherDataAnalysis.Model.Enums
{
    /// <summary>
    /// Enum for ImportTypes
    /// </summary>
    public enum ImportType
    {
        /// <summary>
        /// Indicates that the import should utilize a merging process.
        /// </summary>
        Merge,
        /// <summary>
        /// Indicates that the import should utilize an overwrite process.
        /// </summary>
        Overwrite
    }
}