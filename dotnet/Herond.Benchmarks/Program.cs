using BenchmarkDotNet.Running;
using Herond.BenchMarks.Benchmarks;

namespace Herond.BenchMarks;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<ProtobufBenchmark>();
    }
}