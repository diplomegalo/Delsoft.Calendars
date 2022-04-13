using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars.Test.Stubs;

internal interface IHolidaysCalendarStub: IHolidaysCalendar<HolidaysCalendarStub>
{
    Models.Holiday Holiday1 { get; }
    Models.Holiday Holiday2 { get; }
}