using Delsoft.Agendas.Belgian.Calendars;

namespace Delsoft.Agendas.Belgian;

public interface IBelgianAgenda : IAgenda
{
    IBelgianHolidayCalendar BelgianHolidayCalendar { get; }
    ILegalHolidayCalendar LegalHolidaysCalendar { get; }
}