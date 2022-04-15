using Delsoft.Agendas.Belgian.Calendars;
using Delsoft.Agendas.Belgian.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Belgian.Test;

public class BelgianCalendarControllerTest
{
    private BelgianCalendarController _controller;
    private Mock<IAgendaFactory<IBelgianAgenda>> _calendarFactoryMock;
    private Mock<IBelgianAgenda> _belgianCalendarMock;
    private Mock<ILegalHolidayCalendar> _belgianHolidaysCalendarMock;

    public BelgianCalendarControllerTest()
    {
        _belgianHolidaysCalendarMock = new Mock<ILegalHolidayCalendar>();

        _belgianCalendarMock = new Mock<IBelgianAgenda>();
        _belgianCalendarMock.SetupGet(calendar => calendar.LegalHolidaysCalendar)
            .Returns(_belgianHolidaysCalendarMock.Object);

        _calendarFactoryMock = new Mock<IAgendaFactory<IBelgianAgenda>>();
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
        _controller.GetWalloniaBrusselsSchoolHoliday(year);

        // Assert
        _calendarFactoryMock.Verify(factory => factory.Create(year));
        _belgianCalendarMock.VerifyGet(calendar => calendar.LegalHolidaysCalendar);
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
        _belgianCalendarMock.VerifyGet(calendar => calendar.LegalHolidaysCalendar);
        _belgianHolidaysCalendarMock.Verify(calendar => calendar.Get(holidayName));
    }

    [Theory]
    [InlineData(null)]
    [InlineData(2002)]
    public void Can_Get_All_Holidays(int? year)
    {
        // Arrange
        var controller = new BelgianCalendarController(new AgendaFactory<IBelgianAgenda>());

        // Act
        var result = controller.GetWalloniaBrusselsSchoolHoliday(year);

        // Assert
        result.ShouldBeAssignableTo<OkObjectResult>();
    }

    [Theory]
    [InlineData(null, "Armistice")]
    [InlineData(2002, "Armistice")]
    public void Can_Get_Specific_Holidays(int? year, string holidayName)
    {
        // Arrange
        var controller = new BelgianCalendarController(new AgendaFactory<IBelgianAgenda>());

        // Act
        var result = controller.Get(year, holidayName);

        // Assert
        result.ShouldBeAssignableTo<OkObjectResult>();
    }
}