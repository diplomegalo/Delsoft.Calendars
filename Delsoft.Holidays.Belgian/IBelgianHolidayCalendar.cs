using Delsoft.Holidays.Models;

namespace Delsoft.Holidays.Calendars;

public interface IBelgianHolidayCalendar : IHolidayCalendar
{
    public Models.Holidays Easter { get; }
    public Models.Holidays EasterMonday { get; }
    public Models.Holidays Ascent { get; }
    public Models.Holidays PentecostMonday { get; }
    public Models.Holidays Assumption { get; }
    public Models.Holidays Toussaint { get; }
    public Models.Holidays Christmas { get; }
    public Models.Holidays NewYear { get; }
    public Models.Holidays LaborDay { get; }
    public Models.Holidays NationalHolidays { get; }
    public Models.Holidays Armistice { get; }
}