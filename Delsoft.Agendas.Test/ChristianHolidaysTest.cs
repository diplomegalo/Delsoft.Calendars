using System;
using Delsoft.Agendas.Dates;
using Delsoft.Agendas.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Test;

public class ChristianHolidaysTest
{
    private readonly CustomCalendarStub _currentYear;
    private readonly CustomCalendarStub _year2022;

    public ChristianHolidaysTest()
    {
        _currentYear = new CustomCalendarStub(new AgendaStub());
        _year2022 = new CustomCalendarStub(new AgendaStub(2022));
    }

    [Fact]
    public void Can_Get_Easter()
    {
        // Arrange
        var expected = new DateTime(2022, 04, 17);

        // Assert
        _year2022.Easter().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void Can_Get_EasterMonday()
    {
        // Arrange
        var expected = new DateTime(2022, 4, 18);

        // Assert
        _year2022.EasterMonday().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void Can_Get_Ascent()
    {
        // Arrange
        var expected = new DateTime(2022, 5, 26);

        // Assert
        _year2022.Ascent().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void Can_Get_PentecostMonday()
    {
        // Arrange
        var expected = new DateTime(2022, 6, 6);

        // Assert
        _year2022.PentecostMonday().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void Can_Get_Assumption()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 8, 15);

        // Assert
        _currentYear.Assumption().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void Can_Get_Toussaint()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 11, 1);

        // Assert
        _currentYear.Toussaint().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void Can_Get_Christmas()
    {
        // Arrange
        var expected = new DateTime(DateTime.Today.Year, 12, 25);

        // Assert
        _currentYear.Christmas().ShouldBeEquivalentTo(expected);
    }
}