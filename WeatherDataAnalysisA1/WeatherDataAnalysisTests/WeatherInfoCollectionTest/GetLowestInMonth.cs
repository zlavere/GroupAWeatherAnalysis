using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherDataAnalysis.Model;

namespace WeatherDataAnalysisTests.WeatherInfoCollectionTest
{
    /// <summary>
    /// Test Cases
    /// Find lowest temperture day(s) in a month in a empty WeatherInfoCollection
    /// Find lowest temperture day(s) in a empty month in a WeatherInfoCollection
    /// Find lowest temperture day(s) in a month in a WeatherInfoCollection with a single day in the month.
    /// Find lowest temperture day(s) in a month in a WeatherInfoCollection with two duplicate days in the month.
    /// Find lowest temperture day(s) in a month in a WeatherInfoCollection with two days in the month with boundry temperture.
    /// Find lowest temperture day(s) in a month in a WeatherInfoCollection with three days in the month with a temperture boundry sequence.
    /// Find lowest temperture day(s) in a month in a WeatherInfoCollection with a day on the border of the next month
    /// Find lowest temperture day(s) in a month in a WeatherInfoCollection with a day on the border of the previous month
    /// </summary>
    [TestClass]
    public class GetLowestInMonth
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
        public void TestNoDaysInMonth()
        {
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                new WeatherInfo(DateTime.Parse("2/2/2007"), 10, 0)
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
            var result = collection.GetLowestInMonth(1);
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testWeatherInfo
            });

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestTwoDaysInMonthHighBoundry()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var testinfo2 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);
            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S
            });
            var result = collection.GetLowestInMonth(1);

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
            var result = collection.GetLowestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInMonthTempertureSequence()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -1);
            var testinfo2 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -0);
            var testinfo3 = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 1);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2,
                testinfo3
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S
            });
            var result = collection.GetLowestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInMonthDuplicate()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -1);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, -1);
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
            var result = collection.GetLowestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInOutsidemonthAheadInTime()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var testinfo3 = new WeatherInfo(DateTime.Parse("2/1/2007"), 10, 0);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
            testinfo1S,
            testinfo2S,
            testinfo3
        });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
            testinfo1S,
            testinfo2S
        });
            var result = collection.GetLowestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }

        [TestMethod]
        public void TestManyDaysInOutsidemonthBehindInTime()
        {
            var testinfo1S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var testinfo2S = new WeatherInfo(DateTime.Parse("1/2/2007"), 10, 0);
            var testinfo3 = new WeatherInfo(DateTime.Parse("2/1/2007"), 10, 0);

            var collection = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S,
                testinfo3
            });
            var expected = new WeatherInfoCollection("Test1", new List<WeatherInfo> {
                testinfo1S,
                testinfo2S
            });
            var result = collection.GetLowestInMonth(1);

            Assert.IsTrue(expected.SequenceEqual(result));
        }
    }
}
