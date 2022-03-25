namespace Delsoft.Holiday;

internal class BelgianHoliday : IBelgianHoliday
{
    private int _year = DateTime.Today.Year;
    
    public static BelgianHoliday Create() => new();

    public DateTime NewYear => new(_year, 1, 1);

    public DateTime Easter
    {
        get
        {
            var year = _year;

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
    }

    public DateTime EasterMonday => Easter.AddDays(1);
    
    public DateTime LaborDay => new(_year, 5, 1);
    
    public DateTime Ascent => Easter.AddDays(39);
    
    public DateTime PentecostMonday => Easter.AddDays(50);
    
    public DateTime NationalHoliday => new(_year, 7, 21);
    
    public DateTime Assumption => new(_year, 8, 15);
    
    public DateTime Toussaint => new(_year, 11, 1);
    
    public DateTime Armistice1918 => new(_year, 11, 11);
    
    public DateTime Christmas => new(_year, 12, 25);

    public IBelgianHoliday ForYear(int year)
    {
        _year = year;
        return this;
    }
}