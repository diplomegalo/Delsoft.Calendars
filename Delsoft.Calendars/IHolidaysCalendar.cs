using Delsoft.Calendars.Models;

namespace Delsoft.Calendars;

public interface IHolidaysCalendar
{
    int Year { get; }
    string[] GetCultures();
    IEnumerable<Holiday> GetAll();
}