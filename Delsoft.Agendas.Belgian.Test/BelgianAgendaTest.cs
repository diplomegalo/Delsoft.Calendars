using Shouldly;
using Xunit;

namespace Delsoft.Agendas.Belgian.Test;

public class BelgianAgendaTest
{
    [Fact]
    public void Can_Create_Belgian_Agenda()
    {
        // Arrange

        // Act
        var agenda = AgendaFactory.Create<BelgianAgenda>();

        // Assert
        agenda.ShouldNotBeNull();
        agenda.LegalHolidaysCalendar.ShouldNotBeNull();
        agenda.GetCultures().ShouldContain("fr");
        agenda.GetCultures().ShouldContain("nl");
    }
}