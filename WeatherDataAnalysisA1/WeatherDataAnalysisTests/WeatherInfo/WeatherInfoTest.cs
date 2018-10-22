using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoTest
{
    /// <summary>
    /// Test Cases
    /// Tests Valid input parameters
    /// Exception when the high is less than the low
    /// Successful creation when the date is today
    /// Successful creation when high equals low
    /// Exception when the Date is greater than today  
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
        public void TestWhenHighLessThanLow()
        {
            Assert.ThrowsException<ArgumentException>(() => new WeatherInfo(DateTime.Now.AddDays(-1), 0, 100));
        }

        [TestMethod]
        public void TestSuccessWhenDateIsToday()
        {
            var test = new WeatherInfo(DateTime.Today, 100, 0);
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
    }
}
