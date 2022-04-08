using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars.Belgian.Holidays;

public static class NationalHolidays
{
    public static DateTime LaborDay(this HolidaysCalendar holidaysCalendar) => new(holidaysCalendar.Year, 5, 1);
    public static DateTime NationalHoliday(this HolidaysCalendar holidaysCalendar) => new(holidaysCalendar.Year, 7, 21);

}