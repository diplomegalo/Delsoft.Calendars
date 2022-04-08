using System;
using Delsoft.Calendars.Test.Stubs;
using Delsoft.Calendars.Extensions;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Test;

public class EuropeanCivilianHolidaysTest
{
    private readonly HolidaysCalendarStub _currentYear;

    public EuropeanCivilianHolidaysTest()
    {
        _currentYear = new HolidaysCalendarStub();
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