namespace Delsoft.Calendars.Test.Stubs;

internal class CalendarStub : BaseCalendar<HolidaysCalendarStub>, ICalendarStub
{
    public CalendarStub(int? year = null)
        : base(year)
    {

    }

    public override string[] GetCultures() => new[] { "fr", "nl" };
}