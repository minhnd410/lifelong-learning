using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Herond.Common.Authentication;

public class ApiKeyAuthOptions : AuthenticationSchemeOptions
{
    public string ApiKeyValue { get; set; }
    public string ApiKeyName { get; set; }
}

public class ApiKeyAuthHandler : AuthenticationHandler<ApiKeyAuthOptions>
{
    public ApiKeyAuthHandler(
        IOptionsMonitor<ApiKeyAuthOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock)
        : base(options, logger, encoder, clock)
    {
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (Context.Request.Path.Value!.StartsWith("/swagger"))
            return AuthenticateResult.NoResult();
        
        // Retrieve the API key from the query parameters
        var apiKey = Context.Request.Query[Options.ApiKeyName];

        // Validate the API key (you can replace "your_hardcoded_key" with your actual key)
        if (!String.Equals(apiKey, Options.ApiKeyValue, StringComparison.CurrentCultureIgnoreCase))
            return AuthenticateResult.Fail("Invalid API key");

        // Create claims (if needed)
        var claims = new[] { new Claim(ClaimTypes.Name, "ApiKeyUser") };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}