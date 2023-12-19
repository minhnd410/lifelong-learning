using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace Herond.BenchMarks;

[MemoryDiagnoser(true)]
public class Collection
{
    [Benchmark]
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