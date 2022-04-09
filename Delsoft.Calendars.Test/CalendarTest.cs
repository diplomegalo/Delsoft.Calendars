
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

        // Act
        var calendar = CalendarFactory.Create<CalendarStub>();

        // Assert
        calendar.ShouldNotBeNull();
        calendar.Holidays.ShouldNotBeNull();
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