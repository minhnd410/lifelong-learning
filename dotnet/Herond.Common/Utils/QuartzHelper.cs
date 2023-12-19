using Quartz;

namespace Herond.Common.Utils;

public static class QuartzHelper
{
    public static async Task<(int? WholePart, int? Fractional)> GetTotalSecondsNextFireTime(
        ISchedulerFactory schedulerFactory, JobKey jobKey)
    {
        var scheduler = await schedulerFactory.GetScheduler();
        var triggers = await scheduler.GetTriggersOfJob(jobKey);
        var nextFireTimeUtc = triggers.FirstOrDefault()?.GetNextFireTimeUtc();
        if (nextFireTimeUtc is not null)
        {
            return nextFireTimeUtc.Value.DateTime
                .AddMinutes(7)
                .Subtract(DateTime.UtcNow)
                .TotalSeconds
                .GetParts();
        }

        return default;
    }
}