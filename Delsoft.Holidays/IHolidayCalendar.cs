using System.Globalization;

namespace Delsoft.Holidays;

public interface IHolidayCalendar
{
    int Year { get; }
    CultureInfo CultureInfo { get; }
}