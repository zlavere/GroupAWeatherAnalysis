using System;
using System.Globalization;

namespace WeatherDataAnalysis.Extension
{
    public static class DateExtensions
    {
        #region Methods

        public static string OrdinalDateString(this DateTime date)
        {
            return getDateString(date);
        }

        private static string getDateString(DateTime date)
        {
            var month = DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
            var ordinalDay = getOrdinal(date.Day);
            return $"{month} {ordinalDay}, {date.Year}";
        }

        private static string getOrdinal(int day)
        {
            string ordinalDay;
            if (day == 11 || day == 12 || day == 13)
            {
                ordinalDay = day + "th";
            }
            else
            {
                switch (day % 10)
                {
                    case 1:
                        ordinalDay = day + "st";
                        break;
                    case 2:
                        ordinalDay = day + "nd";
                        break;
                    case 3:
                        ordinalDay = day + "rd";
                        break;
                    default:
                        ordinalDay = day + "th";
                        break;
                }
            }

            return ordinalDay;
        }

        #endregion
    }
}