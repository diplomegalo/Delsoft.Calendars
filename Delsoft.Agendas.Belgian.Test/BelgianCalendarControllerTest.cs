using Delsoft.Agendas.Belgian.Calendars;
using Delsoft.Agendas.Belgian.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Belgian.Test;

public class BelgianCalendarControllerTest
{
    private readonly BelgianCalendarController _controller;
    private readonly Mock<IAgendaFactory<IBelgianAgenda>> _agendaFactoryMock;
    private readonly Mock<IBelgianAgenda> _belgianAgendaMock;
    private readonly Mock<ILegalHolidayCalendar> _legalHolidaysCalendarMock;
    private readonly Mock<IBelgianHolidayCalendar> _belgianHolidayCalendarMock;

    public BelgianCalendarControllerTest()
    {
        _legalHolidaysCalendarMock = new Mock<ILegalHolidayCalendar>();
        _belgianHolidayCalendarMock = new Mock<IBelgianHolidayCalendar>();

        _belgianAgendaMock = new Mock<IBelgianAgenda>();
        _belgianAgendaMock.SetupGet(calendar => calendar.LegalHolidaysCalendar)
            .Returns(_legalHolidaysCalendarMock.Object);
        _belgianAgendaMock.SetupGet(calendar => calendar.BelgianHolidayCalendar)
            .Returns(_belgianHolidayCalendarMock.Object);

        _agendaFactoryMock = new Mock<IAgendaFactory<IBelgianAgenda>>();
        _agendaFactoryMock.Setup(factory => factory.Create(It.IsAny<int?>()))
            .Returns(_belgianAgendaMock.Object);

        _controller = new BelgianCalendarController(_agendaFactoryMock.Object);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(2002)]
    public void Can_Get_All_With_Year(int? year)
    {
        // Arrange

        // Act
        _controller.GetLegalHolidays(year);

        // Assert
        _agendaFactoryMock.Verify(factory => factory.Create(year));
        _belgianAgendaMock.VerifyGet(calendar => calendar.LegalHolidaysCalendar);
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
        _agendaFactoryMock.Verify(factory => factory.Create(year));
        _belgianAgendaMock.VerifyGet(calendar => calendar.BelgianHolidayCalendar);
        _belgianHolidayCalendarMock.Verify(calendar => calendar.Get(holidayName));
    }

    [Theory]
    [InlineData(null)]
    [InlineData(2002)]
    public void Can_Get_All_Holidays(int? year)
    {
        // Arrange
        var controller = new BelgianCalendarController(new AgendaFactory<IBelgianAgenda>());

        // Act
        var result = controller.GetLegalHolidays(year);

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