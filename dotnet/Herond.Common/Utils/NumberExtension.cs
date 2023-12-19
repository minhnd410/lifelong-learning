using System.Globalization;

namespace Herond.Common.Utils;

public static class NumberExtension
{
    public static (int WholePart, int Fractional) GetParts(this double d)
    {
        var wholePart = (int)Math.Truncate(d);

        var str = d.ToString("0.000000000", CultureInfo.InvariantCulture);
        var fractional = int.Parse(str.Substring(str.IndexOf('.') + 1));
        
        return (wholePart, fractional);
    }
}