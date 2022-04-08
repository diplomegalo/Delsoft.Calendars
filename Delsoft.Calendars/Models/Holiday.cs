namespace Delsoft.Calendars.Models;

public class Holiday
{
    public Holiday(DateTime date, string name, string localName)
    {
        Name = name;
        Date = date;
        LocalName = localName;
    }

    public string Name { get; }
    public DateTime Date { get; }
    public string LocalName { get; }
}