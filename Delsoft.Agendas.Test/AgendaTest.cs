using System;
using System.Globalization;
using System.Linq;
using Delsoft.Agendas.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Test;

public class AgendaTest
{
    [Fact]
    public void Can_Create_Agenda()
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
    public void Can_Create_Agenda_Interface()
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
    public void Can_Create_Agenda_With_Specific_Year()
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

    [Fact]
    public void Can_Get_All_Event()
    {
        // Arrange
        var agenda = AgendaFactory.Create<AgendaStub>();

        // Act
        var actual = agenda
            .GetAll(x => x.CustomCalendar)
            .ToList();

        // Assert
        actual.ShouldNotBeEmpty();
    }
}