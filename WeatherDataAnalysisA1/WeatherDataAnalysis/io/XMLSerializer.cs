using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.IO
{
    /// <summary>
    ///     This class contains tools for the serialization, and deserialization of XML files related to weather
    /// </summary>
    public static class XmlSerializer
    {
        #region Methods

        /// <summary>
        ///     Writes a weather collection to the file specified in an XML format
        /// </summary>
        /// <param name="collection">The weather collection to be written as XML</param>
        /// <param name="file">The file to write the weather collection to</param>
        public static async void WriteWeatherCollection(WeatherInfoCollection collection, StorageFile file)
        {
            try
            {
                var outStream = await file.OpenStreamForWriteAsync();
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(WeatherInfoCollection));
                using (outStream)
                {
                    serializer.Serialize(outStream, collection);
                }
            }
            catch (Exception)
            {
                //TODO Error Handling
            }
        }

        /// <summary>
        ///     Reads a weather collection to the file specified in an XML format
        /// </summary>
        /// <param name="file">The file to read a weather collection from</param>
        /// <returns>A weather collection created from the file specified</returns>
        public static async Task<WeatherInfoCollection> ReadWeatherCollection(StorageFile file)
        {
            try
            {
                var inStream = await file.OpenStreamForReadAsync();
                var deserializer = new System.Xml.Serialization.XmlSerializer(typeof(WeatherInfoCollection));
                return (WeatherInfoCollection) deserializer.Deserialize(inStream);
            }
            catch (Exception e)
            {
                //TODO error handling
            }

            //TODO fix method so that there is only a single return statement
            return null;
        }

        #endregion
    }
}