using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Belgian.Test;

public class BelgianCalendarTest
{
    [Fact]
    public void Can_Create_Belgian_Calendar()
    {
        // Arrange

        // Act
        var calendar = AgendaFactory.Create<BelgianAgenda>();

        // Assert
        calendar.ShouldNotBeNull();
        calendar.LegalHolidaysCalendar.ShouldNotBeNull();
    }
}