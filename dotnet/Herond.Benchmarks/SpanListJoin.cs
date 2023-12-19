using BenchmarkDotNet.Attributes;

namespace Herond.BenchMarks;

[MemoryDiagnoser(true)]
public class SpanListJoin
{
    private const int Iterations = 100_000;
    private readonly string[] _values =  new string[] { "aa", "bb", "cc" };
    private readonly byte[] _data = new byte[100];
    
    
    [Benchmark]
    public void ListJoin()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var res = ActionListJoin(new Span<byte>(_data));
        }
    }
    
    [Benchmark]
    public void SpanJoin()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var res = ActionSpanJoin(new Span<byte>(_data));
        }
    }
    
    [Benchmark]
    public void ListJoinRef()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var res = ActionListJoinRef(new Span<byte>(_data));
        }
    }
    
    [Benchmark]
    public void SpanJoinRef()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var res = ActionSpanJoinRef(new Span<byte>(_data));
        }
    }
    
    private string ActionListJoin(Span<byte> entities)
    {
        var valuesList = new List<string>();
        for (var i = 0; i < entities.Length; i++)
        {
            valuesList.Add($"({string.Join(", ", _values)})");
        }
        
        return $"{string.Join(", ", valuesList.ToArray())}";
    }
    
    private string ActionSpanJoin(Span<byte> entities)
    {
        var valuesList = new Span<string>(new string[entities.Length]);
        for (var i = 0; i < entities.Length; i++)
        {
            valuesList[i] = $"({string.Join(", ", _values)})";
        }
        
        return $"{string.Join(", ", valuesList.ToArray())}";
    }
    
    private string ActionListJoinRef(in Span<byte> entities)
    {
        var valuesList = new List<string>();
        for (var i = 0; i < entities.Length; i++)
        {
            valuesList.Add($"({string.Join(", ", _values)})");
        }
        
        return $"{string.Join(", ", valuesList.ToArray())}";
    }
    
    private string ActionSpanJoinRef(in Span<byte> entities)
    {
        var valuesList = new Span<string>(new string[entities.Length]);
        for (var i = 0; i < entities.Length; i++)
        {
            
            valuesList[i] = $"({string.Join(", ", _values)})";
        }
        
        return $"{string.Join(", ", valuesList.ToArray())}";
    }
}