using Delsoft.Calendars.Models;

namespace Delsoft.Calendars.Calendars;

public interface IBelgianHolidayCalendar : IHolidayCalendar
{
    public Models.Holiday Easter { get; }
    public Models.Holiday EasterMonday { get; }
    public Models.Holiday Ascent { get; }
    public Models.Holiday PentecostMonday { get; }
    public Models.Holiday Assumption { get; }
    public Models.Holiday Toussaint { get; }
    public Models.Holiday Christmas { get; }
    public Models.Holiday NewYear { get; }
    public Models.Holiday LaborDay { get; }
    public Models.Holiday NationalHoliday { get; }
    public Models.Holiday Armistice { get; }
}