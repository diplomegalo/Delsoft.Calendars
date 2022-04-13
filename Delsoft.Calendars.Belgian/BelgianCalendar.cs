using Delsoft.Calendars.Belgian.Holidays;

namespace Delsoft.Calendars.Belgian;

public class BelgianCalendar : BaseCalendar<IBelgianHolidaysCalendar>, IBelgianCalendar
{
    public BelgianCalendar(int? year = null)
        : base(year)
    {
    }

    public override string[] GetCultures() => new[] { "fr", "nl" };
}