using System;
using Delsoft.Agendas.Belgian.Calendars;
using Delsoft.Agendas.Belgian.Dates;
using Delsoft.Agendas.Calendars;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Belgian.Test;

public class NationalHolidaysTest
{
    private readonly BelgianHolidayCalendar _currentYear;

    public NationalHolidaysTest()
    {
        _currentYear = CustomCalendar.Factory.Create<BelgianHolidayCalendar>(new BelgianAgenda());
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