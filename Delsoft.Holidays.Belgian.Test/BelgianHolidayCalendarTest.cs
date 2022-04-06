using System;
using System.Globalization;
using System.Reflection;
using Delsoft.Holidays.Models;
using Shouldly;
using Xunit;

namespace Delsoft.Holidays.Belgian.Test;

public class BelgianHolidayCalendarTest
{
    private readonly BelgianHolidayCalendar _holidayCalendar;

    public BelgianHolidayCalendarTest()
    {
        _holidayCalendar = HolidayCalendar.Create<BelgianHolidayCalendar>();
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

        var propertyInfo = typeof(IBelgianHolidayCalendar)
                               .GetProperty(propertyName)
                           ?? throw new InvalidOperationException($"Unable to find the {propertyName} property");

        var methodName = propertyName == "NationalHoliday"
            ? "BelgianNationalHoliday"
            : propertyName;
        
        var methodInfo = typeof(Extensions.HolidaysExtension)
                             .GetMethod(methodName, BindingFlags.Static | BindingFlags.Public)
                         ?? throw new InvalidOperationException($"Unable to find the {propertyName} method");

        var expectedDate = methodInfo.Invoke(null, new object?[]{ _holidayCalendar });
        
        // Act
        var holiday = (Holiday)propertyInfo.GetValue(_holidayCalendar)!;

        // Assert
        holiday.ShouldNotBeNull();
        holiday.Date.ShouldBe(expectedDate);
        holiday.Name.ShouldBe(name);
        holiday.LocalName.ShouldBe(localName);
    }
}