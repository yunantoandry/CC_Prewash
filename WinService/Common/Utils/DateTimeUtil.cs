using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static partial class DateTimeExtensions
    {
        public static readonly string IsoFormat = "yyyy-MM-dd";
        public static readonly string IsoFormatWithHoursMinutesAndSeconds = "yyyy-MM-dd HH:mm:ss";

        public static string ToIsoStringWithHoursMinutesAndSeconds(this DateTime dt)
        {
            return dt.ToString(IsoFormatWithHoursMinutesAndSeconds);
        }

        public static string ToIsoString(this DateTime dt)
        {
            return dt.ToString(IsoFormat);
        }

        public static DateTime ToDateTimeFromIsoFormat(this string str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            if (str.Contains(":"))
            {
                return DateTime.ParseExact(str, IsoFormatWithHoursMinutesAndSeconds, CultureInfo.InvariantCulture);
            }
            else
            {
                return DateTime.ParseExact(str, IsoFormat, CultureInfo.InvariantCulture);
            }
        }

        public static DateTime FirstDayOfWeek(this DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }

        public static DateTime LastDayOfWeek(this DateTime dt)
        {
            return dt.FirstDayOfWeek().AddDays(6);
        }

        public static DateTime FirstDayOfMonth(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        public static DateTime FirstDayOfNextMonth(this DateTime dt)
        {
            return dt.FirstDayOfMonth().AddMonths(1);
        }
        public static DateTime DateNowMin_30(this DateTime dt)
        {
            return dt.AddDays(-30);
        }

     
    }
}
