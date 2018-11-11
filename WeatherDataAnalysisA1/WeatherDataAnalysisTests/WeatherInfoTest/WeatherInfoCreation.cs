using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoTest
{

    /// <summary>
    /// Test Cases
    /// Tests Valid input parameters
    /// Successful creation when the date is today with no precipitation
    /// Successful creation when the date is today with precipitation
    /// Successful assignment of the date when WeatherInfo is created.
    /// Successful assignment of the high temp when WeatherInfo is created.
    /// Successful assignment of the low temp when WeatherInfo is created.
    /// Successful assignment of the precipitation when WeatherInfo is created.
    /// Successful creation when high equals low
    /// Successful creation the Date is yesterday 
    /// Exception when the Date is greater than today
    /// Exception when the high is less than the low
    /// Exception when the precipitation is less than 0
    /// </summary>
    [TestClass]
    public class WeatherInfoCreation
    {
        [TestMethod]
        public void TestSuccessfulCreation()
        {
            var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0);
            Assert.IsNotNull(test);
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
            var test = new WeatherInfo(DateTime.Today, 100, 0, .01);
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void TestSuccessfulCreationDateAssignment()
        {
            var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0);
            Assert.IsTrue(test.Date.Date == DateTime.Now.AddDays(-1).Date);
        }
        [TestMethod]
        public void TestSuccessfulCreationHighTempAssignment()
        {
            var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0);
            Assert.IsTrue(test.HighTemp == 100);
        }
        [TestMethod]
        public void TestSuccessfulCreationLowTempAssignment()
        {
            var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0);
            Assert.IsTrue(test.LowTemp == 0);
        }
        [TestMethod]
        public void TestSuccessfulCreationPrecipitationAssignment()
        {
            var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0, 1.1);
            Assert.AreEqual((double)test.Precipitation, 1.1, .009);
        }
        [TestMethod]
        public void TestSuccessWhenHighEqualsLow()
        {
            var test = new WeatherInfo(DateTime.Today, 100, 100);
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestWhenDateIsYesterday()
        {
            var test = new WeatherInfo(DateTime.Now.AddDays(-1), 100, 0);
            Assert.IsNotNull(test);
        }
        [TestMethod]
        public void TestWhenDateIsTomorrow()
        {
            Assert.ThrowsException<ArgumentException>(() => new WeatherInfo(DateTime.Now.AddDays(1), 100, 0));
        }
        [TestMethod]
        public void TestWhenHighTempLessThanLowTemp()
        {
            Assert.ThrowsException<ArgumentException>(() => new WeatherInfo(DateTime.Now.AddDays(-1), 0, 100));
        }
        [TestMethod]
        public void TestWhenPrecipitationLessThanZero()
        {
            Assert.ThrowsException<ArgumentException>(() => new WeatherInfo(DateTime.Now.AddDays(-1), 0, 100, -1));
        }
    }
}
