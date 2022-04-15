using System;
using Delsoft.Agendas.Dates;
using Delsoft.Agendas.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Test;

public class EuropeanCivilianHolidaysTest
{
    private readonly CustomCalendarStub _currentYear;

    public EuropeanCivilianHolidaysTest()
    {
        _currentYear = new CustomCalendarStub(new AgendaStub());
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