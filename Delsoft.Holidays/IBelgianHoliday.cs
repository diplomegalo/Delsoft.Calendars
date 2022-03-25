namespace Delsoft.Holiday;

public interface IBelgianHoliday
{
    DateTime NewYear { get; }
    
    DateTime Easter { get; }
    
    DateTime EasterMonday { get; }

    DateTime LaborDay { get; }
    
    DateTime Ascent { get; }

    DateTime PentecostMonday { get; }
    
    DateTime NationalHoliday { get; }

    DateTime Assumption { get; }
    
    DateTime Toussaint { get; }
    
    DateTime Armistice1918 { get; }

    DateTime Christmas { get; }

    IBelgianHoliday ForYear(int year);
}