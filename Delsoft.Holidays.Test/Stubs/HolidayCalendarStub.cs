using Delsoft.Holidays;

namespace Delsoft.Calendars.Test.Stubs;

internal class HolidayCalendarStub : HolidayCalendar
{
    public HolidayCalendarStub()
    {
    }

    public HolidayCalendarStub(int year)
    {
        Year = year;
    }
}