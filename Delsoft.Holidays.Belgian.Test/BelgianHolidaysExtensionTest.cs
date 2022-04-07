using System;
using Delsoft.Holidays.Calendars;
using Delsoft.Holidays.Extensions;
using Shouldly;
using Xunit;

namespace Delsoft.Holidays.Belgian.Test;

public class BelgianHolidaysExtensionTest
{
    private readonly BelgianHolidayCalendar _currentYear;

    public BelgianHolidaysExtensionTest()
    {
        _currentYear = HolidayCalendar.Create<BelgianHolidayCalendar>();
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