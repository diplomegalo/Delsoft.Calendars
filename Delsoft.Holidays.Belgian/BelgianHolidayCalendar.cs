using System.Globalization;
using System.Reflection;
using Delsoft.Holidays.Extensions;

using Resources = Delsoft.Holidays.Belgian.Resources;

namespace Delsoft.Holidays.Calendars;

public class BelgianHolidayCalendar : HolidayCalendar<BelgianHolidayCalendar>, IBelgianHolidayCalendar
{
    public Models.Holiday Easter => new(date: this.Easter(), name: GetName(nameof(Easter)),
        localName: Resources.Translation.Easter);

    public Models.Holiday EasterMonday => new(date: this.EasterMonday(), name: GetName(nameof(EasterMonday)),
        localName: Resources.Translation.EasterMonday);

    public Models.Holiday Ascent => new(date: this.Ascent(), name: GetName(nameof(Ascent)),
        localName: Resources.Translation.Ascent);

    public Models.Holiday PentecostMonday => new(date: this.PentecostMonday(), name: GetName(nameof(PentecostMonday)),
        localName: Resources.Translation.PentecostMonday);

    public Models.Holiday Assumption => new(date: this.Assumption(), name: GetName(nameof(Assumption)),
        localName: Resources.Translation.Assumption);

    public Models.Holiday Toussaint => new(date: this.Toussaint(), name: GetName(nameof(Toussaint)),
        localName: Resources.Translation.Toussaint);

    public Models.Holiday Christmas => new(date: this.Christmas(), name: GetName(nameof(Christmas)),
        localName: Resources.Translation.Christmas);

    public Models.Holiday NewYear => new(date: this.NewYear(), name: GetName(nameof(NewYear)),
        localName: Resources.Translation.NewYear);

    public Models.Holiday LaborDay => new(date: this.LaborDay(), name: GetName(nameof(LaborDay)),
        localName: Resources.Translation.LaborDay);

    public Models.Holiday NationalHoliday => new(date: this.NationalHoliday(), name: GetName(nameof(NationalHoliday)),
        localName: Resources.Translation.NationalHoliday);
    
    public Models.Holiday Armistice => new(date: this.Armistice1918(), name: GetName(nameof(Armistice)),
        localName: Resources.Translation.Armistice);

    public override string[] GetCultures() => new[] { "fr", "nl"};

    public override IEnumerable<Models.Holiday> GetAll() =>
        typeof(IBelgianHolidayCalendar).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(info => (Models.Holiday)info.GetValue(this)!);

    private static string GetName(string propertyName) =>
        Resources.Translation.ResourceManager.GetString(propertyName, CultureInfo.InvariantCulture)
        ?? throw new InvalidOperationException("Cannot set property with null value");
}