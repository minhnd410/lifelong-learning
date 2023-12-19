namespace Herond.Common.Utils;

public static class RandomExtensions
{
    public static int WithTolerance(this Random rnd, int number, double percentage, double tolerance)
    {
        // 1 or -1
        var rndSide = rnd.Next(0, 101) >= 50 ? -1 : 1;
        // random within tolerance
        int rndTolerance = rnd.Next(0, (int)(tolerance * 1_000_000));

        double adjustment = rndSide * percentage * (rndTolerance / 1_000_000.0) / 100;
        double result = number * (percentage + adjustment) / 100.0;
        return (int)result;
    }
    
    public static T GetRandomKeyBasedOnThreshold<T>(this Random rnd, Dictionary<T, double> thresholdMap) where T : notnull
    {
        var rndSide = rnd.Next(0, 1_000_000_001);
        int cumulativeProbability = 0;

        foreach (var kvp in thresholdMap)
        {
            cumulativeProbability += (int)(kvp.Value * 10_000_000);
            if (rndSide <= cumulativeProbability)
                return kvp.Key;
        }

        return thresholdMap.FirstOrDefault().Key;
    }
}