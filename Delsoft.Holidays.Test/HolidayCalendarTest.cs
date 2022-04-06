using System;
using System.Globalization;
using Delsoft.Calendars.Test.Stubs;
using Delsoft.Holidays;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Test;

public class HolidayCalendarTest
{
    [Fact]
    public void Can_Create_Default_Calendar()
    {
        // Act
        var holidayCalendar = HolidayCalendar.Create<HolidayCalendarStub>();

        // Assert
        holidayCalendar.Year.ShouldBe(DateTime.Today.Year);
        holidayCalendar.CultureInfo.ShouldBe(CultureInfo.CurrentCulture);
    }
    
    [Fact]
    public void Can_Create_Specific_Year_Calendar()
    {
        // Arrange
        var year = DateTime.Today.Year - 10;
        
        // Act
        var holidayCalendar = HolidayCalendar.Create<HolidayCalendarStub>(year);

        // Assert
        holidayCalendar.Year.ShouldBe(year);
        holidayCalendar.CultureInfo.ShouldBe(CultureInfo.CurrentCulture);
    }
}