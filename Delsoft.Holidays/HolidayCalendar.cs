using System.Globalization;

namespace Delsoft.Holidays;

public abstract class HolidayCalendar : IHolidayCalendar
{
    public static T Create<T>(int? year = null) where T : HolidayCalendar, new() => year == null
        ? HolidayCalendarBuilder<T>.Default
        : HolidayCalendarBuilder<T>.ForYear(year.Value);

    protected HolidayCalendar()
    {
        Year = DateTime.Today.Year;
        CultureInfo = CultureInfo.CurrentCulture;
    }

    public int Year { get; protected init; }

    public CultureInfo CultureInfo { get; }

    private static class HolidayCalendarBuilder<THolidayCalendar> where THolidayCalendar : HolidayCalendar, new()
    {
        public static THolidayCalendar Default => new();

        public static THolidayCalendar ForYear(int year) => new() { Year = year };
    }
}