using Delsoft.Holidays.Calendars;

namespace Delsoft.Holidays.Extensions;

public static class BelgianHolidaysExtension
{
    public static DateTime LaborDay(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 5, 1);
    public static DateTime NationalHoliday(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 7, 21);

}