namespace Herond.Common.Utils;

public static class Guard
{
    public static GuardClause<T> ThrowIf<T>(string paramName, T value)
    {
        return new GuardClause<T>(paramName, value);
    }
}

public class GuardClause<T>
{
    private readonly string _paramName;
        private readonly T _value;

    public GuardClause(string paramName, T value)
    {
        _paramName = paramName;
        _value = value;
    }

    public void Null()
    {
        if (typeof(T) == typeof(string) && String.IsNullOrEmpty(_value as string))
        {
            throw new ArgumentNullException(_paramName);
        }
        if (_value == null)
        {
            throw new ArgumentNullException(_paramName);
        }
    }
}