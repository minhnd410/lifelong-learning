using Google.Protobuf;
using Herond.Common.Constants;
using Microsoft.AspNetCore.Http;

namespace Herond.Common.Utils;

public static class HttpContextExtensions
{
    public static void SetProperty(this HttpContext context, string key, object value)
    {
        context.Items[key] = value;
    }

    public static T? GetProperty<T>(this HttpContext context, string key)
    {
        if (context.Items.TryGetValue(key, out var outVal))
        {
            return (T)outVal!;
        }

        return default;
    }

    public static async Task ResponseProtobuf(this HttpContext context, IBufferMessage obj)
    {
        var bufferWriter = ProtoHelper.Serialize(obj);
            
        context.Response.StatusCode = 200;
        context.Response.Headers.ContentType = ApiConstant.ContentType.Protobuf;
        context.Response.ContentLength = bufferWriter.WrittenCount;
        await context.Response.Body.WriteAsync(bufferWriter.Buffer, 0, bufferWriter.WrittenCount);
        ProtoHelper.Return(bufferWriter);
    }

    public static async Task ResponseBadRequest(this HttpContext context, string message)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(message);
    }
}