## ApiKeyValidator

```csharp
services.AddSingleton<IApiKeyValidator>(_ => new ApiKeyValidator(_apiKey));

var apiV1 = app.MapGet( "/some-endpoint" )
    .AddEndpointFilter<ApiKeyFilter>();
```