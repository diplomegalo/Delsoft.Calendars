using System;
using Delsoft.Calendars.Belgian.Holidays;
using Delsoft.Calendars.Calendars;
using Delsoft.Calendars.Extensions;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Belgian.Test;

public class BelgianHolidaysExtensionTest
{
    private readonly HolidaysCalendar _currentYear;

    public BelgianHolidaysExtensionTest()
    {
        _currentYear = HolidayCalendar.Create<HolidaysCalendar>();
    }
    
    [Fact]
    public void Can_Get_LaborDay()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 5, 1);
        
        // Assert
        _currentYear.LaborDay().ShouldBeEquivalentTo(expected);
    }
    
    [Fact]
    public void Can_Get_BelgianNationalHoliday()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 7, 21);

        // Assert
        _currentYear.NationalHoliday().ShouldBeEquivalentTo(expected);
    }
}