using System.Runtime.CompilerServices;

namespace Delsoft.Calendars;

public class Calendar
{
    public int Year { get; }
    public int Day { get; }
    public int Month { get; }

    private Calendar() : this(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
    {
    }

    private Calendar(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public static Calendar Now => new Calendar();

    public static Calendar ForYear(int year) => new Calendar(year, 1, 1);
}