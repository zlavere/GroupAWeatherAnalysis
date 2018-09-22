using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    /// Binding for weather info collections
    /// TODO Consider turning this into a data map of some kind where imported collections have a key/value pair, where key can be something like city and year. 
    /// </summary>
    public class WeatherInfoCollectionsBinding:ICollection<WeatherInfoCollection>
    {
        /// <summary>
        /// Gets or sets the weather information collections.
        /// </summary>
        /// <value>
        /// The weather information collections.
        /// </value>
        public List<WeatherInfoCollection> WeatherInfoCollections { get; set; }
        
        /// <summary>
        /// Gets or sets the current.
        /// </summary>
        /// <value>
        /// The current.
        /// </value>
        public WeatherInfoCollection Active { get; set; }
        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count => ((ICollection<WeatherInfoCollection>)this.WeatherInfoCollections).Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly => ((ICollection<WeatherInfoCollection>)this.WeatherInfoCollections).IsReadOnly;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherInfoCollectionsBinding"/> class.
        /// </summary>
        public WeatherInfoCollectionsBinding()
        {
            this.WeatherInfoCollections = new List<WeatherInfoCollection>();
        }

        public async Task<WeatherInfoCollection> CreateNewFromFile(StorageFile file)
        {
            var csvFileReader = new CsvReader();
            var temperatureParser = new TemperatureParser();
            var fileLines = await csvFileReader.GetFileLines(file);
            var newWeatherInfoCollection = temperatureParser.GetWeatherInfoCollection(fileLines);
            this.Add(newWeatherInfoCollection);
            return newWeatherInfoCollection;
        }
        /// <summary>
        /// Adds the specified weather information collection.
        /// </summary>
        /// <param name="weatherInfoCollection">The weather information collection.</param>
        public void Add(WeatherInfoCollection weatherInfoCollection)
        {
            this.WeatherInfoCollections.Add(weatherInfoCollection);
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            ((ICollection<WeatherInfoCollection>)this.WeatherInfoCollections).Clear();
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains(WeatherInfoCollection item)
        {
            return ((ICollection<WeatherInfoCollection>)this.WeatherInfoCollections).Contains(item);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(WeatherInfoCollection[] array, int arrayIndex)
        {
            ((ICollection<WeatherInfoCollection>)this.WeatherInfoCollections).CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        /// true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false. This method also returns false if item is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        public bool Remove(WeatherInfoCollection item)
        {
            return ((ICollection<WeatherInfoCollection>)this.WeatherInfoCollections).Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<WeatherInfoCollection> GetEnumerator()
        {
            return ((ICollection<WeatherInfoCollection>)this.WeatherInfoCollections).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<WeatherInfoCollection>)WeatherInfoCollections).GetEnumerator();
        }
    }
}
