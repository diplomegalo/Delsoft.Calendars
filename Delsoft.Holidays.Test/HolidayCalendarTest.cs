using System;
using System.Globalization;
using System.Linq;
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
    }

    [Fact]
    public void Can_Compose_Calendar()
    {
        // Arrange
        var holidayCalendar = HolidayCalendar.Create<HolidayCalendarStub>();

        // Act
        var list = holidayCalendar.Get(
            cal => cal.Holiday1, cal => cal.Holiday2)
            .ToList();
        
        // Assert
        list.Count.ShouldBe(2);
        list.First().Date.ShouldBe(HolidayCalendarStub.Holiday1Date);
        list.First().Name.ShouldBe(HolidayCalendarStub.Holiday1Name);
        list.First().LocalName.ShouldBe(HolidayCalendarStub.Holiday1LocalName);
        list.ElementAt(1).Date.ShouldBe(HolidayCalendarStub.Holiday2Date);
        list.ElementAt(1).Name.ShouldBe(HolidayCalendarStub.Holiday2Name);
        list.ElementAt(1).LocalName.ShouldBe(HolidayCalendarStub.Holiday2LocalName);
    }
}