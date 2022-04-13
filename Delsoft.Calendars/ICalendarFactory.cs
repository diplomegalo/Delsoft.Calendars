namespace Delsoft.Calendars;

public interface ICalendarFactory<TCalendar>
    where TCalendar : IBaseCalendar
{
    TCalendar Create(int? year = null);
}