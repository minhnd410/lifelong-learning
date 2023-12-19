using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Herond.BenchMarks;

[MemoryDiagnoser(true)]
public class StringFormatVsInterpolation
{
    private DateTime _time = new DateTime();
    
    [Benchmark]
    public string Format() => String.Format($"CONVERT(DATETIME, '{0}', 121)", _time.ToString("yyyy/MM/dd HH:mm:ss"));

    [Benchmark]
    public string Interpolate() => $"CONVERT(DATETIME, '{_time:yyyy/MM/dd HH:mm:ss}', 121)";
    
    [Benchmark]
    public string InterpolateExplicit() => $"CONVERT(DATETIME, '{_time.ToString("yyyy/MM/dd HH:mm:ss")}', 121)";
}