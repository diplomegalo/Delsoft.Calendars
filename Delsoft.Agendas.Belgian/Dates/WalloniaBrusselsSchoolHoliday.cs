namespace Delsoft.Agendas.Belgian.Dates;

public static class WalloniaBrusselsSchoolHoliday
{
    public static DateTime FrenchCommunityHoliday(this Agenda calendar) => new(calendar.Year - 1, 9, 27);

    public static (DateTime, DateTime) AutumnHoliday(this Agenda agenda) => (
        new DateTime(agenda.Year - 1, 11, 1),
        new DateTime(agenda.Year - 1, 11, 5));

    public static DateTime CommemorationOf11November(this Agenda agenda) => new (agenda.Year - 1, 11, 11);
}
