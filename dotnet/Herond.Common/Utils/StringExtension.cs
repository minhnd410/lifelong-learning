using System.Text;

namespace Herond.Common.Utils;

public static class StringExtension
{
    public static string EncodeBase64(this string value)
    {
        var valueBytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(valueBytes);
    }

    public static string DecodeBase64(this string value)
    {
        var valueBytes = System.Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(valueBytes);
    }
    
    public static bool IsHexadecimalEncoded(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        foreach (char c in input)
        {
            if (!IsHexadecimalChar(c))
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsHexadecimalChar(char c)
    {
        return (c >= '0' && c <= '9') ||
               (c >= 'a' && c <= 'f') ||
               (c >= 'A' && c <= 'F');
    }
}