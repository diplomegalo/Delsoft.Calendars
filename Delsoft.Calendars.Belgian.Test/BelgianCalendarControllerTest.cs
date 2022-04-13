using Delsoft.Calendars.Belgian.Controllers;
using Delsoft.Calendars.Belgian.Holidays;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace Delsoft.Calendars.Belgian.Test;

public class BelgianCalendarControllerTest
{
    private BelgianCalendarController _controller;
    private Mock<ICalendarFactory<IBelgianCalendar>> _calendarFactoryMock;
    private Mock<IBelgianCalendar> _belgianCalendarMock;
    private Mock<IBelgianHolidaysCalendar> _belgianHolidaysCalendarMock;

    public BelgianCalendarControllerTest()
    {
        _belgianHolidaysCalendarMock = new Mock<IBelgianHolidaysCalendar>();

        _belgianCalendarMock = new Mock<IBelgianCalendar>();
        _belgianCalendarMock.SetupGet(calendar => calendar.Holidays)
            .Returns(_belgianHolidaysCalendarMock.Object);

        _calendarFactoryMock = new Mock<ICalendarFactory<IBelgianCalendar>>();
        _calendarFactoryMock.Setup(factory => factory.Create(It.IsAny<int?>()))
            .Returns(_belgianCalendarMock.Object);

        _controller = new BelgianCalendarController(_calendarFactoryMock.Object);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(2002)]
    public void Can_Get_All_With_Year(int? year)
    {
        // Arrange

        // Act
        _controller.GetAll(year);

        // Assert
        _calendarFactoryMock.Verify(factory => factory.Create(year));
        _belgianCalendarMock.VerifyGet(calendar => calendar.Holidays);
        _belgianHolidaysCalendarMock.Verify(calendar => calendar.GetAll());
    }

    [Theory]
    [InlineData(null, "Armistice")]
    [InlineData(2002, "Armistice")]
    public void Can_Get_Holiday_With_Year(int? year, string holidayName)
    {
        // Arrange

        // Act
        _ = _controller.Get(year, holidayName);

        // Assert
        _calendarFactoryMock.Verify(factory => factory.Create(year));
        _belgianCalendarMock.VerifyGet(calendar => calendar.Holidays);
        _belgianHolidaysCalendarMock.Verify(calendar => calendar.Get(holidayName));
    }

    [Theory]
    [InlineData(null)]
    [InlineData(2002)]
    public void Can_Get_All_Holidays(int? year)
    {
        // Arrange
        var controller = new BelgianCalendarController(new CalendarFactory<IBelgianCalendar>());

        // Act
        var result = controller.GetAll(year);

        // Assert
        result.ShouldBeAssignableTo<OkObjectResult>();
    }

    [Theory]
    [InlineData(null, "Armistice")]
    [InlineData(2002, "Armistice")]
    public void Can_Get_Specific_Holidays(int? year, string holidayName)
    {
        // Arrange
        var controller = new BelgianCalendarController(new CalendarFactory<IBelgianCalendar>());

        // Act
        var result = controller.Get(year, holidayName);

        // Assert
        result.ShouldBeAssignableTo<OkObjectResult>();
    }
}