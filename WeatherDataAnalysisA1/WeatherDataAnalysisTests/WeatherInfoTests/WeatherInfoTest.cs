using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoTests
{
    /// <summary>
    /// Test Cases
    /// Tests Valid input parameters
    /// Exception when the high is less than the low
    /// Exception when the precipitation is less than 0
    /// Successful creation when the date is today with no precipitation
    /// Successful creation when the date is today with precipitation
    /// Successful creation when high equals low
    /// Exception when the Date is greater than today
    /// Successful creation the Date is yesterday 
    /// </summary>
    [TestClass]
    public class WeatherInfoTest
    {
        [TestMethod]
        public void TestSuccessfulCreation()
        {
            var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0);
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestWhenHighTempLessThanLowTemp()
        {
            Assert.ThrowsException<ArgumentException>(() => new WeatherInfo(DateTime.Now.AddDays(-1), 0, 100));
        }
        [TestMethod]
        public void TestWhenPrecipitationLessThanZero()
        {
            Assert.ThrowsException<ArgumentException>(() => new WeatherInfo(DateTime.Now.AddDays(-1), 0, 100,-1));
        }
        [TestMethod]
        public void TestSuccessWhenDateIsTodayWithoutPrecipitation()
        {
            var test = new WeatherInfo(DateTime.Today, 100, 0);
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void TestSuccessWhenDateIsTodayWithPrecipitation()
        {
            var test = new WeatherInfo(DateTime.Today, 100, 0,.01);
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void TestSuccessWhenHighEqualsLow()
        {
            var test = new WeatherInfo(DateTime.Today, 100, 100);
            Assert.IsNotNull(test);
        }


        [TestMethod]
        public void TestWhenDateIsTomorrow()
        {
            Assert.ThrowsException<ArgumentException>(() => new WeatherInfo(DateTime.Now.AddDays(1), 100, 0));
        }
        [TestMethod]
        public void TestWhenDateIsYesterday()
        {
           var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0);
            Assert.IsNotNull(test);
        }
    }
}
