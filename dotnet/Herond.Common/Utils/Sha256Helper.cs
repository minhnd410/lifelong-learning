using System.Security.Cryptography;
using System.Text;

namespace Herond.Common.Utils;

public static class Sha256Helper
{
    public static byte[] CalcSha256(string data)
    {
        using var sha = SHA256.Create();
        return sha.ComputeHash(Encoding.ASCII.GetBytes(data));
    }
}