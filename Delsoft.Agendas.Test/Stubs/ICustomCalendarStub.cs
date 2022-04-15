using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Models;

namespace Delsoft.Agendas.Test.Stubs;

internal interface ICustomCalendarStub: ICustomCalendar<CustomCalendarStub>
{
    Event Holiday1 { get; }
    Event Holiday2 { get; }
}