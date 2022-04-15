namespace Delsoft.Agendas.Models;

public class Event
{
    private readonly Func<string> _localName;

    public Event(DateTime dateStart, string name, Func<string> localName)
    {
        _localName = localName;
        this.Name = name;
        this.DateStart = dateStart;
        this.DateEnd = dateStart;
    }

    public DateTime DateEnd { get; }
    public string Name { get; }
    public DateTime DateStart { get; }
    public string LocalName => _localName();
}