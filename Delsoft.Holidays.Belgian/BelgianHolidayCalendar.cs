using System.Globalization;
using System.Reflection;
using Delsoft.Holidays.Extensions;
using Delsoft.Holidays.Models;

using Resources = Delsoft.Holidays.Belgian.Resources;

namespace Delsoft.Holidays.Calendars;

public class BelgianHolidayCalendar : HolidayCalendar<BelgianHolidayCalendar>, IBelgianHolidayCalendar
{
    public Holiday Easter => new()
    {
        Date = this.Easter(),
        Name = GetName(nameof(Easter)),
        LocalName = Resources.Translation.Easter
    };

    public Holiday EasterMonday => new()
    {
        Date = this.EasterMonday(),
        Name = GetName(nameof(EasterMonday)),
        LocalName = Resources.Translation.EasterMonday
    };

    public Holiday Ascent => new()
    {
        Date = this.Ascent(),
        Name = GetName(nameof(Ascent)),
        LocalName = Resources.Translation.Ascent,
    };

    public Holiday PentecostMonday => new()
    {
        Date = this.PentecostMonday(),
        Name = GetName(nameof(PentecostMonday)),
        LocalName = Resources.Translation.PentecostMonday
    };

    public Holiday Assumption => new()
    {
        Date = this.Assumption(),
        Name = GetName(nameof(Assumption)),
        LocalName = Resources.Translation.Assumption
    };

    public Holiday Toussaint => new()
    {
        Date = this.Toussaint(),
        Name = GetName(nameof(Toussaint)),
        LocalName = Resources.Translation.Toussaint
    };

    public Holiday Christmas => new()
    {
        Date = this.Christmas(),
        Name = GetName(nameof(Christmas)),
        LocalName = Resources.Translation.Christmas
    };

    public Holiday NewYear => new()
    {
        Date = this.NewYear(),
        Name = GetName(nameof(NewYear)),
        LocalName = Resources.Translation.NewYear
    };

    public Holiday LaborDay => new()
    {
        Date = this.LaborDay(),
        Name = GetName(nameof(LaborDay)),
        LocalName = Resources.Translation.LaborDay,
    };

    public Holiday NationalHoliday => new()
    {
        Date = this.NationalHoliday(),
        Name = GetName(nameof(NationalHoliday)),
        LocalName = Resources.Translation.NationalHoliday
    };
    
    public Holiday Armistice => new()
    {
        Date = this.Armistice1918(),
        Name = GetName(nameof(Armistice)),
        LocalName = Resources.Translation.Armistice
    };

    public override string[] GetCultures() => new[] { "fr", "nl"};

    public override IEnumerable<Holiday> GetAll() =>
        typeof(IBelgianHolidayCalendar).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Select(info => (Holiday)info.GetValue(this)!);

    private static string GetName(string propertyName) =>
        Resources.Translation.ResourceManager.GetString(propertyName, CultureInfo.InvariantCulture)
        ?? throw new InvalidOperationException("Cannot set property with null value");
}