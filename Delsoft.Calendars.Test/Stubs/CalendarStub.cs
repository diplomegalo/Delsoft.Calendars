namespace Delsoft.Calendars.Test.Stubs;

internal class CalendarStub : BaseCalendar<HolidaysCalendarStub>, ICalendarStub
{
    public CalendarStub()
    {
    }

    public CalendarStub(int year)
        : base(year)
    {

    }
}