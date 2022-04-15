using Delsoft.Agendas.Belgian.Calendars;

namespace Delsoft.Agendas.Belgian;

public interface IBelgianAgenda : IAgenda
{
    IBelgianHolidayCalendar Holidays { get; }
}