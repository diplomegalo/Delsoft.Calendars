using System;
using System.Globalization;
using Delsoft.Calendars.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Test;

public class CalendarTest
{
    [Fact]
    public void Can_Create_Calendar()
    {
        // Arrange
        var year = DateTime.Today.Year;

        // Act
        var calendar = CalendarFactory.Create<CalendarStub>();

        // Assert
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
        calendar.ShouldBeAssignableTo(typeof(CalendarStub));
        calendar.ShouldBeAssignableTo(typeof(ICalendarStub));

        // TODO : Move year property to the BaseCalendar class.
        calendar.Holidays.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Create_Calendar_Interface()
    {
        // Arrange
        var year = DateTime.Today.Year;

        // Act
        var calendar = CalendarFactory.Create<ICalendarStub>();

        // Assert
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
        calendar.ShouldBeAssignableTo(typeof(CalendarStub));
        calendar.ShouldBeAssignableTo(typeof(ICalendarStub));

        // TODO : Move year property to the BaseCalendar class.
        calendar.Holidays.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Create_Calendar_With_Specific_Year()
    {
        // Arrange
        var year = 2002;

        // Act
        var calendar = CalendarFactory.Create<CalendarStub>(year);

        // Assert
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
        calendar.Holidays.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Create_Factory_From_Instance()
    {
        // Arrange
        var factory = new CalendarFactory<CalendarStub>();

        // Act
        var stub = factory.Create();

        // Assert
        stub.ShouldNotBeNull();
        stub.Holidays.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Get_Local_Name()
    {
        // Arrange
        var calendar = CalendarFactory.Create<CalendarStub>();

        foreach (var holiday in calendar.Holidays.GetAll())
        {
            var actual = holiday.Name;
            foreach (var culture in calendar.Holidays.GetCultures())
            {
                CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
                var expected = holiday.LocalName;
                actual.ShouldNotBe(expected);
                actual = expected;
            }
        }
    }
}