using System;
using System.Globalization;
using Delsoft.Agendas.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Test;

public class CalendarTest
{
    [Fact]
    public void Can_Create_Calendar()
    {
        // Arrange
        var year = DateTime.Today.Year;

        // Act
        var calendar = AgendaFactory.Create<AgendaStub>();

        // Assert
        calendar.ShouldNotBeNull();
        calendar.CustomCalendar.ShouldNotBeNull();
        calendar.ShouldBeAssignableTo(typeof(AgendaStub));
        calendar.ShouldBeAssignableTo(typeof(IAgendaStub));

        // TODO : Move year property to the BaseCalendar class.
        calendar.CustomCalendar.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Create_Calendar_Interface()
    {
        // Arrange
        var year = DateTime.Today.Year;

        // Act
        var calendar = AgendaFactory.Create<IAgendaStub>();

        // Assert
        calendar.ShouldNotBeNull();
        calendar.CustomCalendar.ShouldNotBeNull();
        calendar.ShouldBeAssignableTo(typeof(AgendaStub));
        calendar.ShouldBeAssignableTo(typeof(IAgendaStub));

        // TODO : Move year property to the BaseCalendar class.
        calendar.CustomCalendar.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Create_Calendar_With_Specific_Year()
    {
        // Arrange
        var year = 2002;

        // Act
        var calendar = AgendaFactory.Create<AgendaStub>(year);

        // Assert
        calendar.ShouldNotBeNull();
        calendar.CustomCalendar.ShouldNotBeNull();
        calendar.CustomCalendar.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Create_Factory_From_Instance()
    {
        // Arrange
        var factory = new AgendaFactory<AgendaStub>();

        // Act
        var stub = factory.Create();

        // Assert
        stub.ShouldNotBeNull();
        stub.CustomCalendar.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Get_Local_Name()
    {
        // Arrange
        var calendar = AgendaFactory.Create<AgendaStub>();

        foreach (var holiday in calendar.CustomCalendar.GetAll())
        {
            var actual = holiday.Name;
            foreach (var culture in calendar.CustomCalendar.GetCultures())
            {
                CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
                var expected = holiday.LocalName;
                actual.ShouldNotBe(expected);
                actual = expected;
            }
        }
    }
}