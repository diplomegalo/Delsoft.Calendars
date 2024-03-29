﻿using System;
using System.Globalization;
using System.Linq;
using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Exceptions;
using Delsoft.Agendas.Test.Stubs;
using Delsoft.Calendars.Test.Resources;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Test;

public class CustomCalendarTest
{
    private readonly ICustomCalendarStub _calendar;
    private readonly ICustomCalendarStub _2002Calendar;
    private readonly AgendaStub _agenda;

    public CustomCalendarTest()
    {
        _agenda = new AgendaStub();
        _2002Calendar = CustomCalendar.Factory.Create<CustomCalendarStub>(new AgendaStub(2002));
        _calendar = CustomCalendar.Factory.Create<CustomCalendarStub>(_agenda);
    }

    [Fact]
    public void Can_Create_Default_Calendar()
    {
        // Act

        // Assert
        _calendar.Year.ShouldBe(DateTime.Today.Year);
        _calendar.GetCultures().ShouldBe(_agenda.GetCultures(), true);
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
        list.First().StartDate.ShouldBe(CustomCalendarStub.Holiday1Date);
        list.First().Name.ShouldBe(holiday1Name);
        list.First().LocalName.ShouldBe(holiday1LocalName);
        list.ElementAt(1).StartDate.ShouldBe(CustomCalendarStub.Holiday2Date);
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
        holidays.ElementAt(0).StartDate.ShouldBe(_calendar.Holiday1.StartDate);
        holidays.ElementAt(0).Name.ShouldBe(_calendar.Holiday1.Name);
        holidays.ElementAt(0).LocalName.ShouldBe(holiday1LocalName);
        holidays.ElementAt(1).StartDate.ShouldBe(_calendar.Holiday2.StartDate);
        holidays.ElementAt(1).Name.ShouldBe(_calendar.Holiday2.Name);
        holidays.ElementAt(1).LocalName.ShouldBe(holiday2LocalName);
    }

    [Fact]
    public void Cannot_Found_Unknow_Holiday()
    {
        // Act
        var method = () => _calendar.Get("plop").ToList();

        // Assert
        method.ShouldThrow<EventNotFoundException>();
    }
}