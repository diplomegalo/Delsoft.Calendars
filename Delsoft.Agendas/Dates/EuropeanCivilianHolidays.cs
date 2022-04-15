using Delsoft.Agendas.Calendars;

namespace Delsoft.Agendas.Dates;

public static partial class HolidaysExtension
{
    public static DateTime NewYear(this CustomCalendar customCalendar) => new(customCalendar.Year, 1, 1);

    public static DateTime Armistice1918(this CustomCalendar customCalendar) => new(customCalendar.Year, 11, 11);

}