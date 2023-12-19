using Herond.Common.Constants;
using Herond.Common.Validator;
using Microsoft.AspNetCore.Http;

namespace Herond.Common.Filters.EndpointFilters;

public sealed class ApiKeyFilter : IEndpointFilter
{
    private readonly IApiKeyValidator _apiKeyValidator;

    public ApiKeyFilter(IApiKeyValidator apiKeyValidator)
    {
        _apiKeyValidator = apiKeyValidator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var res = context.HttpContext.Request.Headers
            .TryGetValue(ApiConstant.ApiKeyHeaderName, out var apiKey);

        if (!res || !_apiKeyValidator.IsValid(apiKey!))
            return Results.Unauthorized();
        
        var result = await next(context);
        return result;
    }
}