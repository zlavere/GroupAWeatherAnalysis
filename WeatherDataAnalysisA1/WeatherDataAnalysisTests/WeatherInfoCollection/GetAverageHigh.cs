﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoCollection
{
    /// <summary>
    /// Tests Cases:
    /// Finding Average on a WeatherInfoCollection with One WeatherInfo
    /// Finding Average on a WeatherInfoCollection with More than One WeatherInfo
    /// Finding Average on an empty WeatherInfoCollection 
    /// </summary>
    [TestClass]
    public class GetAverageHigh
    {
        [TestMethod]
        public void TestOneDataPoint()
        {
            var collection = new WeatherDataAnalysis.Model.WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 50, 40)
            });
            Assert.AreEqual(50.0, collection.GetAverageHigh());
        }

        [TestMethod]
        public void TestZeroDataPoints()
        {
            var collection = new WeatherDataAnalysis.Model.WeatherInfoCollection("Test1", new List<WeatherInfo>());
            Assert.AreEqual(int.MaxValue, collection.GetAverageHigh());
        }

        [TestMethod]
        public void TestTwoDataPoints()
        {
            var collection = new WeatherDataAnalysis.Model.WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Today.AddDays(-3), 0, -10),
                new WeatherInfo(DateTime.Today, 100, 90)
            });
            Assert.AreEqual(50, collection.GetAverageHigh());
        }

        
    }
}