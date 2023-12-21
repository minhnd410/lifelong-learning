using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Quartz;

namespace Herond.Common.Quartz;

public abstract class BaseQuartzJob : IJob
{
    private readonly Stopwatch _wStopwatch = new ();
    private readonly ILogger<BaseQuartzJob> _logger;

    protected BaseQuartzJob(ILogger<BaseQuartzJob> logger)
    {
        _logger = logger;
    }

    public ILogger<BaseQuartzJob> Logger => _logger;
    
    public async Task Execute(IJobExecutionContext context)
    {
        // Execute pre-tasks before the main job logic
        await ExecutePreTasks(context);

        try
        {
            // Main job logic implemented by derived classes
            await ExecuteJob(context);
        }
        catch (Exception ex)
        {
            // Handle exceptions if needed
            Console.WriteLine($"Job execution failed: {ex.Message}");
        }
        
        // Execute post-tasks after the main job logic
        await ExecutePostTasks(context);
    }
    
    protected abstract Task ExecuteJob(IJobExecutionContext context);

    private Task ExecutePreTasks(IJobExecutionContext context)
    {
        _wStopwatch.Reset();
        _wStopwatch.Start();
        return Task.CompletedTask;
    }
    
    private Task ExecutePostTasks(IJobExecutionContext context)
    {
        _wStopwatch.Stop();
        _logger.LogInformation("Done {ExecuteJobName} took {S}ms",
            GetType().ToString(),
            _wStopwatch.ElapsedMilliseconds.ToString("#,##0"));
        return Task.CompletedTask;
    }
}