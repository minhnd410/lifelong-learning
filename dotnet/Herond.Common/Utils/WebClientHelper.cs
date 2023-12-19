using System.Net;

namespace Herond.Common.Utils;

public static class WebClientHelper
{
    public static void DownloadFile(string url, string filePath)
    {
        using var client = new WebClient();
        client.DownloadFile(url, filePath);
    }
}