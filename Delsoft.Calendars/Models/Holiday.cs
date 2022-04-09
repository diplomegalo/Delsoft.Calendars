namespace Delsoft.Calendars.Models;

public class Holiday
{
    public Holiday(DateTime date, string name, Func<string> localName)
    {
        Name = name;
        Date = date;
        LocalName = localName;
    }

    public string Name { get; }
    public DateTime Date { get; }
    public Func<string> LocalName { get; }
}