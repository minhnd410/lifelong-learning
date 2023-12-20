namespace Herond.Common.Utils;

public static class HttpClientExtensions
{
    public static async Task DownloadFile(this HttpClient client, string uri, string filePath)
    {
        await using var stream = await client.GetStreamAsync(uri);
        await using var fileStream = new FileStream(filePath, FileMode.Create);
        await stream.CopyToAsync(fileStream);
    }
}