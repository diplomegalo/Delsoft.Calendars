namespace Delsoft.Holidays.Models;

public class Holidays
{
    public Holidays(DateTime date, string name, string localName)
    {
        Name = name;
        Date = date;
        LocalName = localName;
    }

    public string Name { get; }
    public DateTime Date { get; }
    public string LocalName { get; }
}