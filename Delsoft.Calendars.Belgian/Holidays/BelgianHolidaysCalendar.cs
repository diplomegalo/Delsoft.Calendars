using System.Globalization;
using System.Reflection;
using Delsoft.Calendars.Belgian.Resources;
using Delsoft.Calendars.Holidays;

namespace Delsoft.Calendars.Belgian.Holidays;

public class BelgianHolidaysCalendar : HolidaysCalendar<BelgianHolidaysCalendar>, IBelgianHolidaysCalendar
{
    public Models.Holiday Easter => new(date: this.Easter(), name: GetName(nameof(Easter)),
        localName: Translation.Easter);

    public Models.Holiday EasterMonday => new(date: this.EasterMonday(), name: GetName(nameof(EasterMonday)),
        localName: Translation.EasterMonday);

    public Models.Holiday Ascent => new(date: this.Ascent(), name: GetName(nameof(Ascent)),
        localName: Translation.Ascent);

    public Models.Holiday PentecostMonday => new(date: this.PentecostMonday(), name: GetName(nameof(PentecostMonday)),
        localName: Translation.PentecostMonday);

    public Models.Holiday Assumption => new(date: this.Assumption(), name: GetName(nameof(Assumption)),
        localName: Translation.Assumption);

    public Models.Holiday Toussaint => new(date: this.Toussaint(), name: GetName(nameof(Toussaint)),
        localName: Translation.Toussaint);

    public Models.Holiday Christmas => new(date: this.Christmas(), name: GetName(nameof(Christmas)),
        localName: Translation.Christmas);

    public Models.Holiday NewYear => new(date: this.NewYear(), name: GetName(nameof(NewYear)),
        localName: Translation.NewYear);

    public Models.Holiday LaborDay => new(date: this.LaborDay(), name: GetName(nameof(LaborDay)),
        localName: Translation.LaborDay);

    public Models.Holiday NationalHoliday => new(date: this.NationalHoliday(), name: GetName(nameof(NationalHoliday)),
        localName: Translation.NationalHoliday);
    
    public Models.Holiday Armistice => new(date: this.Armistice1918(), name: GetName(nameof(Armistice)),
        localName: Translation.Armistice);

    public override string[] GetCultures() => new[] { "fr", "nl"};

    public override IEnumerable<Models.Holiday> GetAll() =>
        typeof(IBelgianHolidaysCalendar).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(info => (Models.Holiday)info.GetValue(this)!);

    private static string GetName(string propertyName) =>
        Translation.ResourceManager.GetString(propertyName, CultureInfo.InvariantCulture)
        ?? throw new InvalidOperationException("Cannot set property with null value");
}