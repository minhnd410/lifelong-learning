using BenchmarkDotNet.Attributes;
using Herond.Benchmarks.Models;

namespace Herond.BenchMarks;

[MemoryDiagnoser(true)]
public class RefBenchmarks
{
    private const int Iterations = 100;
    private FieldItem _data = new();

    [Benchmark]
    public void PassAsRef()
    {
        AcceptPassAsRef(ref _data);
    }

    [Benchmark]
    public void PassAsValue()
    {
        AcceptPassAsValue(_data);
    }

    [Benchmark]
    public void Return()
    {
        _data = AcceptReturn().Result;
    }

    private void AcceptPassAsRef(ref FieldItem items)
    {
        for (int i = 0; i < Iterations; i++)
        {
            items.AddItem(i.ToString(), 0);
        }
    }

    private async Task AcceptPassAsValue(FieldItem items)
    {
        for (int i = 0; i < Iterations; i++)
        {
            items.AddItem(i.ToString(), 0);
        }
    }

    private async Task<FieldItem> AcceptReturn()
    {
        var res = new FieldItem();
        for (int i = 0; i < Iterations; i++)
        {
            res.AddItem(i.ToString(), 0);
        }
        return res;
    }
}