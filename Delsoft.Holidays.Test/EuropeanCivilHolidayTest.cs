using System;
using Delsoft.Calendars.Test.Stubs;
using Delsoft.Holidays.Extensions;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Test;

public class EuropeanCivilHolidayTest
{
    private readonly HolidayCalendarStub _currentYear;

    public EuropeanCivilHolidayTest()
    {
        _currentYear = new HolidayCalendarStub();
    }
    
    [Fact]
    public void Can_Get_NewYear()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 1, 1);

        // Assert
        _currentYear.NewYear().ShouldBeEquivalentTo(expected);
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
        _currentYear.BelgianNationalHoliday().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void Can_Get_Armistice()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 11, 11);

        // Assert
        _currentYear.Armistice().ShouldBeEquivalentTo(expected);
    }
}