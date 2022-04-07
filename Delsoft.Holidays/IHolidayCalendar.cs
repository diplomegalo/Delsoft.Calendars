using Delsoft.Holidays.Models;

namespace Delsoft.Holidays.Calendars;

public interface IHolidayCalendar
{
    int Year { get; }
    string[] GetCultures();
    IEnumerable<Models.Holidays> GetAll();
}