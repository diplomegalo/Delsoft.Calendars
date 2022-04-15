using System.Globalization;
using Delsoft.Agendas.Belgian.Dates;
using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Dates;
using Delsoft.Agendas.Models;
using Delsoft.Calendars.Belgian.Resources;

namespace Delsoft.Agendas.Belgian.Calendars;

public class BelgianHolidayCalendar : CustomCalendar<BelgianHolidayCalendar>, IBelgianHolidayCalendar
{
    public BelgianHolidayCalendar(Agenda agenda)
        : base(agenda)
    {
    }

    public Event Easter => new(dateStart: this.Easter(), name: GetName(nameof(this.Easter)),
        localName: () => Translation.Easter);

    public Event EasterMonday => new(dateStart: this.EasterMonday(), name: GetName(nameof(this.EasterMonday)),
        localName: () => Translation.EasterMonday);

    public Event Ascent => new(dateStart: this.Ascent(), name: GetName(nameof(this.Ascent)),
        localName: () => Translation.Ascent);

    public Event PentecostMonday => new(dateStart: this.PentecostMonday(), name: GetName(nameof(this.PentecostMonday)),
        localName: () => Translation.PentecostMonday);

    public Event Assumption => new(dateStart: this.Assumption(), name: GetName(nameof(this.Assumption)),
        localName: () => Translation.Assumption);

    public Event Toussaint => new(dateStart: this.Toussaint(), name: GetName(nameof(this.Toussaint)),
        localName: () => Translation.Toussaint);

    public Event Christmas => new(dateStart: this.Christmas(), name: GetName(nameof(this.Christmas)),
        localName: () => Translation.Christmas);

    public Event NewYear => new(dateStart: this.NewYear(), name: GetName(nameof(this.NewYear)),
        localName: () => Translation.NewYear);

    public Event LaborDay => new(dateStart: this.LaborDay(), name: GetName(nameof(this.LaborDay)),
        localName: () => Translation.LaborDay);

    public Event NationalHoliday => new(dateStart: this.NationalHoliday(), name: GetName(nameof(this.NationalHoliday)),
        localName: () => Translation.NationalHoliday);

    public Event Armistice => new(dateStart: this.Armistice1918(), name: GetName(nameof(this.Armistice)),
        localName: () => Translation.Armistice);

    public override string[] GetCultures() => new[] { "fr", "nl" };

    private static string GetName(string propertyName) =>
        Translation.ResourceManager.GetString(propertyName, CultureInfo.InvariantCulture)
        ?? throw new InvalidOperationException("Cannot set property with null value");

    public Event FrenchCommunityHoliday => new(
        Agenda.FrenchCommunityHoliday(),
        GetName(nameof(this.FrenchCommunityHoliday)),
        () => Translation.FrenchCommunityHoliday);

    public Event AutumnHoliday => new(
            Agenda.AutumnHoliday(),
            GetName(nameof(this.AutumnHoliday)),
            () => Translation.AutumnHoliday);

    public Event CommemorationOf11November => new(
        Agenda.CommemorationOf11November(),
        GetName(nameof(this.CommemorationOf11November)),
        () => Translation.CommemorationOf11November);
}