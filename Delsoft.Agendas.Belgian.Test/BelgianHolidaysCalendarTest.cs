using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Delsoft.Agendas.Belgian.Calendars;
using Delsoft.Agendas.Belgian.Dates;
using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Models;
using Shouldly;
using Xunit;
using HolidaysExtension = Delsoft.Agendas.Dates.HolidaysExtension;

namespace Delsoft.Agendas.Belgian.Test;

public class BelgianHolidaysCalendarTest
{
    private readonly ILegalHolidayCalendar _legalHolidayCalendar;

    public BelgianHolidaysCalendarTest()
    {
        _legalHolidayCalendar = CustomCalendar.Factory.Create<BelgianHolidayCalendar>(new BelgianAgenda());
    }

    [Theory]
    [InlineData("Easter", "fr", "Pâques", "Easter")]
    [InlineData("Easter", "nl", "Pasen", "Easter")]
    [InlineData("Easter", "", "Easter", "Easter")]
    [InlineData("EasterMonday", "fr", "Lundi de Pâques", "Easter Monday")]
    [InlineData("EasterMonday", "nl", "Tweede Paasdag", "Easter Monday")]
    [InlineData("EasterMonday", "", "Easter Monday", "Easter Monday")]
    [InlineData("Ascent", "fr", "Ascension", "Ascent")]
    [InlineData("Ascent", "nl", "Beklimming", "Ascent")]
    [InlineData("Ascent", "", "Ascent", "Ascent")]
    [InlineData("PentecostMonday", "fr", "Lundi de Pentecôte", "Pentecost Monday")]
    [InlineData("PentecostMonday", "nl", "Pinkstermaandag", "Pentecost Monday")]
    [InlineData("PentecostMonday", "", "Pentecost Monday", "Pentecost Monday")]
    [InlineData("Assumption", "fr", "Assomption", "Assumption")]
    [InlineData("Assumption", "nl", "Aanname", "Assumption")]
    [InlineData("Assumption", "", "Assumption", "Assumption")]
    [InlineData("Toussaint", "fr", "Toussaint", "Toussaint")]
    [InlineData("Toussaint", "nl", "Toussaint", "Toussaint")]
    [InlineData("Toussaint", "", "Toussaint", "Toussaint")]
    [InlineData("Christmas", "fr", "Noël", "Christmas")]
    [InlineData("Christmas", "nl", "Kerstmis", "Christmas")]
    [InlineData("Christmas", "", "Christmas", "Christmas")]
    [InlineData("NewYear", "fr", "Nouvel An", "New Year")]
    [InlineData("NewYear", "nl", "Nieuwjaar", "New Year")]
    [InlineData("NewYear", "", "New Year", "New Year")]
    [InlineData("LaborDay", "fr", "Fête du travail", "Labor Day")]
    [InlineData("LaborDay", "nl", "Dag van de Arbeid", "Labor Day")]
    [InlineData("LaborDay", "", "Labor Day", "Labor Day")]
    [InlineData("NationalHoliday", "fr", "Fête Nationale", "National Holiday")]
    [InlineData("NationalHoliday", "nl", "Nationale feestdag", "National Holiday")]
    [InlineData("NationalHoliday", "", "National Holiday", "National Holiday")]
    [InlineData("Armistice", "fr", "Armistice", "Armistice")]
    [InlineData("Armistice", "nl", "Wapenstilstand", "Armistice")]
    [InlineData("Armistice", "", "Armistice", "Armistice")]
    public void Can_Get_Holiday(string propertyName, string culture, string localName, string name)
    {
        // Arrange
        CultureInfo.CurrentUICulture = culture != string.Empty
            ? CultureInfo.CreateSpecificCulture(culture)
            : CultureInfo.InvariantCulture;

        var propertyInfo = typeof(ILegalHolidayCalendar)
                               .GetProperty(propertyName)
                           ?? throw new InvalidOperationException($"Unable to find the {propertyName} property");

        var methodName = propertyName;
        var type = typeof(HolidaysExtension);
        switch (propertyName)
        {
            case "NationalHoliday":
            case "LaborDay":
                type = typeof(NationalHolidays);
                break;
            case "Armistice":
                methodName = nameof(HolidaysExtension.Armistice1918);
                break;
        }

        var methodInfo = type.GetMethod(methodName, BindingFlags.Static | BindingFlags.Public)
                         ?? throw new InvalidOperationException($"Unable to find the {propertyName} method");

        var expectedDate = methodInfo.Invoke(null, new object?[] { _legalHolidayCalendar });

        // Act
        var holiday = (Event)propertyInfo.GetValue(_legalHolidayCalendar)!;

        // Assert
        holiday.ShouldNotBeNull();
        holiday.StartDate.ShouldBe(expectedDate);
        holiday.EndDate.ShouldBe(holiday.StartDate);
        holiday.Name.ShouldBe(name);
        holiday.LocalName.ShouldBe(localName);
    }

    [Fact]
    public void Can_Get_Culture()
    {
        // Act
        var cultures = _legalHolidayCalendar.GetCultures();

        // Assert
        cultures.ShouldContain("fr");
        cultures.ShouldContain("nl");
        cultures.Length.ShouldBe(2);
    }

    [Fact]
    public void Can_Get_All()
    {
        // Act
        var holidays = _legalHolidayCalendar.GetAll()
            .ToList();

        // Assert
        holidays.Count.ShouldBe(11);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(2002)]
    public void Can_Create_Belgian_Holidays_Calendar(int? year)
    {
        var holidayCalendar = CustomCalendar.Factory.Create<BelgianHolidayCalendar>(new BelgianAgenda(year));

        // Assert
        holidayCalendar.ShouldNotBeNull();
    }
}