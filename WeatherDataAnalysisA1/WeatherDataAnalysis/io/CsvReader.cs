using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;

namespace WeatherDataAnalysis.io
{
    /// <summary>
    ///     Reads CSV file lines
    /// </summary>
    public class CsvReader
    {
        #region Methods

        /// <summary>
        /// Gets the file lines.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns></returns>
        public async Task<IList<string>> GetFileLines(IStorageFile file)
        {
            var fileLines = await FileIO.ReadLinesAsync(file);
            return fileLines;
        }

        #endregion
    }
}