using Delsoft.Agendas.Calendars;

namespace Delsoft.Agendas.Belgian.Dates;

public static class NationalHolidays
{
    public static DateTime LaborDay(this CustomCalendar customCalendar) => new(customCalendar.Year, 5, 1);
    public static DateTime NationalHoliday(this CustomCalendar customCalendar) => new(customCalendar.Year, 7, 21);
}