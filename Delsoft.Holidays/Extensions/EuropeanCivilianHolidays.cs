using Delsoft.Holidays.Calendars;

namespace Delsoft.Holidays.Extensions;

public static partial class HolidaysExtension
{
    public static DateTime NewYear(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 1, 1);

    public static DateTime Armistice1918(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 11, 11);

}