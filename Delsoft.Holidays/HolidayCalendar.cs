using System.Globalization;
using Delsoft.Holidays.Models;

namespace Delsoft.Holidays;

public abstract class HolidayCalendar
{
    public int Year { get; protected init; }
    
    public static class Names
    {
        public const string Easter = "Easter";
        
        public const string EasterMonday = "Easter Monday";
    }

    public static T Create<T>(int? year = null) 
        where T : HolidayCalendar<T>, new() => HolidayCalendar<T>.Create(year);
}

public abstract class HolidayCalendar<THolidayCalendar> : HolidayCalendar, IHolidayCalendar
    where THolidayCalendar : HolidayCalendar<THolidayCalendar>, new()
{
    public static THolidayCalendar Create(int? year = null) => year == null
        ? HolidayCalendarBuilder.Default
        : HolidayCalendarBuilder.ForYear(year.Value);
    
    protected HolidayCalendar() => Year = DateTime.Today.Year;
    
    private static class HolidayCalendarBuilder
    {
        public static THolidayCalendar Default => new();

        public static THolidayCalendar ForYear(int year) => new() { Year = year };
    }
    
    public IEnumerable<Holiday> Get(params Func<THolidayCalendar, Holiday>[] args) => args.Select(func => func.Invoke((THolidayCalendar)this));
}