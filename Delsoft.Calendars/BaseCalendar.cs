using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars;

public abstract class BaseCalendar
{
}

public abstract class BaseCalendar<THolidayCalendar> : BaseCalendar, IBaseCalendar<THolidayCalendar>
    where THolidayCalendar : IHolidaysCalendar
{
    protected BaseCalendar() => Holidays = HolidaysCalendar.Factory.Create<THolidayCalendar>();

    protected BaseCalendar(int year) => Holidays = HolidaysCalendar.Factory.Create<THolidayCalendar>(year);

    public THolidayCalendar Holidays { get; }
}