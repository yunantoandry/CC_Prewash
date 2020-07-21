using Common.Services.Scheduling.DTO;
using Cronos;
using System;
using System.Linq;

namespace Common.Services.Scheduling
{
    /// <summary>
    /// A static class for determining when a BackgroundProcess should run next
    /// given the UTC date and a cron string.
    /// </summary>
    public static class WhenToRunNextHelper
    {
        public static WhenToRunNextDto TryGetWhenToRunNext(DateTime utcNow, string cronString)
        {
            if (utcNow.Kind != DateTimeKind.Utc)
            {
                return new WhenToRunNextDto
                {
                    ResultType = WhenToRunNextResultType.DateGivenIsNotUtc
                };
            }

            if (string.IsNullOrWhiteSpace(cronString))
            {
                return new WhenToRunNextDto
                {
                    ResultType = WhenToRunNextResultType.CronIsEmpty
                };
            }
            else if (cronString.Trim().Equals("disabled", StringComparison.InvariantCultureIgnoreCase)
                || cronString.Trim().Equals("disable", StringComparison.InvariantCultureIgnoreCase))
            {
                return new WhenToRunNextDto
                {
                    ResultType = WhenToRunNextResultType.ProcessIsDisabled
                };
            }

            var elementsCount = cronString.Split(' ').Count();

            CronExpression cronExpression;

            try
            {
                if (elementsCount == 6)
                {
                    cronExpression = CronExpression.Parse(cronString, CronFormat.IncludeSeconds);
                }
                else
                {
                    cronExpression = CronExpression.Parse(cronString, CronFormat.Standard);
                }
            }
            catch (Exception)
            {
                return new WhenToRunNextDto
                {
                    ResultType = WhenToRunNextResultType.CronIsInvalid
                };
            }

            return new WhenToRunNextDto
            {
                DateTime = cronExpression.GetNextOccurrence(utcNow),
                ResultType = WhenToRunNextResultType.CronIsValid
            };
        }
    }
}
