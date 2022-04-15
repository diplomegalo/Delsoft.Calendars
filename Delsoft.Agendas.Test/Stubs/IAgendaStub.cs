namespace Delsoft.Agendas.Test.Stubs;

internal interface IAgendaStub : IAgenda
{
    ICustomCalendarStub CustomCalendar { get; }
}