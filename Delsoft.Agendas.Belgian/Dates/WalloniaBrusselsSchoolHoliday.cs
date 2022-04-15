namespace Delsoft.Agendas.Belgian.Dates;

public static class WalloniaBrusselsSchoolHoliday
{
    public static DateTime FrenchCommunityHoliday(this Agenda calendar) => new(calendar.Year, 9, 27);

    public static (DateTime, DateTime) AutumnHoliday(this Agenda calendar) => (
        new DateTime(calendar.Year, 11, 1),
        new DateTime(calendar.Year, 11, 5));
}
