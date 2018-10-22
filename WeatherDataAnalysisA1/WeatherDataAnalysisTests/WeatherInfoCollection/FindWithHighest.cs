using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoCollection
{
    /// <summary>
    /// Test Cases
    /// Find Highest from one WeatherInfo in collection
    /// Find Highest from more than one WeatherInfo in collection
    /// Find Highest in collection of 0 WeatherInfo
    /// </summary>
    [TestClass]
    public class FindWithHighest
    {
        [TestMethod]
        public void FromOneWeatherInfo()
        {
            var collection = new WeatherDataAnalysis.Model.WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 50, 40)
            });
            Assert.AreEqual(50, collection.FindWithHighest().First().HighTemp);
        }

        [TestMethod]
        public void FromTwoWeatherInfo()
        {
            var collection = new WeatherDataAnalysis.Model.WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 0, -10),
                new WeatherInfo(DateTime.Today, 100, 90)
            });
            Assert.AreEqual(100, collection.FindWithHighest().First().HighTemp);
        }

        [TestMethod]
        public void FromZeroWeatherInfo()
        {
            var collection = new WeatherDataAnalysis.Model.WeatherInfoCollection("Test1", new List<WeatherInfo>());

            Assert.ThrowsException<InvalidOperationException>(() => collection.FindWithHighest());

        }
        

    }
}
