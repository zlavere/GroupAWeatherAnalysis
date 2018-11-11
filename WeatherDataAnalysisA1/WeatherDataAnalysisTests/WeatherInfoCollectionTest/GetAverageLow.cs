using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoCollectionTest
{
    /// <summary>
    /// Tests Cases:
    /// Finding Average on a WeatherInfoCollection with One WeatherInfo
    /// Finding Average on a WeatherInfoCollection with More than One WeatherInfo
    /// Finding Average on a WeatherInfoCollection with many WeatherInfo
    /// Finding Average on a WeatherInfoCollection with many WeatherInfo that returns a decimal answer
    /// Finding Average on an empty WeatherInfoCollection 
    /// </summary>
    [TestClass]
    public class GetAverageLow
    {
        [TestMethod]
        public void TestOneDataPoint()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 50, 40)
            });
            Assert.AreEqual(40, collection.GetAverageLow());
        }

        [TestMethod]
        public void TestZeroDataPoints()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo>());
            Assert.AreEqual(double.MinValue, collection.GetAverageLow());
        }

        [TestMethod]
        public void TestTwoDataPoints()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 0, -10),
                new WeatherInfo(DateTime.Today, 100, 90)
            });
            Assert.AreEqual(40, collection.GetAverageLow());

        }
        [TestMethod]
        public void TestManyDataPoints()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 0, -10),
                new WeatherInfo(DateTime.Today, 100, 90),
                new WeatherInfo(DateTime.Today, 100, 40)
            });
            Assert.AreEqual(40, collection.GetAverageLow());
        }
        [TestMethod]
        public void TestManyDataPointsDecimalAnswer()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 5, 2),
                new WeatherInfo(DateTime.Today, 100, 97),
                new WeatherInfo(DateTime.Today, 100, 43)
            });
            Assert.AreEqual(47.33,collection.GetAverageLow(),.009);
        }
    }
}
