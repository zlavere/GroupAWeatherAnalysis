using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoCollectionTest
{
    /// <summary>
    /// Test Cases
    /// Find highest low temperture day(s) in a month in a empty WeatherInfoCollection
    /// Find highest low temperture day(s) in a month in a WeatherInfoCollection with a single day in the month.
    /// Find highest low temperture day(s) in a month in a WeatherInfoCollection with two duplicate days in the month.
    /// Find highest low temperture day(s) in a month in a WeatherInfoCollection with two days in the month with boundry temperture.
    /// Find highest low temperture day(s) in a month in a WeatherInfoCollection with three days in the month with a temperture boundry sequence where the first is the highest.
    /// Find highest low temperture day(s) in a month in a WeatherInfoCollection with three days in the month with a temperture boundry sequence where the second is the highest.
    /// Find highest low temperture day(s) in a month in a WeatherInfoCollection with three days in the month with a temperture boundry sequence where the last is the highest.
    /// Find highest low temperture day(s) in a month in a WeatherInfoCollection with three days in the month with a temperture boundry and multiple results
    /// </summary>
    [TestClass]
    public class FindHighestLowTemps
    {

        [TestMethod]
        public void TestNoDaysInCollection()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo>
            {
            });
            Assert.ThrowsException<InvalidOperationException>(() => collection.GetLowestInMonth(1));
        }

        [TestMethod]
        public void TestOneDaysInMonth()
        {
            var testWeatherInfo = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testWeatherInfo
            });
            var result = collection.FindHighestLowTemps();
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testWeatherInfo
            });

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestTwoDaysInMonthLowBoundry()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);
            var testinfo2 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S
            });
            var result = collection.FindHighestLowTemps();

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestTwoDaysInMonthEquals()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var result = collection.FindHighestLowTemps();

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInMonthTempertureSequenceFirstIsHighest()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);
            var testinfo2 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10,  0);
            var testinfo3 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -1);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2,
                testinfo3
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S
            });
            var result = collection.FindHighestLowTemps();

            Assert.IsTrue(expected.SequenceEqual(result));
        }
        [TestMethod]
        public void TestManyDaysInMonthTempertureSequenceSecondIsHighest()
        {
            var testinfo1 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -1);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);
            var testinfo3 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1,
                testinfo2S,
                testinfo3
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo2S
            });
            var result = collection.FindHighestLowTemps();

            Assert.IsTrue(expected.SequenceEqual(result));
        }
        [TestMethod]
        public void TestManyDaysInMonthTempertureSequenceLastIsHighest()
        {
            var testinfo1 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -1);
            var testinfo2 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -0);
            var testinfo3S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1,
                testinfo2,
                testinfo3S
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo3S
            });
            var result = collection.FindHighestLowTemps();

            Assert.IsTrue(expected.SequenceEqual(result));
        }
        [TestMethod]
        public void TestManyDaysInMonthDuplicate()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);
            var testinfo3 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S,
                testinfo3
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var result = collection.FindHighestLowTemps();

            Assert.IsTrue(expected.SequenceEqual(result));
        }

     
    }
}
