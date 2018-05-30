using System;

namespace DotNetPOC.Utils
{
    public static class TimeConverter
    {
        private static int DAY_HOURS = 24;
        private static TimeZoneInfo timezone = null; 
        /// <summary>
        /// Converts days in hours.
        /// </summary>
        /// <returns> Quantity of hours according to specified quantity of days </returns>
        public static int ConvertDaysInHours(int days){
            return days * DAY_HOURS;
        }

        private static TimeZoneInfo GetCustomTimezone()
        {
            if (timezone == null)
            {
                string displayName = "(GMT-03:00) Brazil Time";
                string standardName = "Brazil Time";
                TimeSpan offset = new TimeSpan(-3, 00, 00);
                timezone = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName);
            }
            return timezone;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTicks)
        {
            DateTime date = new DateTime(0); // the lowest date possible.

            return date.AddMilliseconds(unixTicks);            
        }

        public static long DateTimeToUnixTime(DateTime date)
        {
            DateTime timestamp = new DateTime(0); // the lowest timestamp possible.
            
            return (long)(date - timestamp).TotalMilliseconds;
        }
    }
}