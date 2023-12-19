using BenchmarkDotNet.Attributes;

namespace Herond.BenchMarks;

[MemoryDiagnoser(true)]
public class ToListVsNewList
{
    [Benchmark]
    public List<string> ToList() => Enumerable.Empty<string>().ToList();

    [Benchmark]
    public List<string> NewList() => new List<string>();
}