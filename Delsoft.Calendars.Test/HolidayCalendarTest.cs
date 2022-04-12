using System;
using System.Globalization;
using System.Linq;
using Delsoft.Calendars.Holidays;
using Delsoft.Calendars.Test.Resources;
using Delsoft.Calendars.Test.Stubs;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Test;

public class HolidayCalendarTest
{
    [Fact]
    public void Can_Create_Default_Calendar()
    {
        // Act
        var holidayCalendar = HolidaysCalendar.Factory.Create<HolidaysCalendarStub>();

        // Assert
        holidayCalendar.Year.ShouldBe(DateTime.Today.Year);
    }

    [Fact]
    public void Can_Create_Specific_Year_Calendar()
    {
        // Arrange
        var year = DateTime.Today.Year - 10;

        // Act
        var holidayCalendar = HolidaysCalendar.Factory.Create<HolidaysCalendarStub>(year);

        // Assert
        holidayCalendar.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Get_Holiday_List()
    {
        // Arrange
        var holidayCalendar = HolidaysCalendar.Factory.Create<HolidaysCalendarStub>();
        var holiday1LocalName = Resources.Translation.Holiday1;
        var holiday2LocalName = Resources.Translation.Holiday2;
        var holiday1Name = Translation.ResourceManager.GetString(nameof(HolidaysCalendarStub.Holiday1));
        var holiday2Name = Translation.ResourceManager.GetString(nameof(HolidaysCalendarStub.Holiday2));

        // Act
        var list = holidayCalendar.Get(
            cal => cal.Holiday1, cal => cal.Holiday2)
            .ToList();

        // Assert
        list.Count.ShouldBe(2);
        list.First().Date.ShouldBe(HolidaysCalendarStub.Holiday1Date);
        list.First().Name.ShouldBe(holiday1Name);
        list.First().LocalName.ShouldBe(holiday1LocalName);
        list.ElementAt(1).Date.ShouldBe(HolidaysCalendarStub.Holiday2Date);
        list.ElementAt(1).Name.ShouldBe(holiday2Name);
        list.ElementAt(1).LocalName.ShouldBe(holiday2LocalName);
    }

    [Fact]
    public void Can_Get_Holiday_By_Name()
    {
        // Arrange
        var calendar = HolidaysCalendar.Factory.Create<IHolidaysCalendarStub>();
        var name = Resources.Translation.ResourceManager.GetString(nameof(calendar.Holiday1), CultureInfo.InvariantCulture);
        var localName = Resources.Translation.Holiday1;

        // Act
        var holidays = calendar.Get(name);

        // Assert
        holidays.ShouldBeUnique();
        holidays.Single().Date.ShouldBe(calendar.Holiday1.Date);
        holidays.Single().Name.ShouldBe(calendar.Holiday1.Name);
        holidays.Single().LocalName.ShouldBe(localName);
    }
}