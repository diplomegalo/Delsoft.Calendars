using System;
using System.Globalization;
using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Models;
using Delsoft.Calendars.Test.Resources;

namespace Delsoft.Agendas.Test.Stubs;

internal class CustomCalendarStub : CustomCalendar<CustomCalendarStub>, ICustomCalendarStub
{
    public static DateTime Holiday1Date = DateTime.Today.AddDays(1);
    public static DateTime Holiday2Date = DateTime.Today;

    public CustomCalendarStub(Agenda agenda): base(agenda)
    {
    }

    public Event Holiday1 => new(
        Holiday1Date,
        Translation.ResourceManager.GetString(nameof(this.Holiday1), CultureInfo.InvariantCulture)
            ?? throw new InvalidOperationException($"Cannot find translation for {nameof(this.Holiday1)}"),
        () => Delsoft.Calendars.Test.Resources.Translation.Holiday1);

    public Event Holiday2 => new(
        Holiday2Date,
        Translation.ResourceManager.GetString(nameof(this.Holiday2), CultureInfo.InvariantCulture)
            ?? throw new InvalidOperationException($"Cannot find translation for {nameof(this.Holiday1)}"),
        () => Delsoft.Calendars.Test.Resources.Translation.Holiday2);
}