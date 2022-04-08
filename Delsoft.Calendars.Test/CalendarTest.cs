﻿using Delsoft.Calendars.Test.Stubs;
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
        var calendar = CalendarFactory.Create<BaseCalendarStub>();
        
        // Assert 
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
    }
    
    [Fact]
    public void Can_Create_Calendar_With_Specific_Year()
    {
        // Arrange
        var year = 2002;
        
        // Act
        var calendar = CalendarFactory.Create<BaseCalendarStub>(year);
        
        // Assert 
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
        calendar.Holidays.Year.ShouldBe(year);
    }
}