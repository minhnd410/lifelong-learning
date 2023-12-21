using BenchmarkDotNet.Running;

namespace Herond.BenchMarks;

public class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<ProtobufBenchmark>();
        BenchmarkRunner.Run<StringFormatVsInterpolation>();
        BenchmarkRunner.Run<IfVsSwitch>();
        BenchmarkRunner.Run<ToListVsNewList>();
        BenchmarkRunner.Run<ListVsArray>();
        BenchmarkRunner.Run<SpanBenchmarks>();
        BenchmarkRunner.Run<SpanListJoin>();
        BenchmarkRunner.Run<RefBenchmarks>();
    }
}