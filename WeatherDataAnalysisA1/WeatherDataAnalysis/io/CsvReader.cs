﻿using System;
using System.Collections.Generic;
using Windows.Storage;
using System.Threading.Tasks;

namespace WeatherDataAnalysis.io
{
    /// <summary>
    /// Reads CSV file lines
    /// </summary>
    public class CsvReader
    {
        public async Task<IList<string>> GetFileLines(IStorageFile file)
        {
            var fileLines = await FileIO.ReadLinesAsync(file);
            return fileLines;
        }
    }
}