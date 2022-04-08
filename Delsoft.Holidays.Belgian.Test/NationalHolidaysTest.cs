using System;
using Delsoft.Calendars.Belgian.Holidays;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Belgian.Test;

public class NationalHolidaysTest
{
    private readonly BelgianHolidaysCalendar _currentYear;

    public NationalHolidaysTest()
    {
        _currentYear = HolidaysCalendar.Create<BelgianHolidaysCalendar>();
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