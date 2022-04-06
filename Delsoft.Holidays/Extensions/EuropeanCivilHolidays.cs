namespace Delsoft.Holidays.Extensions;

public static class EuropeanCivilHolidays
{
    public static DateTime NewYear(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 1, 1);
    public static DateTime LaborDay(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 5, 1);
    public static DateTime BelgianNationalHoliday(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 7, 21);
    public static DateTime Armistice(this HolidayCalendar holidayCalendar) => new(holidayCalendar.Year, 11, 11);

}