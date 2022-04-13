using Microsoft.Extensions.DependencyInjection;

namespace Delsoft.Calendars.Belgian.Controllers;

public static class MvcBuilderExtension
{
    public static IMvcBuilder AddBelgianCalendarController(this IMvcBuilder builder)
    {
        builder
            .AddApplicationPart(typeof(BelgianCalendarController).Assembly)
            .Services.AddScoped<ICalendarFactory<IBelgianCalendar>, CalendarFactory<IBelgianCalendar>>();

        return builder;
    }
}