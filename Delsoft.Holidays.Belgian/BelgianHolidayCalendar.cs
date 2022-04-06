using Delsoft.Holidays.Extensions;

namespace Delsoft.Holidays.Belgian;

public class BelgianHolidayCalendar : HolidayCalendar, IBelgianHolidayCalendar
{
    public DateTime Easter => this.Easter();
    public DateTime EasterMonday => this.EasterMonday();
    public DateTime Ascent => this.Ascent();
    public DateTime PentecostMonday => this.PentecostMonday();
    public DateTime Assumption => this.Assumption();

    public DateTime Toussaint => this.Toussaint();
    public DateTime Christmas => this.Christmas();
    public DateTime NewYear => this.NewYear();

    public DateTime LaborDay => this.LaborDay();
    public DateTime NationalHoliday => this.BelgianNationalHoliday();
    public DateTime Armistice => this.Armistice();
}