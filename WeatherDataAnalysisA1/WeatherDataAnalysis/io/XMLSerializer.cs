using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.IO
{
   public static class XMLWriter
    {


        public static void WriteWeatherCollection(WeatherInfoCollection collection, string storagePath)
        {

            XmlSerializer writer = new XmlSerializer(typeof(WeatherInfoCollection));
            try
            {
              //  using (XMLWriter)
               
              //  writer.Serialize();
            }
            catch (Exception e)
            {
                
                
            }
        }
    }
}
