using Delsoft.Calendars.Models;

namespace Delsoft.Calendars.Holidays;

public interface IHolidaysCalendar
{
    int Year { get; }
    string[] GetCultures();
    IEnumerable<Holiday> GetAll();
}