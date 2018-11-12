using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Microsoft.Graphics.Canvas.Svg;
using WeatherDataAnalysis.IO;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.Controller
{
    class ExportController
    {
        private const int CSV = 0;
        private const int XML = 1;
        private const int Cancel = 2;
        /// <summary>
        /// Saves the weather info
        /// </summary>
        /// <returns></returns>
        public async Task ExportActiveCollection()
        {

            var dialog = new MessageDialog("Please select an export format.") {Title = "Export Format"};
            dialog.Commands.Add(new UICommand {Label = "CSV", Id = CSV });
            dialog.Commands.Add(new UICommand {Label = "XML", Id = XML});
            dialog.Commands.Add(new UICommand {Label = "Cancel", Id = Cancel });
            var res = await dialog.ShowAsync();

            if ((int) res.Id == CSV)
            {
                this.saveDataAsCSV();
            } else if ((int)res.Id == XML)

            {
                this.saveDataAsXML();
            }
        }


        private async void saveDataAsCSV()
        {
            var directoryPicker = new FolderPicker();
            directoryPicker.FileTypeFilter.Add(".csv");
            directoryPicker.FileTypeFilter.Add(".txt");
            directoryPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            var directoryResult = await directoryPicker.PickSingleFolderAsync();

            if (directoryResult != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", directoryResult);
                var output = new WriteWeatherDataToCsv();
                output.WriteActiveDataToCsv(directoryResult);
            }
        }
        private async void saveDataAsXML()
        {
            var directoryPicker = new FolderPicker();
            directoryPicker.FileTypeFilter.Add(".xml");
            directoryPicker.SuggestedStartLocation = PickerLocationId.ComputerFolder;

            var directoryResult = await directoryPicker.PickSingleFolderAsync();

            if (directoryResult != null)
            {
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", directoryResult);
                
                XMLSerializer.WriteWeatherCollection(directoryResult);
            }
        }
    }
}
