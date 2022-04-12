namespace Delsoft.Calendars.Test.Stubs;

internal interface ICalendarStub : IBaseCalendar
{
    HolidaysCalendarStub Holidays { get; }
}