namespace Delsoft.Holidays.Belgian;

public interface IBelgianHolidayCalendar : IHolidayCalendar
{
    public DateTime Easter { get; }
    public DateTime EasterMonday { get; }
    public DateTime Ascent { get; }
    public DateTime PentecostMonday { get; }
    public DateTime Assumption { get; }
    public DateTime Toussaint { get; }
    public DateTime Christmas { get; }
    public DateTime NewYear { get; }
    public DateTime LaborDay { get; }
    public DateTime NationalHoliday { get; }
    public DateTime Armistice { get; }
}