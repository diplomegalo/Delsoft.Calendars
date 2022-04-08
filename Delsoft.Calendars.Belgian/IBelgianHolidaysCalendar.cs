using Delsoft.Calendars.Models;

namespace Delsoft.Calendars.Belgian;

public interface IBelgianHolidaysCalendar : IHolidaysCalendar
{
    public Holiday Easter { get; }
    public Holiday EasterMonday { get; }
    public Holiday Ascent { get; }
    public Holiday PentecostMonday { get; }
    public Holiday Assumption { get; }
    public Holiday Toussaint { get; }
    public Holiday Christmas { get; }
    public Holiday NewYear { get; }
    public Holiday LaborDay { get; }
    public Holiday NationalHoliday { get; }
    public Holiday Armistice { get; }
}