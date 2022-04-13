using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars;

public abstract class BaseCalendar
{
    public int Year { get; }

    public abstract string[] GetCultures();

    protected BaseCalendar(int? year = null) => Year = year ?? DateTime.Today.Year;
}

public abstract class BaseCalendar<THolidayCalendar> : BaseCalendar, IBaseCalendar<THolidayCalendar>
    where THolidayCalendar : IHolidaysCalendar
{
    protected BaseCalendar(int? year = null)
        :base(year) => Holidays = HolidaysCalendar.Factory.Create<THolidayCalendar>(this);

    public THolidayCalendar Holidays { get; }
}