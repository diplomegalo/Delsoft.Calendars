using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars;

public interface IBaseCalendar
{

}

public interface IBaseCalendar<THolidayCalendar> : IBaseCalendar
    where THolidayCalendar : IHolidaysCalendar
{
    public THolidayCalendar Holidays { get; }
}