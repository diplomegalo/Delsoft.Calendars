using Delsoft.Agendas.Belgian.Calendars;
using Delsoft.Agendas.Calendars;

namespace Delsoft.Agendas.Belgian;

public class BelgianAgenda : Agenda, IBelgianAgenda
{
    private IBelgianHolidayCalendar? _belgianHolidayCalendar;

    public BelgianAgenda(int? year = null)
        : base(year)
    {
    }

    public override string[] GetCultures() => new[] { "fr", "nl" };
    public IBelgianHolidayCalendar BelgianHolidayCalendar => _belgianHolidayCalendar
        ??= CustomCalendar.Factory.Create<BelgianHolidayCalendar>(this);
    public ILegalHolidayCalendar LegalHolidaysCalendar => BelgianHolidayCalendar;
}