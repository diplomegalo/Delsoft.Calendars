using Delsoft.Calendars.Models;

namespace Delsoft.Calendars.Holidays;

public interface IHolidaysCalendar
{
    int Year { get; }

    string[] GetCultures();

}

public interface IHolidaysCalendar<THolidaysCalendar> : IHolidaysCalendar
    where THolidaysCalendar : IHolidaysCalendar<THolidaysCalendar>
{
    IEnumerable<Holiday> Get(params Func<THolidaysCalendar, Holiday>[] args);
    IEnumerable<Holiday> GetAll();
    IEnumerable<Holiday> Get(params string[] args);
}