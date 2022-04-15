using Delsoft.Calendars.Belgian;
using Microsoft.Extensions.DependencyInjection;

namespace Delsoft.Agendas.Belgian.Controllers;

public static class MvcBuilderExtension
{
    public static IMvcBuilder AddBelgianAgendaController(this IMvcBuilder builder)
    {
        builder
            .AddApplicationPart(typeof(BelgianCalendarController).Assembly)
            .Services.AddScoped<IAgendaFactory<IBelgianAgenda>, AgendaFactory<IBelgianAgenda>>();

        return builder;
    }
}