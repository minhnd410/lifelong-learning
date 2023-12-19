using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Herond.Benchmarks.Models;

namespace Herond.BenchMarks;

[MemoryDiagnoser(true)]
public class IfVsSwitch
{
    public IEnumerable<object> ValuesForBenchmark()
    {
        yield return null;
        yield return 10000;
        yield return 10.234;
        yield return DateTime.Now;
        yield return "temp";
        yield return new MetricLogRequest()
        {
            Cadence = "express",
            Channel = "release",
            CountryCode = "other",
            Platform = "macos",
            Version = "2.0.4",

            MetricName = "metricName",
            MetricValue = 0,

            Yos = 2023,
            Woi = 24,
            Yoi = 2023,
        };
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(ValuesForBenchmark))]
    public string? IfElseStatement(object? value)
    {
        if (value is null)
            return "NULL";
        if (value is string or char)
            return $"'{value}'";
        if (value is DateTime time)
            return $"CONVERT(DATETIME, '{time.ToString("yyyy/MM/dd HH:mm:ss")}', 121)";
        if (value.GetType().IsClass)
            return $"'{JsonSerializer.Serialize(value)}'";
        return value.ToString();
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(ValuesForBenchmark))]
    public string? SwitchStatement(object? value)
    {
        switch (value)
        {
            case null:
                return "NULL";
            case string or char:
                return $"'{value}'";
            case DateTime time:
                return $"CONVERT(DATETIME, '{time.ToString("yyyy/MM/dd HH:mm:ss")}', 121)";
            default:
                switch (value.GetType().IsClass)
                {
                    case true:
                        return $"'{JsonSerializer.Serialize(value)}'";
                    default:
                        return value.ToString();
                }
                break;
        }
    }
    
    [Benchmark]
    [ArgumentsSource(nameof(ValuesForBenchmark))]
    public string? SwitchExpression(object? value)
    {
        return value switch
        {
            null => "NULL",
            string or char => $"'{value}'",
            DateTime time => $"CONVERT(DATETIME, '{time.ToString("yyyy/MM/dd HH:mm:ss")}', 121)",
            _ => value.GetType().IsClass switch
            {
                true => $"'{JsonSerializer.Serialize(value)}'",
                _ => value.ToString()
            }
        };
    }
}