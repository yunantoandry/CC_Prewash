using System;

namespace Common.Services.System.Dto
{
    /// <summary>
    /// Represents a string like "10:00".
    /// </summary>
    public class HourAndMinuteDto
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public HourAndMinuteDto(string hourAndMinuteString)
        {
            if (hourAndMinuteString == null) throw new ArgumentNullException(nameof(hourAndMinuteString));
            if (string.IsNullOrWhiteSpace(hourAndMinuteString)) throw new ArgumentException($"The parameter {nameof(hourAndMinuteString)} cannot be whitespace.");

            try
            {
                var splitHourAndMinuteString = hourAndMinuteString.Split(':');

                Hour = int.Parse(splitHourAndMinuteString[0]);
                Minute = int.Parse(splitHourAndMinuteString[1]);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occured when trying to parse '{hourAndMinuteString}' as hours and minutes.", ex);
            }

            // Validate the hour and minute.

            if (Hour < 0 || Hour > 24)
            {
                throw new InvalidOperationException($"The string '{hourAndMinuteString}' produced an hour of '{Hour}' which is not between 0 and 24.");
            }

            if (Minute < 0 || Minute > 60)
            {
                throw new InvalidOperationException($"The string '{hourAndMinuteString}' produced an hour of '{Hour}' which is not between 0 and 60.");
            }

            if (Hour >= 24 && Minute >= 00)
            {
                throw new InvalidOperationException($"The string '{hourAndMinuteString}' are not valid hours and minutes.");
            }
        }

        public HourAndMinuteDto(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return $"{Hour.ToString().PadLeft(2, '0')}:{Minute.ToString().PadLeft(2, '0')}";
        }
    }

    public static class DateTimeHourAndMinuteExtensions
    {
        public static bool Matches(this DateTime dateTime, HourAndMinuteDto hourAndMinuteDto)
        {
            if (hourAndMinuteDto == null) throw new ArgumentNullException(nameof(hourAndMinuteDto));

            return dateTime.Hour == hourAndMinuteDto.Hour && dateTime.Minute == hourAndMinuteDto.Minute;
        }
    }
}
