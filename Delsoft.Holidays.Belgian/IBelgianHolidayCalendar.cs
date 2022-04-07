using Delsoft.Holidays.Models;

namespace Delsoft.Holidays.Calendars;

public interface IBelgianHolidayCalendar : IHolidayCalendar
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