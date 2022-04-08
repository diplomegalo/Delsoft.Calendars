using Delsoft.Calendars.Calendars;

namespace Delsoft.Calendars.Belgian.Holidays;

public static class HolidaysExtension
{
    public static DateTime LaborDay(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 5, 1);
    public static DateTime NationalHoliday(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 7, 21);

}