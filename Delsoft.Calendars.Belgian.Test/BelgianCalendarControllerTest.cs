using Delsoft.Calendars.Belgian.Controllers;
using Delsoft.Calendars.Belgian.Holidays;
using Delsoft.Calendars.Holidays;
using Microsoft.VisualBasic;
using Moq;
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

    [Fact]
    public void Can_Get_All_With_Year()
    {
        // Arrange
        var year = 2002;

        // Act
        _controller.GetAll(year);

        // Assert
        _calendarFactoryMock.Verify(factory => factory.Create(year));
        _belgianCalendarMock.VerifyGet(calendar => calendar.Holidays);
        _belgianHolidaysCalendarMock.Verify(calendar => calendar.GetAll());
    }

    [Fact]
    public void Can_Get_All()
    {
        // Arrange

        // Act
        _controller.GetAll();

        // Assert
        _calendarFactoryMock.Verify(factory => factory.Create(null));
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
        _ = year == null
            ? _controller.Get(holidayName)
            : _controller.Get(year.Value, holidayName);

        // Assert
        _calendarFactoryMock.Verify(factory => factory.Create(year));
        _belgianCalendarMock.VerifyGet(calendar => calendar.Holidays);
        _belgianHolidaysCalendarMock.Verify(calendar => calendar.Get(holidayName));
    }
}