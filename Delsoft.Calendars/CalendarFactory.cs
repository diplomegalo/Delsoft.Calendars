namespace Delsoft.Calendars;

public class CalendarFactory
{
    public static TCalendar Create<TCalendar>(int? year = null)
        where TCalendar : IBaseCalendar
    {
        var type = typeof(TCalendar).IsInterface
            ? typeof(TCalendar).Assembly.GetTypes().Single(t => typeof(TCalendar).IsAssignableFrom(t) && !t.IsInterface)
            : typeof(TCalendar);

        return (TCalendar)Activator.CreateInstance(type, year)!;
    }
}

public class CalendarFactory<TCalendar> : ICalendarFactory<TCalendar>
    where TCalendar : IBaseCalendar
{
    public TCalendar Create(int? year = null) => CalendarFactory.Create<TCalendar>(year);
}