using Delsoft.Calendars;

namespace Delsoft.Calendars.Extensions;

public static partial class HolidaysExtension
{
    public static DateTime NewYear(this HolidaysCalendar holidaysCalendar) => new(holidaysCalendar.Year, 1, 1);

    public static DateTime Armistice1918(this HolidaysCalendar holidaysCalendar) => new(holidaysCalendar.Year, 11, 11);

}