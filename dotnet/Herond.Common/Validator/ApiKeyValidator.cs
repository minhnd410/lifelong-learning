namespace Herond.Common.Validator;

public interface IApiKeyValidator
{
    bool IsValid(string apiKey);
}

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly string _apiKey;

    public ApiKeyValidator(string apiKey)
    {
        _apiKey = apiKey;
    }

    public bool IsValid(string apiKey)
    {
        // Implement logic for validating the API key.
        return apiKey == _apiKey;
    }
}