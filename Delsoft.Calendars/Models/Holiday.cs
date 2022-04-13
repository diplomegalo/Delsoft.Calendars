namespace Delsoft.Calendars.Models;

public class Holiday
{
    private readonly Func<string> _localName;

    public Holiday(DateTime date, string name, Func<string> localName)
    {
        _localName = localName;
        Name = name;
        Date = date;
    }

    public string Name { get; }
    public DateTime Date { get; }
    public string LocalName => _localName();
}