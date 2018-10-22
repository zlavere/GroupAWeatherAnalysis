using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.IO
{
    public class OutputWeatherDataCsv
    {
          private StorageFolder directory { get; set; }

        public async void WriteActiveDataToCsv(StorageFolder directory)
        {
            this.directory = directory;
            var file = await this.directory.CreateFileAsync($"{ActiveWeatherInfoCollection.Active.Name}.csv",
                CreationCollisionOption.GenerateUniqueName);
            await FileIO.WriteLinesAsync(file, this.getSeperatedWeatherInfo());
        }

        private IEnumerable<string> getSeperatedWeatherInfo()
        {
            var commaSeparatedData = new List<string>();
            foreach (var current in ActiveWeatherInfoCollection.Active)
            {
                commaSeparatedData.Add(
                    $"{current.Date.Month}/{current.Date.Day}/{current.Date.Year},{current.HighTemp},{current.LowTemp}");
            }

            return commaSeparatedData;
        }
        
    }
}
