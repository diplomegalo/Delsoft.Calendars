using Delsoft.Agendas.Belgian.Calendars;
using Delsoft.Agendas.Calendars;

namespace Delsoft.Agendas.Belgian;

public class BelgianAgenda : Agenda, IBelgianAgenda
{
    public BelgianAgenda(int? year = null)
        : base(year)
    {
    }

    public override string[] GetCultures() => new[] { "fr", "nl" };
    public IBelgianHolidayCalendar Holidays => CustomCalendar.Factory.Create<BelgianHolidayCalendar>(this);
}