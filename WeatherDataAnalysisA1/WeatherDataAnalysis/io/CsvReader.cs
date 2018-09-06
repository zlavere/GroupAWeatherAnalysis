using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using WeatherDataAnalysis.Format;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;
using System.Threading.Tasks;

namespace WeatherDataAnalysis.io
{
    class CsvReader
    {
        public async Task<IList<string>> GetFileLines(IStorageFile file)
        {
            var fileLines = await FileIO.ReadLinesAsync(file);
            return fileLines;
        }
    }
}
    
