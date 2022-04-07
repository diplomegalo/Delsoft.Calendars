using System;
using Delsoft.Holidays.Extensions;
using Delsoft.Holidays.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Holidays.Test;

public class EuropeanCivilianHolidaysTest
{
    private readonly HolidayCalendarStub _currentYear;

    public EuropeanCivilianHolidaysTest()
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
    public void Can_Get_Armistice1918()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 11, 11);

        // Assert
        _currentYear.Armistice1918().ShouldBeEquivalentTo(expected);
    }
}