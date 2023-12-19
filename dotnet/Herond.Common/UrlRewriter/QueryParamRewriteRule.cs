using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;

namespace Herond.Common.UrlRewriter;

public sealed class QueryParamRewriteRule : IRule
{
    private Regex InitialMatch { get; }

    private string Replacement { get; }

    private bool SkipRemainingRules { get; }

    public QueryParamRewriteRule([StringSyntax("Regex")] string regex, string replacement, bool skipRemainingRules)
    {
        InitialMatch = new Regex(regex, RegexOptions.Compiled | RegexOptions.CultureInvariant);
        Replacement = replacement;
        SkipRemainingRules = skipRemainingRules;
    }

    public void ApplyRule(RewriteContext context)
    {
        var fullPath = context.HttpContext.Request.Path + context.HttpContext.Request.QueryString;
        var match = fullPath != string.Empty ? InitialMatch.Match(fullPath.Substring(1)) : InitialMatch.Match(fullPath);
        if (!match.Success)
            return;

        var str = match.Result(this.Replacement);
        var request = context.HttpContext.Request;
        if (SkipRemainingRules)
            context.Result = RuleResult.SkipRemainingRules;

        request.Path = str[0] != '/' ? PathString.FromUriComponent("/" + str) : PathString.FromUriComponent(str);
        request.Query = context.HttpContext.Request.Query;
        request.QueryString = context.HttpContext.Request.QueryString;
    }
}