using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WeatherDataAnalysis.Model.Enums;

namespace WeatherDataAnalysis.ViewModel
{
    /// <summary>
    /// </summary>
    /// <seealso cref="int" />
    public class HistogramSizeComboBoxBindings : IEnumerable<int>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the options of sizes.
        /// </summary>
        public List<int> Sizes { get; }

        /// <summary>
        ///     The most recently selected size.
        /// </summary>
        public static int ActiveSelection { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HistogramSizeComboBoxBindings" /> class.
        /// </summary>
        public HistogramSizeComboBoxBindings()
        {
            this.Sizes = Enum.GetValues(typeof(HistogramBucketSize)).Cast<int>().ToList();
            ActiveSelection = 10;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>) this.Sizes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>) this.Sizes).GetEnumerator();
        }

        #endregion
    }
}