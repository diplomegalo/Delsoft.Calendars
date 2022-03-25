namespace Delsoft.Holiday;

internal class BelgianHoliday : IBelgianHoliday
{
    public Calendar Calendar { get; }

    private int Year => Calendar.Year;

    private BelgianHoliday()
    {
        Calendar = new Calendar();
    }
    
    private BelgianHoliday(Calendar calendar)
    {
        Calendar = calendar;
    }

    public static BelgianHoliday Create(Calendar calendar) => new BelgianHoliday(calendar);

    public DateTime NewYear => new(Year, 1, 1);

    public DateTime Easter
    {
        get
        {
            var year = Year;

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
    
    public DateTime LaborDay => new(Year, 5, 1);
    
    public DateTime Ascent => Easter.AddDays(39);
    
    public DateTime PentecostMonday => Easter.AddDays(50);
    
    public DateTime NationalHoliday => new(Year, 7, 21);
    
    public DateTime Assumption => new(Year, 8, 15);
    
    public DateTime Toussaint => new(Year, 11, 1);
    
    public DateTime Armistice1918 => new(Year, 11, 11);
    
    public DateTime Christmas => new(Year, 12, 25);
}