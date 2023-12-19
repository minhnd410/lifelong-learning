using System.Globalization;

namespace Herond.Common.Utils;

public static class DatetimeExtensions
{
    public static int GetWeekOfYear(this DateTime dateTime)
    {
        CultureInfo culture = CultureInfo.CurrentCulture;
        CalendarWeekRule weekRule = culture.DateTimeFormat.CalendarWeekRule;
        DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;

        return culture.Calendar.GetWeekOfYear(dateTime, weekRule, firstDayOfWeek);
    }

    public static int GetDayOfYear(this DateTime dateTime)
    {
        CultureInfo culture = CultureInfo.CurrentCulture;
        return culture.Calendar.GetDayOfYear(dateTime);
    }
}