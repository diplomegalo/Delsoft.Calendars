using System.Runtime.CompilerServices;

namespace Delsoft.Holiday;

public class Calendar
{
    public int Year { get; private set; }
    public int Day { get; }
    public int Month { get; }

    public Calendar()
    {
        Year = DateTime.Now.Year;
        Month = DateTime.Now.Month;
        Day = DateTime.Now.Day;
    }
    
    public Calendar(int year, int month, int day)
    {
        Year = year;
        Month = month;
        Day = day;
    }
    
    public static Calendar Create => new Calendar();
    public IBelgianHoliday BelgianHoliday => Holiday.BelgianHoliday.Create(new Calendar());
    
    public static Calendar ForYear(int year)
    {
        return new Calendar(year, 1, 1);
    }
}