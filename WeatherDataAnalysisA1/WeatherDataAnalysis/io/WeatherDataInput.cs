using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherDataAnalysis.io
{
    /// <summary>
    /// 
    /// </summary>
    public class WeatherDataInput
    {
        private readonly StreamReader inputStream;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherDataInput"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public WeatherDataInput(string filePath)
        {
            this.inputStream = new StreamReader(filePath);   
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<string> Data
        {
            get
            {
                var data = new List<string>();

                while (!this.inputStream.EndOfStream)
                {
                    var value = this.inputStream.ReadLine();
                    data.Add(value);
                }

                return data;
            }
        }
    }
}
