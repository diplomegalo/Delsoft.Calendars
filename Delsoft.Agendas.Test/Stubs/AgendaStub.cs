using Delsoft.Agendas.Calendars;

namespace Delsoft.Agendas.Test.Stubs;

internal class AgendaStub : Agenda, IAgendaStub
{
    public AgendaStub(int? year = null)
        : base(year)
    {
    }

    public override string[] GetCultures() => new[] { "fr", "nl" };

    public ICustomCalendarStub CustomCalendar => Calendars.CustomCalendar.Factory.Create<CustomCalendarStub>(this);
}