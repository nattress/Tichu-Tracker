using System;

namespace ScoreConverter
{
    static class WebkitTimeConverter
    {
        static DateTime s_webkitEpoch = new DateTime(2001, 01, 01, 0, 0, 0, DateTimeKind.Utc);
        static DateTime s_unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        public static DateTime ToDateTime(double webkitDate)
        {
            return s_webkitEpoch.AddSeconds(webkitDate);
        }

        public static double ToUnixTimestamp(double webkitDate)
        {
            return ToDateTime(webkitDate).Subtract(s_unixEpoch).TotalSeconds;
        }
    }
}
