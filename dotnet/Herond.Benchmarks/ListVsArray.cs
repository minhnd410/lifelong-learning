using BenchmarkDotNet.Attributes;

namespace Herond.BenchMarks;

[MemoryDiagnoser(true)]
public class ListVsArray
{
    [Benchmark]
    public List<int> MemList()
    {
        var res = new List<int>();
        for (var i = 0; i < 9; i++)
            res.Add(i);
        return res;
    }

    [Benchmark]
    public Array MemArray()
    {
        var res = new int[9];
        for (var i = 0; i < 9; i++)
            res[i] = i;
        return res;
    }
}