using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Belgian.Test;

public class BelgianCalendarTest
{
    [Fact]
    public void Can_Create_Belgian_Calendar()
    {
        // Arrange
        
        // Act
        var calendar = CalendarFactory.Create<BelgianBaseCalendar>();

        // Assert
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
    }
}