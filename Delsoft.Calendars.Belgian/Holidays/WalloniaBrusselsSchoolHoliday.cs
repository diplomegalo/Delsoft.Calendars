using Delsoft.Calendars.Models;

namespace Delsoft.Calendars.Belgian.Holidays;

public static class WalloniaBrusselsSchoolHoliday
{
    public static DateTime FrenchCommunityHoliday(this BaseCalendar calendar) => new(calendar.Year, 9, 27);

    public static (DateTime, DateTime) AutumnHoliday(this BaseCalendar calendar) => (
        new DateTime(calendar.Year, 11, 1),
        new DateTime(calendar.Year, 11, 5));
}
