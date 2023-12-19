using System.Text;
using BenchmarkDotNet.Attributes;
using Herond.Common.Utils;

namespace Herond.BenchMarks.Benchmarks;

[MemoryDiagnoser(true)]
public class ProtobufBenchmark
{
    private const int Iterations = 10_000;
    private const string ReqStr =
        "ChYKCGNocm9taXVtEgoxMTcuMi4wLjI1EhsKDQgFEAYYASIDMDAxMAEQjv0TGgIYCh5_wiESGwoNCAEQBhgBIgMwMDEwARCPtg0aAhgKkUDYbRIbCg0IAxAGGAEiAzAwMTABELmtDRoCGAqyDIgSEhsKDQgHEAYYASIDMDAxMAEQzPwNGgIYCheNfEcSGgoNCAEQCBgBIgMwMDEwBBCPNhoCGAqgxawVEhsKDQgPEAYYASIDMDAxMAEQ-vgBGgIYCiBRpSUSGQoNCAkQBhgBIgMwMDEwARAjGgIYCl_RllQaKAgBCAMIBQgGCAcICAgJCAoIDQgOCA8IEBAEEAgaBgoE9BTmjCABIAQ=";

    private readonly ProtobufNet.FindFullHashesRequest _reqNetObj = 
        ProtoNetHelper.DeserializeFromBase64Url<ProtobufNet.FindFullHashesRequest>(ReqStr);
    private readonly GG.Protobuf.FindFullHashesRequest _reqGgObj = 
        ProtoHelper.DeserializeFromBase64Url<GG.Protobuf.FindFullHashesRequest>(ReqStr);

    [GlobalSetup]
    public void GlobalSetup()
    {
    }
    
    [Benchmark]
    public void ProtobufNet_DeserializeFromBase64Url()
    {
        for (int i = 0; i < Iterations; i++) ProtobufNet_DeserializeFromBase64Url_Func(ReqStr);
    }
    
    [Benchmark]
    public void ProtobufGG_DeserializeFromBase64Url()
    {
        for (int i = 0; i < Iterations; i++) ProtobufGG_DeserializeFromBase64Url_Func(ReqStr);
    }
    
    [Benchmark]
    public void ProtobufNet_Serialize()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var br = ProtobufNet_Serialize_Func(_reqNetObj);
            ProtoNetHelper.Return(br);
        };
    }
    
    [Benchmark]
    public void ProtobufGG_Serialize()
    {
        for (int i = 0; i < Iterations; i++)
        {
            var br = ProtobufGG_Serialize_Func(_reqGgObj);
            ProtoHelper.Return(br);
        };
    }
    
    private ProtobufNet.FindFullHashesRequest ProtobufNet_DeserializeFromBase64Url_Func(string req)
        => ProtoNetHelper.DeserializeFromBase64Url<ProtobufNet.FindFullHashesRequest>(req);
    
    private GG.Protobuf.FindFullHashesRequest ProtobufGG_DeserializeFromBase64Url_Func(string req)
        => ProtoHelper.DeserializeFromBase64Url<GG.Protobuf.FindFullHashesRequest>(req);

    private BufferWriter<byte> ProtobufNet_Serialize_Func(ProtobufNet.FindFullHashesRequest obj)
        => ProtoNetHelper.Serialize(obj);

    private BufferWriter<byte> ProtobufGG_Serialize_Func(GG.Protobuf.FindFullHashesRequest obj)
        => ProtoHelper.Serialize(obj);
}