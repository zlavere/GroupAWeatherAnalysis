using System;
using System.Collections.Generic;
using System.Globalization;
using WeatherDataAnalysis.Model;
using WeatherDataAnalysis.ViewModel;

namespace WeatherDataAnalysis.io
{
    /// <summary>
    ///     Parser for CSV set of Temperature Data where format is date, high, low.
    /// </summary>
    public class TemperatureParser
    {
        #region Data members

        private const int DateSegment = 0;
        private const int HighTempSegment = 1;
        private const int LowTempSegment = 2;
        private const int PrecipitationSegment = 3;
        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the error messages.
        /// </summary>
        /// <value>
        ///     The error messages.
        /// </value>
        public ICollection<string> ErrorMessages { get; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TemperatureParser" /> class.
        /// </summary>
        public TemperatureParser()
        {
            this.ErrorMessages = new List<string>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the day temperature list.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="weatherInfoList">The temporary list.</param>
        /// <returns></returns>
        public WeatherInfoCollection GetWeatherInfoCollection(string name, IList<string> weatherInfoList)
        {
            var data = new List<WeatherInfo>();

            foreach (var currentDateData in weatherInfoList)
            {
                var splitLine = currentDateData.Split(',');
                var currentIndex = weatherInfoList.IndexOf(currentDateData);

                if (this.isValidData(splitLine, currentIndex))
                {
                    data.Add(this.parseLine(splitLine));
                }
            }

            var newCollection = new WeatherInfoCollection(name, data);
            ActiveWeatherInfoCollection.Active = newCollection;
            return newCollection;
        }

        private WeatherInfo parseLine(IReadOnlyList<string> line)
        {
            
            var date = DateTime.ParseExact(line[DateSegment], "M/d/yyyy", CultureInfo.InvariantCulture);
            var highTemp = int.Parse(line[HighTempSegment]);
            var lowTemp = int.Parse(line[LowTempSegment]);
            //TODO refactor so there is a single return
            try
            {
                var precipitation = double.Parse(line[PrecipitationSegment]);
                return new WeatherInfo(date, highTemp, lowTemp, precipitation);
            }
            catch (Exception e)
            {
                return new WeatherInfo(date, highTemp, lowTemp);
            }
            
            
        }

        private bool isValidData(IReadOnlyList<string> line, int lineNumber)
        {
            var isValid = false;

            var date = line[DateSegment];
            var highTemp = line[HighTempSegment];
            var lowTemp = line[LowTempSegment];
            if (!this.isValidDate(date))
            {
                var message =
                    $"Error at ln{lineNumber}: {this.getLineString(date, highTemp, lowTemp)}{Environment.NewLine}" +
                    $"{date} is not a valid date. Record Skipped";
                this.ErrorMessages.Add(message);
            }
            else if (!this.isValidTemp(highTemp))
            {
                var message =
                    $"Error at ln{lineNumber}: {this.getLineString(date, highTemp, lowTemp)}{Environment.NewLine}" +
                    $"{highTemp} is not a valid High Temperature. Record Skipped.";
                this.ErrorMessages.Add(message);
            }
            else if (!this.isValidTemp(lowTemp))
            {
                var message =
                    $"Error at ln{lineNumber}: {this.getLineString(date, highTemp, lowTemp)}{Environment.NewLine}" +
                    $"{lowTemp} is not a valid Low Temperature. Record Skipped.";
                this.ErrorMessages.Add(message);
            }
            else 
            {
                //TODO refactor out into helper methods to remove code smell
                try
                {
                    var precipitation = line[PrecipitationSegment];
                    if (!this.isValidPrecipitation(precipitation))
                    {
                        var message =
                            $"Error at ln{lineNumber}: {this.getLineString(date, highTemp, lowTemp, precipitation)}{Environment.NewLine}" +
                            $"{precipitation} is not a valid precipitation. Record Skipped.";
                        this.ErrorMessages.Add(message);
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                catch (Exception e)
                {
                    var message =
                        $"{lineNumber}: {this.getLineString(date, highTemp, lowTemp)}{Environment.NewLine}" +
                        $"Does not contain precipitation records, it will still be imported";
                    this.ErrorMessages.Add(message);
                    isValid = true;
                }
                
                
            }
            
            return isValid;
        }

        private string getLineString(string date, string highTemp, string lowTemp)
        {
            return $"'{date},{highTemp},{lowTemp}'";
        }
        private string getLineString(string date, string highTemp, string lowTemp, string precipitation)
        {
            return $"'{date},{highTemp},{lowTemp},{precipitation}'";
        }
        //TODO Display this
        private bool isValidDate(string date)
        {
            bool isValid;
            try
            {
                var dateTime = DateTime.ParseExact(date, "M/d/yyyy", CultureInfo.InvariantCulture);
                isValid = true;
            }
            catch (Exception)
            {
                isValid = false;
            }

            return isValid;
        }

        //TODO I need to figure out how the TryParse functions worth with keyword out.
        private bool isValidTemp(string temp)
        {
            var isValid = false;

            try
            {
                var i = int.Parse(temp);
                isValid = true;
            }
            catch (Exception)
            {
                //ignored
            }

            return isValid;
        }
        private bool isValidPrecipitation(string precipitation)
        {
            var isValid = false;

            try
            {
                var i = double.Parse(precipitation);
                isValid = true;
            }
            catch (Exception)
            {
                //ignored
            }

            return isValid;
        }
        #endregion
    }
}