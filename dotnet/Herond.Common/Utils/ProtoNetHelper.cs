using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Herond.Common.Utils;

public static class ProtoNetHelper
{
    private static readonly BufferWriterPool<byte> Pool = new();

    public static BufferWriter<byte> Serialize<T>(T obj)
    {
        var br = Pool.Rent();
        ProtoBuf.Serializer.Serialize(br, obj);
        return br;
    }

    public static T DeserializeFromBase64Url<T>(string str)
    {
        using var stream = new MemoryStream(Base64UrlEncoder.DecodeBytes(str));
        return ProtoBuf.Serializer.Deserialize<T>(stream);
    }

    public static T Deserialize<T>(HttpResponseMessage msg)
    {
        using var task = msg.Content.ReadAsByteArrayAsync();
        return ProtoBuf.Serializer.Deserialize<T>(new ReadOnlySpan<byte>(Base64UrlEncoderBytes.DecodeBytes(task.Result)));
    }
    
    public static void Return(BufferWriter<byte> writer)
    {
        Pool.Return(writer);
    }
}