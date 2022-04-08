using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars;

public abstract class BaseCalendar
{
    public static TCalendar Create<TCalendar> (int? year = null)
        where TCalendar : BaseCalendar, new()
    {
        return year == null
            ? new TCalendar()
            : (TCalendar) Activator.CreateInstance(typeof(TCalendar), year)!;
    }
}

public abstract class BaseCalendar<THolidayCalendar> : BaseCalendar
    where THolidayCalendar : HolidaysCalendar<THolidayCalendar>, new()
{
    protected BaseCalendar() => Holidays = HolidaysCalendar.Create<THolidayCalendar>();

    protected BaseCalendar(int year) => Holidays = HolidaysCalendar.Create<THolidayCalendar>(year);

    public THolidayCalendar Holidays { get; }
}