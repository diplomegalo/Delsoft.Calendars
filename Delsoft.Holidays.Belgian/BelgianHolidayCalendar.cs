using System.Globalization;
using System.Reflection;
using Delsoft.Holidays.Extensions;

using Resources = Delsoft.Holidays.Belgian.Resources;

namespace Delsoft.Holidays.Calendars;

public class BelgianHolidayCalendar : HolidayCalendar<BelgianHolidayCalendar>, IBelgianHolidayCalendar
{
    public Models.Holidays Easter => new(date: this.Easter(), name: GetName(nameof(Easter)),
        localName: Resources.Translation.Easter);

    public Models.Holidays EasterMonday => new(date: this.EasterMonday(), name: GetName(nameof(EasterMonday)),
        localName: Resources.Translation.EasterMonday);

    public Models.Holidays Ascent => new(date: this.Ascent(), name: GetName(nameof(Ascent)),
        localName: Resources.Translation.Ascent);

    public Models.Holidays PentecostMonday => new(date: this.PentecostMonday(), name: GetName(nameof(PentecostMonday)),
        localName: Resources.Translation.PentecostMonday);

    public Models.Holidays Assumption => new(date: this.Assumption(), name: GetName(nameof(Assumption)),
        localName: Resources.Translation.Assumption);

    public Models.Holidays Toussaint => new(date: this.Toussaint(), name: GetName(nameof(Toussaint)),
        localName: Resources.Translation.Toussaint);

    public Models.Holidays Christmas => new(date: this.Christmas(), name: GetName(nameof(Christmas)),
        localName: Resources.Translation.Christmas);

    public Models.Holidays NewYear => new(date: this.NewYear(), name: GetName(nameof(NewYear)),
        localName: Resources.Translation.NewYear);

    public Models.Holidays LaborDay => new(date: this.LaborDay(), name: GetName(nameof(LaborDay)),
        localName: Resources.Translation.LaborDay);

    public Models.Holidays NationalHolidays => new(date: this.NationalHoliday(), name: GetName(nameof(NationalHolidays)),
        localName: Resources.Translation.NationalHoliday);
    
    public Models.Holidays Armistice => new(date: this.Armistice1918(), name: GetName(nameof(Armistice)),
        localName: Resources.Translation.Armistice);

    public override string[] GetCultures() => new[] { "fr", "nl"};

    public override IEnumerable<Models.Holidays> GetAll() =>
        typeof(IBelgianHolidayCalendar).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(info => (Models.Holidays)info.GetValue(this)!);

    private static string GetName(string propertyName) =>
        Resources.Translation.ResourceManager.GetString(propertyName, CultureInfo.InvariantCulture)
        ?? throw new InvalidOperationException("Cannot set property with null value");
}