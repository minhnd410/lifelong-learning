using Herond.Common.Constants;
using Microsoft.AspNetCore.Http;

namespace Herond.Common.Filters.EndpointFilters;

public enum ContentType {
    Protobuf
}

public enum ContentTypeSearchPlace {
    QueryParam
}

public class ContentTypeFilter : IEndpointFilter
{
    private readonly ContentType _contentType;
    private readonly ContentTypeSearchPlace _contentTypeSearchPlace;
    private readonly string _searchKey;
    
    public ContentTypeFilter(ContentType contentType, ContentTypeSearchPlace contentTypeSearchPlace, string? searchKey)
    {
        _contentType = contentType;
        _contentTypeSearchPlace = contentTypeSearchPlace;
        _searchKey = searchKey ?? "Content-Type";
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        if (_contentType == ContentType.Protobuf)
        {
            if (_contentTypeSearchPlace == ContentTypeSearchPlace.QueryParam)
            {
                if (context.HttpContext.Request.Query[_searchKey]
                    != ApiConstant.ContentType.Protobuf)
                    return Results.Problem(title: "Unsupported Content Type", statusCode: 415);
            }
        }
        
        return await next(context);
    }
}