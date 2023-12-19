namespace Herond.Common.Utils;

public static class DoubleUtils
{
    public static double TryParseNullable(object val)
    {
        var input = val.ToString();
        double? parsedValue = !string.IsNullOrWhiteSpace(input) ? double.Parse(input) : null;
        return parsedValue ?? 0;
    }
}