using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoCollectionTest
{
    /// <summary>
    /// Test Cases
    /// Find highest temperture day(s) in a month in a empty WeatherInfoCollection
    /// Find highest temperture day(s) in a empty month in a WeatherInfoCollection
    /// Find highest temperture day(s) in a month in a WeatherInfoCollection with a single day in the month.
    /// Find highest temperture day(s) in a month in a WeatherInfoCollection with two duplicate days in the month.
    /// Find highest temperture day(s) in a month in a WeatherInfoCollection with two days in the month with boundry temperture.
    /// Find highest temperture day(s) in a month in a WeatherInfoCollection with three days in the month with a temperture boundry sequence.
    /// Find highest temperture day(s) in a month in a WeatherInfoCollection with a day on the border of the next month
    /// Find highest temperture day(s) in a month in a WeatherInfoCollection with a day on the border of the previous month
    /// </summary>
    [TestClass]
    public class GetHighestInMonth
    {
        [TestMethod]
        public void TestNoDaysInCollection()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
            });
            Assert.ThrowsException<InvalidOperationException>(() => collection.GetHighestInMonth(1));
        }

        [TestMethod]
        public void TestNoDaysInMonth()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Parse("2/2/2007"), 0, -10)
            });
            Assert.ThrowsException<InvalidOperationException>(() => collection.GetHighestInMonth(1));
        }

        [TestMethod]
        public void TestOneDaysInMonth()
        {
            var testWeatherInfo = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testWeatherInfo
            });
            var result = collection.GetHighestInMonth(1);
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testWeatherInfo
            });

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestTwoDaysInMonthLowBoundry()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var testinfo2 = new WeatherInfo(DateTime.Parse("1/2/2007"), -1, -10);
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S
            });
            var result = collection.GetHighestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestTwoDaysInMonthEquals()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var result = collection.GetHighestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInMonthTempertureSequence()
        {
            var testinfo1 = new WeatherInfo(DateTime.Parse("1/2/2007"), -1, -10);
            var testinfo2 = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var testinfo3S = new WeatherInfo(DateTime.Parse("1/2/2007"), 1, -10);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1,
                testinfo2,
                testinfo3S
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo3S
            });
            var result = collection.GetHighestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInMonthDuplicate()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var testinfo3 = new WeatherInfo(DateTime.Parse("1/2/2007"), -1, -10);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S,
                testinfo3
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var result = collection.GetHighestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInOutsidemonthAheadInTime() { 
        var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
        var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
        var testinfo3 = new WeatherInfo(DateTime.Parse("2/1/2007"), 0, -10);

        var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
            testinfo1S,
            testinfo2S,
            testinfo3
        });
        var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
            testinfo1S,
            testinfo2S
        });
        var result = collection.GetHighestInMonth(1);

        Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInOutsidemonthBehindInTime()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 0, -10);
            var testinfo3 = new WeatherInfo(DateTime.Parse("2/1/2007"), 0, -10);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S,
                testinfo3
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var result = collection.GetHighestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}