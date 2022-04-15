namespace Delsoft.Agendas.Models;

public class Event
{
    private readonly Func<string> _localName;

    public Event(DateTime dateStart, string name, Func<string> localName)
        : this((dateStart, dateStart), name, localName) { }

    public Event((DateTime, DateTime) period, string name, Func<string> localName)
    {
        _localName = localName;
        this.Name = name;
        var (startDate, endDate) = period;
        this.StartDate = startDate;
        this.EndDate = endDate;
    }

    public DateTime EndDate { get; }
    public string Name { get; }
    public DateTime StartDate { get; }
    public string LocalName => _localName();
}