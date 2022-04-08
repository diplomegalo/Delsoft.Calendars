using Delsoft.Calendars.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Test;

public class CalendarTest
{
    [Fact]
    public void Can_Create_Calendar()
    {
        // Arrange
        
        // Act
        var calendar = BaseCalendar.Create<CalendarStub>();
        
        // Assert 
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
    }
}