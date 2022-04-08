using System;
using System.Linq;
using Delsoft.Calendars;
using Delsoft.Calendars.Holidays;
using Delsoft.Calendars.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Test;

public class HolidayCalendarTest
{
    [Fact]
    public void Can_Create_Default_Calendar()
    {
        // Act
        var holidayCalendar = HolidaysCalendar.Create<HolidaysCalendarStub>();

        // Assert
        holidayCalendar.Year.ShouldBe(DateTime.Today.Year);
    }
    
    [Fact]
    public void Can_Create_Specific_Year_Calendar()
    {
        // Arrange
        var year = DateTime.Today.Year - 10;
        
        // Act
        var holidayCalendar = HolidaysCalendar.Create<HolidaysCalendarStub>(year);

        // Assert
        holidayCalendar.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Get_Holiday_List()
    {
        // Arrange
        var holidayCalendar = HolidaysCalendar.Create<HolidaysCalendarStub>();

        // Act
        var list = holidayCalendar.Get(
            cal => cal.Holiday1, cal => cal.Holiday2)
            .ToList();
        
        // Assert
        list.Count.ShouldBe(2);
        list.First().Date.ShouldBe(HolidaysCalendarStub.Holiday1Date);
        list.First().Name.ShouldBe(HolidaysCalendarStub.Holiday1Name);
        list.First().LocalName.ShouldBe(HolidaysCalendarStub.Holiday1LocalName);
        list.ElementAt(1).Date.ShouldBe(HolidaysCalendarStub.Holiday2Date);
        list.ElementAt(1).Name.ShouldBe(HolidaysCalendarStub.Holiday2Name);
        list.ElementAt(1).LocalName.ShouldBe(HolidaysCalendarStub.Holiday2LocalName);
    }
}