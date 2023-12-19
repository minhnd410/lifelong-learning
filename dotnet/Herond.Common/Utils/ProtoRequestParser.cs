using System.Reflection;
using Google.Protobuf;
using Herond.Common.Utils;
using Microsoft.AspNetCore.Http;

namespace Herond.Common.Utils;

public class ProtoRequestParser<T> where T : IMessage<T>, new()
{
    public T? Value { get; set; }
    
    public static ValueTask<ProtoRequestParser<T>> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        var req = context.Request.Query["$req"];
        var res = new ProtoRequestParser<T>();
        
        if (String.IsNullOrEmpty(req))
            return ValueTask.FromResult(res);

        res.Value = ProtoHelper.DeserializeFromBase64Url<T>(req!);
        return ValueTask.FromResult(res);
    }
}