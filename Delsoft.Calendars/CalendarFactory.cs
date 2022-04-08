namespace Delsoft.Calendars;

public static class CalendarFactory
{
    public static TCalendar Create<TCalendar> (int? year = null)
        where TCalendar : BaseCalendar, new()
    {
        return year == null
            ? new TCalendar()
            : (TCalendar) Activator.CreateInstance(typeof(TCalendar), year)!;
    }
}