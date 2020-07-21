namespace Common.Services.Scheduling.DTO
{
    public enum WhenToRunNextResultType
    {
        CronIsEmpty,
        CronIsInvalid,
        ProcessIsDisabled,
        CronIsValid,
        DateGivenIsNotUtc
    }
}
