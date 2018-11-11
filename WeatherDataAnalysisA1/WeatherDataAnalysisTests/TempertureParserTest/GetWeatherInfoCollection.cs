using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.TempertureParserTest
{
    /// <summary>
    /// Test Cases
    /// Successful getting a empty WeatherInfoCollection from an empty list of strings.
    /// Successful getting a WeatherInfoCollection from a list with a single string not containing precipitation
    /// Successful getting a empty WeatherInfoCollection from a list with a single string not containing precipitation with a corrupt date.
    /// Successful getting a empty WeatherInfoCollection from a list with a single string not containing precipitation with a corrupt high temp.
    /// Successful getting a empty WeatherInfoCollection from a list with a single string not containing precipitation with a corrupt low temp.
    /// Successful getting a WeatherInfoCollection from a list with a single string containing precipitation
    /// Successful getting a empty WeatherInfoCollection from a list with a single string containing precipitation with a corrupt date.
    /// Successful getting a empty WeatherInfoCollection from a list with a single string containing precipitation with a corrupt high temp.
    /// Successful getting a empty WeatherInfoCollection from a list with a single string containing precipitation with a corrupt low temp.
    /// Successful getting a empty WeatherInfoCollection from a list with a single string containing precipitation with a corrupt precipitation.
    /// Successful getting a WeatherInfoCollection from a list of strings not containing precipitation.
    /// Successful getting a WeatherInfoCollection from a list of strings containing a singe entry with precipitation first.
    /// Successful getting a WeatherInfoCollection from a list of strings containing a singe entry with precipitation second.
    /// Successful getting a WeatherInfoCollection from a list of strings containing a singe entry with precipitation last.
    /// Successful getting a WeatherInfoCollection from a list of strings not containing precipitation that has duplication.
    /// Successful getting a WeatherInfoCollection from a list of strings containing precipitation that has duplication.
    /// Successful getting a WeatherInfoCollection from a mixed list of string containing some precipitation that has duplication.
    /// Successful getting a WeatherInfoCollection from a list of strings not containing precipitation with a single string containing corruption;
    /// Successful getting a WeatherInfoCollection from a list of strings not containing precipitation with a muliple strings containing corruption;
    /// Successful getting a WeatherInfoCollection from a mixed list of string containing some precipitation with a single string containing corruption;
    /// Successful getting a WeatherInfoCollection from a mixed list of string containing some precipitation with a muliple strings containing corruption;
    /// Successful getting a WeatherInfoCollection from a list of strings containing precipitation with a single string containing corruption;
    /// Successful getting a WeatherInfoCollection from a list of strings containing precipitation with a muliple strings containing corruption;
    /// </summary>
    [TestClass]
    public class GetWeatherInfoCollection
    {
        [TestMethod]
        public void FromEmptyWeatherInfo()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>();
            var weatherInfoCollection = parser.GetWeatherInfoCollection("emptyTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count , 0);
        }
        [TestMethod]
        public void FromSingleWeatherInfoNoPrecipitation()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 1);
        }
        
        [TestMethod]
        public void FromSingleWeatherInfoNoPrecipitationCorruptDate()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/2{corrupt}5/2017,200,-200" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromSingleWeatherInfoNoPrecipitationCorruptHighTemp()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,20{corrupt}0,-200" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromSingleWeatherInfoNoPrecipitationCorruptLowTemp()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-2{corrupt}00" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromSingleWeatherInfoWithPrecipitation()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200,1.1" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 1);
        }
        [TestMethod]
        public void FromSingleWeatherInfoWithPrecipitationCorruptDate()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/2{corrupt}5/2017,200,-200,1.1" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromSingleWeatherInfoWithPrecipitationCorruptHighTemp()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,20{corrupt}0,-200,1.1" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromSingleWeatherInfoWithPrecipitationCorruptLowTemp()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-2{corrupt}00,1.1" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromSingleWeatherInfoWithPrecipitationCorruptPrecipitation()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200,1.{corrupt}1" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromManyWeatherInfoNoPrecipitation()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200" , "12/26/2017,200,-200", "12/27/2017,200,-200" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoAllPrecipitation()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200,1.1", "12/26/2017,200,-200,1.1", "12/27/2017,200,-200,1.1" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoSinglePrecipitationFirst()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200,1.1", "12/26/2017,200,-200", "12/27/2017,200,-200" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoSinglePrecipitationSecond()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200", "12/26/2017,200,-200,1.1", "12/27/2017,200,-200" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoSinglePrecipitationLast()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200", "12/26/2017,200,-200", "12/27/2017,200,-200,1.1" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoNoPrecipitationContainingDuplicates()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200", "12/25/2017,200,-200", "12/25/2017,200,-200" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyDuplicateTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoWithPrecipitationContainingDuplicates()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200,1.1", "12/25/2017,200,-200,1.1", "12/25/2017,200,-200,1.1" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyDuplicateTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoMixedPrecipitationContainingDuplicates()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200", "12/25/2017,200,-200", "12/25/2017,200,-200,1.1" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyDuplicateTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoWithoutPrecipitationSingleCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,20{corrupt}0,-200", "12/26/2017,200,-200", "12/27/2017,200,-200" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherSingleCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 2);
        }
        [TestMethod]
        public void FromManyWeatherInfoWithoutPrecipitationMultiCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/{corrupt}25/2017,200,-200", "12/26/2017,20{corrupt}0,-200", "12/27/2017,200,-2{corrupt}00" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherMultiCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromManyWeatherInfoMixedPrecipitationSingleCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200", "12/26/2017,20{corrupt}0,-200", "12/27/2017,200,-200", "12/27/2017,200,-200,1.1" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherMultiCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoMixedPrecipitationMultiCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/{corrupt}25/2017,200,-200", "12/26/2017,20{corrupt}0,-200", "12/27/2017,200,-2{corrupt}00", "12/27/2017,200,-200,1.{corrupt}1" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherMultiCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
        [TestMethod]
        public void FromManyWeatherInfoWithPrecipitationSingleCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,20{corrupt}0,-200,1.1", "12/26/2017,200,-200,1.1", "12/27/2017,200,-200,1.1" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherSingleCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 2);
        }
        [TestMethod]
        public void FromManyWeatherInfoWithPrecipitationMultiCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/{corrupt}25/2017,200,-200,1.1", "12/26/2017,20{corrupt}0,-200,1.1", "12/27/2017,200,-2{corrupt}00,1.1" , "12/27/2017,200,-200,1.{corrupt}1" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherMultiCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }
    
    }
}
