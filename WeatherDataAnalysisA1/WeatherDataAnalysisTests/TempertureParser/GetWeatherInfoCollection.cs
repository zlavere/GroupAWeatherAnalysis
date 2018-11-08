using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.io;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.TempertureParser
{
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
        public void FromSingleWeatherInfo()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("singleTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 1);
        }
        [TestMethod]
        public void FromManyWeatherInfo()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200" , "12/26/2017,200,-200", "12/27/2017,200,-200" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoContainingDuplicates()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,200,-200", "12/25/2017,200,-200", "12/25/2017,200,-200" };
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyDuplicateTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 3);
        }
        [TestMethod]
        public void FromManyWeatherInfoSingleCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/25/2017,20{corrupt}0,-200", "12/26/2017,200,-200", "12/27/2017,200,-200" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherSingleCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 2);
        }
        [TestMethod]
        public void FromManyWeatherInfoMultiCorrupt()
        {
            var parser = new TemperatureParser();
            var weatherlist = new List<string>() { "12/{corrupt}25/2017,200,-200", "12/26/2017,20{corrupt}0,-200", "12/27/2017,200,-2{corrupt}00" }
                ;
            var weatherInfoCollection = parser.GetWeatherInfoCollection("manyWeatherMultiCorruptionTestList", weatherlist);
            Assert.AreEqual(weatherInfoCollection.Count, 0);
        }

    }
}
