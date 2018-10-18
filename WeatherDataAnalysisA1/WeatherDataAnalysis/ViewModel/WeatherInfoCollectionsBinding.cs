using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    ///     Binding for weather info collections
    ///     can be something like city and year.
    /// </summary>
    public class WeatherInfoCollectionsBinding : IDictionary<string, WeatherInfoCollection>,
        ICollection<WeatherInfoCollection>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the weather information collections.
        /// </summary>
        /// <value>
        ///     The weather information collections.
        /// </value>
        private IDictionary<string, WeatherInfoCollection> WeatherInfoCollections { get; }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"></see> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        /// </summary>
        public ICollection<string> Keys => this.WeatherInfoCollections.Keys;

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"></see> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        /// </summary>
        public ICollection<WeatherInfoCollection> Values => this.WeatherInfoCollections.Values;

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count => this.WeatherInfoCollections.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly => this.WeatherInfoCollections.IsReadOnly;

        /// <summary>
        /// Gets or sets the <see cref="WeatherInfoCollection"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="WeatherInfoCollection"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public WeatherInfoCollection this[string key]
        {
            get => this.WeatherInfoCollections[key];
            set => this.WeatherInfoCollections[key] = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherInfoCollectionsBinding" /> class.
        /// </summary>
        public WeatherInfoCollectionsBinding()
        {
            this.WeatherInfoCollections = new Dictionary<string, WeatherInfoCollection>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        public void Add(WeatherInfoCollection item)
        {
            this.Values.Add(item);
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains(WeatherInfoCollection item)
        {
            return this.Values.Contains(item);
        }

        /// <summary>
        ///     Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an
        ///     <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements
        ///     copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see>
        ///     must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(WeatherInfoCollection[] array, int arrayIndex)
        {
            this.Values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>;
        ///     otherwise, false. This method also returns false if item is not found in the original
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        public bool Remove(WeatherInfoCollection item)
        {
            return this.Values.Remove(item);
        }

        IEnumerator<WeatherInfoCollection> IEnumerable<WeatherInfoCollection>.GetEnumerator()
        {
            return this.Values.GetEnumerator();
        }

        /// <summary>
        ///     Adds an element with the provided key and value to the
        ///     <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        /// </summary>
        /// <param name="key">The object to use as the key of the element to add.</param>
        /// <param name="value">The object to use as the value of the element to add.</param>
        public void Add(string key, WeatherInfoCollection value)
        {
            this.WeatherInfoCollections.Add(value.Name, value);
            ActiveWeatherInfoCollection.Active = value;
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.IDictionary`2"></see> contains an element with the
        ///     specified key.
        /// </summary>
        /// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.</param>
        /// <returns>
        ///     true if the <see cref="T:System.Collections.Generic.IDictionary`2"></see> contains an element with the key;
        ///     otherwise, false.
        /// </returns>
        public bool ContainsKey(string key)
        {
            return this.WeatherInfoCollections.ContainsKey(key);
        }

        /// <summary>
        ///     Removes the element with the specified key from the <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        /// </summary>
        /// <param name="key">The key of the element to remove.</param>
        /// <returns>
        ///     true if the element is successfully removed; otherwise, false.  This method also returns false if key was not found
        ///     in the original <see cref="T:System.Collections.Generic.IDictionary`2"></see>.
        /// </returns>
        public bool Remove(string key)
        {
            return this.WeatherInfoCollections.Remove(key);
        }

        /// <summary>
        ///     Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value">
        ///     When this method returns, the value associated with the specified key, if the key is found;
        ///     otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        ///     true if the object that implements <see cref="T:System.Collections.Generic.IDictionary`2"></see> contains an
        ///     element with the specified key; otherwise, false.
        /// </returns>
        public bool TryGetValue(string key, out WeatherInfoCollection value)
        {
            return this.WeatherInfoCollections.TryGetValue(key, out value);
        }

        /// <summary>
        ///     Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        public void Add(KeyValuePair<string, WeatherInfoCollection> item)
        {
            this.WeatherInfoCollections.Add(item);
        }

        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            this.WeatherInfoCollections.Clear();
        }

        /// <summary>
        ///     Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> contains a specific value.
        /// </summary>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if item is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        public bool Contains(KeyValuePair<string, WeatherInfoCollection> item)
        {
            return this.WeatherInfoCollections.Contains(item);
        }

        /// <summary>
        ///     Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an
        ///     <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements
        ///     copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see>
        ///     must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(KeyValuePair<string, WeatherInfoCollection>[] array, int arrayIndex)
        {
            this.WeatherInfoCollections.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if item was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>;
        ///     otherwise, false. This method also returns false if item is not found in the original
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        public bool Remove(KeyValuePair<string, WeatherInfoCollection> item)
        {
            return this.WeatherInfoCollections.Remove(item);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<KeyValuePair<string, WeatherInfoCollection>> GetEnumerator()
        {
            return this.WeatherInfoCollections.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.WeatherInfoCollections.GetEnumerator();
        }


        #endregion
    }
}