using System;
using System.Globalization;
using Delsoft.Calendars.Holidays;
using Delsoft.Calendars.Test.Resources;

namespace Delsoft.Calendars.Test.Stubs;

internal class HolidaysCalendarStub : HolidaysCalendar<HolidaysCalendarStub>, IHolidaysCalendarStub
{
    public static DateTime Holiday1Date = DateTime.Today.AddDays(1);
    public static DateTime Holiday2Date = DateTime.Today;

    public HolidaysCalendarStub()
    {
    }

    public HolidaysCalendarStub(int year) => Year = year;

    public Models.Holiday Holiday1 => new(date:
        Holiday1Date, name:
        Translation.ResourceManager.GetString(nameof(Holiday1), CultureInfo.InvariantCulture)
            ?? throw new InvalidOperationException($"Cannot find translation for {nameof(Holiday1)}"), localName:
        () => Resources.Translation.Holiday1);

    public Models.Holiday Holiday2 => new(date:
        Holiday2Date, name:
        Translation.ResourceManager.GetString(nameof(Holiday2), CultureInfo.InvariantCulture)
            ?? throw new InvalidOperationException($"Cannot find translation for {nameof(Holiday1)}"), localName:
        () => Resources.Translation.Holiday2);

    public override string[] GetCultures() => Array.Empty<string>();
}