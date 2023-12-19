using Google.Protobuf;
using Microsoft.IdentityModel.Tokens;

namespace Herond.Common.Utils;

public static class ProtoHelper
{
    private static readonly BufferWriterPool<byte> Pool = new();
    
    private static class Parser<T>
        where T : IMessage<T>, new()
    {
        public static MessageParser<T> Instance { get; } = new MessageParser<T>(() => new T());
    }
    
    public static BufferWriter<byte> Serialize(IBufferMessage obj)
    {
        var br = Pool.Rent();
        obj.WriteTo(br);
        return br;
    }

    public static T DeserializeFromBase64Url<T>(string str) where T : IMessage<T>, new()
        => Parser<T>.Instance.ParseFrom(Base64UrlEncoder.DecodeBytes(str));
    
    public static T Deserialize<T>(Stream stream) where T : IMessage<T>, new()
       => Parser<T>.Instance.ParseFrom(stream);
    
    public static T Deserialize<T>(byte[] bytes) where T : IMessage<T>, new()
        => Parser<T>.Instance.ParseFrom(bytes);
    
    public static T Deserialize<T>(HttpResponseMessage msg) where T : IMessage<T>, new()
    {
        using var task = msg.Content.ReadAsByteArrayAsync();
        return Parser<T>.Instance.ParseFrom(Base64UrlEncoderBytes.DecodeBytes(task.Result));
    }
    
    public static void Return(BufferWriter<byte> writer)
    {
        Pool.Return(writer);
    }
}