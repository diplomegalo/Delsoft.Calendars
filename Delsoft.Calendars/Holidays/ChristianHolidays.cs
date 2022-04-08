using Delsoft.Calendars;

namespace Delsoft.Calendars.Extensions;

public static partial class HolidaysExtension
{
    public static DateTime Easter(this HolidaysCalendar holidaysCalendar)
    {
        var year = holidaysCalendar.Year;

        // Cycle de méton
        var n = year % 19;

        // Centaine et rang de l'année
        var c = year / 100;
        var u = year % 100;

        // Siècle bissextile
        var s = c / 4;
        var t = c % 4;

        // Cycle de proemptose
        var p = (c + 8) / 25;

        // proemptose
        var q = (c - p + 1) / 3;

        // epacte
        var e = ((19 * n) + c - s - q + 15) % 30;

        // année bisextile
        var b = u / 4;
        var d = u % 4;

        // lettre dominicale
        var L = ((2 * t) + (2 * b) - e - d + 32) % 7;

        // correction
        var h = (n + (11 * e) + (22 * L)) / 451;

        // resultat
        var mois = (e + L - (7 * h) + 114) / 31;
        var jours = (e + L - (7 * h) + 114) % 31; // zero based

        return new DateTime(year, mois, jours + 1);
    }
    public static DateTime EasterMonday(this HolidaysCalendar holidaysCalendar) => holidaysCalendar.Easter().AddDays(1);
    public static DateTime Ascent(this HolidaysCalendar holidaysCalendar) => holidaysCalendar.Easter().AddDays(39);
    public static DateTime PentecostMonday(this HolidaysCalendar holidaysCalendar) => holidaysCalendar.Easter().AddDays(50);
    public static DateTime Assumption(this HolidaysCalendar holidaysCalendar) => new(holidaysCalendar.Year, 8, 15);
    public static DateTime Toussaint(this HolidaysCalendar holidaysCalendar) => new(holidaysCalendar.Year, 11, 1);
    public static DateTime Christmas(this HolidaysCalendar holidaysCalendar) => new(holidaysCalendar.Year, 12, 25);
}