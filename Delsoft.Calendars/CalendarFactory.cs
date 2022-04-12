namespace Delsoft.Calendars;

public class CalendarFactory
{
    public static TCalendar Create<TCalendar> (int? year = null)
        where TCalendar : IBaseCalendar
    {
        var type = typeof(TCalendar);
        if (type.IsInterface)
        {
            type = type.Assembly.GetTypes().Single(t =>
                type.IsAssignableFrom(t) && !t.IsInterface);
        }

        return year == null
            ? (TCalendar) Activator.CreateInstance(type)
            : (TCalendar) Activator.CreateInstance(type, year)!;
    }
}

public class CalendarFactory<TCalendar> : ICalendarFactory<TCalendar>
    where TCalendar : IBaseCalendar
{
    public TCalendar Create(int? year = null) => CalendarFactory.Create<TCalendar>(year);
}