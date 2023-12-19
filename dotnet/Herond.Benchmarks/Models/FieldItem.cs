using Herond.Common.Utils;

namespace Herond.Benchmarks.Models;

public class FieldItem
{
    private int _total;
    private Dictionary<string, int> _keyValuePair = new();
    private Dictionary<string, double> _keyPercentPair = new();
    private readonly Random _random = new ();

    public int Total => _total;
    public Dictionary<string, int> KeyValue => _keyValuePair;
    public Dictionary<string, double> KeyPercent => _keyPercentPair;
    
    public void AddItem(string key, int value)
    {
        if (!_keyValuePair.TryAdd(key, value)) return;
        
        _total += value;
        foreach (var entry in _keyValuePair)
        {
            var percent = (double)entry.Value / _total * 100;
            _keyPercentPair[entry.Key] = percent;
        }
    }

    public Dictionary<string, int> GetAllocates(int number, Dictionary<string, int>? tolerancePercent = null)
    {
        var extantItem = number;
        var extantPercent = 100.0;
        var res = new Dictionary<string, int>();
        foreach (var entry in _keyPercentPair)
        {
            var percentCalc = entry.Value;
            if (tolerancePercent is not null && tolerancePercent.TryGetValue(entry.Key, out var modifyPercent))
                percentCalc += modifyPercent; 
            var itemCalc = (int)(percentCalc * _random.WithTolerance(number, 85, 15) / 100);

            if (extantItem >= 0 
                && extantPercent >= 0 
                && extantItem >= itemCalc 
                && extantPercent >= percentCalc)
            {
                extantItem -= itemCalc;
                extantPercent -= percentCalc;
                res.Add(entry.Key, itemCalc);
            }
            else
            {
                res.Add(entry.Key, extantItem);
                extantPercent = 0;
                extantItem = 0;
            }
        }
        return res;
    }

    public void Clear()
    {
        _total = 0;
        _keyValuePair.Clear();
        _keyPercentPair.Clear();
    }
}