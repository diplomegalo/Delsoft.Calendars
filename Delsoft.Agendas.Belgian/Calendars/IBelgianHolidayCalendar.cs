using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Models;

namespace Delsoft.Agendas.Belgian.Calendars;

public interface IBelgianHolidayCalendar: ICustomCalendar<BelgianHolidayCalendar>
{
    public Event Easter { get; }
    public Event EasterMonday { get; }
    public Event Ascent { get; }
    public Event PentecostMonday { get; }
    public Event Assumption { get; }
    public Event Toussaint { get; }
    public Event Christmas { get; }
    public Event NewYear { get; }
    public Event LaborDay { get; }
    public Event NationalHoliday { get; }
    public Event Armistice { get; }
}