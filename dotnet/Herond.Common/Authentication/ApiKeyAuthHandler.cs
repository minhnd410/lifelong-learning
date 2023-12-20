using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Herond.Common.Authentication;

public class ApiKeyAuthOptions : AuthenticationSchemeOptions
{
    public string ApiKeyValue { get; set; } = null!;
    public string ApiKeyName { get; set; } = null!;
}

public class ApiKeyAuthHandler : AuthenticationHandler<ApiKeyAuthOptions>
{
    public ApiKeyAuthHandler(
        IOptionsMonitor<ApiKeyAuthOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder)
        : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (Context.Request.Path.Value!.StartsWith("/swagger"))
            return Task.FromResult(AuthenticateResult.NoResult());
        
        // Retrieve the API key from the query parameters
        var apiKey = Context.Request.Query[Options.ApiKeyName];

        // Validate the API key (you can replace "your_hardcoded_key" with your actual key)
        if (!String.Equals(apiKey, Options.ApiKeyValue, StringComparison.CurrentCultureIgnoreCase))
            return Task.FromResult(AuthenticateResult.Fail("Invalid API key"));

        // Create claims (if needed)
        var claims = new[] { new Claim(ClaimTypes.Name, "ApiKeyUser") };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}