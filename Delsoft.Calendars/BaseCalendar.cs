using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars;

public abstract class BaseCalendar
{
}

public abstract class BaseCalendar<THolidayCalendar> : BaseCalendar
    where THolidayCalendar : HolidaysCalendar<THolidayCalendar>, new()
{
    protected BaseCalendar() => Holidays = HolidaysCalendar.Create<THolidayCalendar>();

    protected BaseCalendar(int year) => Holidays = HolidaysCalendar.Create<THolidayCalendar>(year);

    public THolidayCalendar Holidays { get; }
}