using System;
using System.Globalization;
using System.Linq;
using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Test.Stubs;
using Delsoft.Calendars.Test.Resources;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Test;

public class HolidayCalendarTest
{
    private readonly ICustomCalendarStub _calendar;
    private readonly ICustomCalendarStub _2002Calendar;

    public HolidayCalendarTest()
    {
        _2002Calendar = CustomCalendar.Factory.Create<CustomCalendarStub>(new AgendaStub(2002));
        _calendar = CustomCalendar.Factory.Create<CustomCalendarStub>(new AgendaStub());
    }

    [Fact]
    public void Can_Create_Default_Calendar()
    {
        // Act

        // Assert
        _calendar.Year.ShouldBe(DateTime.Today.Year);
    }

    [Fact]
    public void Can_Create_Specific_Year_Calendar()
    {
        // Arrange
        // Act
        const int year = 2002;

        // Assert
        _2002Calendar.Year.ShouldBe(year);
    }

    [Fact]
    public void Can_Get_Holiday_List()
    {
        // Arrange
        var holiday1LocalName = Delsoft.Calendars.Test.Resources.Translation.Holiday1;
        var holiday2LocalName = Delsoft.Calendars.Test.Resources.Translation.Holiday2;
        var holiday1Name = Translation.ResourceManager.GetString(nameof(CustomCalendarStub.Holiday1));
        var holiday2Name = Translation.ResourceManager.GetString(nameof(CustomCalendarStub.Holiday2));

        // Act
        var list = _calendar.Get(cal => cal.Holiday1, cal => cal.Holiday2)
            .ToList();

        // Assert
        list.Count.ShouldBe(2);
        list.First().DateStart.ShouldBe(CustomCalendarStub.Holiday1Date);
        list.First().Name.ShouldBe(holiday1Name);
        list.First().LocalName.ShouldBe(holiday1LocalName);
        list.ElementAt(1).DateStart.ShouldBe(CustomCalendarStub.Holiday2Date);
        list.ElementAt(1).Name.ShouldBe(holiday2Name);
        list.ElementAt(1).LocalName.ShouldBe(holiday2LocalName);
    }

    [Fact]
    public void Can_Get_Holiday_By_Name()
    {
        // Arrange
        var holidays1Name = Delsoft.Calendars.Test.Resources.Translation.ResourceManager.GetString(nameof(_calendar.Holiday1), CultureInfo.InvariantCulture)
            ?? throw new InvalidOperationException($"Cannot find translation for {nameof(_calendar.Holiday1)}");
        var holidays2Name = Delsoft.Calendars.Test.Resources.Translation.ResourceManager.GetString(nameof(_calendar.Holiday2), CultureInfo.InvariantCulture)
                            ?? throw new InvalidOperationException($"Cannot find translation for {nameof(_calendar.Holiday2)}");
        var holiday1LocalName = Delsoft.Calendars.Test.Resources.Translation.Holiday1;
        var holiday2LocalName = Delsoft.Calendars.Test.Resources.Translation.Holiday2;

        // Act
        var holidays = _calendar.Get(holidays1Name, holidays2Name)
            .ToList();

        // Assert
        holidays.Count.ShouldBe(2);
        holidays.ElementAt(0).DateStart.ShouldBe(_calendar.Holiday1.DateStart);
        holidays.ElementAt(0).Name.ShouldBe(_calendar.Holiday1.Name);
        holidays.ElementAt(0).LocalName.ShouldBe(holiday1LocalName);
        holidays.ElementAt(1).DateStart.ShouldBe(_calendar.Holiday2.DateStart);
        holidays.ElementAt(1).Name.ShouldBe(_calendar.Holiday2.Name);
        holidays.ElementAt(1).LocalName.ShouldBe(holiday2LocalName);
    }
}