using System.Security.Cryptography;

namespace Herond.Common.Utils;

public static class ChecksumHelper
{
    public static string GetChecksumString(string path)
    {
        var bytes = GetSha256ChecksumBytes(path);
        return BitConverter.ToString(bytes).Replace("-", String.Empty);
    }
    
    public static byte[] GetSha256ChecksumBytes(string path)
    {
        using (FileStream stream = File.OpenRead(path))
        {
            var sha = SHA256.Create();
            return sha.ComputeHash(stream);
        }
    }

    public static string GetChecksumBuffered(Stream stream)
    {
        using (var bufferedStream = new BufferedStream(stream, 1024 * 32))
        {
            var sha = SHA256.Create();
            byte[] checksum = sha.ComputeHash(bufferedStream);
            return BitConverter.ToString(checksum).Replace("-", String.Empty);
        }
    }
}