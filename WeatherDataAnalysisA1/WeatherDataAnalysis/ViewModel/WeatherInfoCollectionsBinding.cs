using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    /// Binding for weather info collections
    /// TODO Consider turning this into a mapping of some kind where imported collections have a key/value pair, where key can be something like city and year. 
    /// </summary>
    public class WeatherInfoCollectionsBinding
    {
        /// <summary>
        /// Gets or sets the weather information collections.
        /// </summary>
        /// <value>
        /// The weather information collections.
        /// </value>
        public List<WeatherInfoCollection> WeatherInfoCollections { get; set; }


        public WeatherInfoCollectionsBinding()
        {
            this.WeatherInfoCollections = new List<WeatherInfoCollection>();
        }
        /// <summary>
        /// Adds the specified weather information collection.
        /// </summary>
        /// <param name="weatherInfoCollection">The weather information collection.</param>
        public async void Add(WeatherInfoCollection weatherInfoCollection)
        {
            this.WeatherInfoCollections.Add(weatherInfoCollection);
        }
    }
}
