namespace Delsoft.Calendars.Test.Stubs;

internal class BaseCalendarStub : BaseCalendar<HolidaysCalendarStub>
{
    public BaseCalendarStub()
    {
    }

    public BaseCalendarStub(int year) 
        : base(year)
    {
        
    }
}