using Delsoft.Agendas.Models;

namespace Delsoft.Agendas.Calendars;

public interface ICustomCalendar
{
    int Year { get; }

    string[] GetCultures();

}

public interface ICustomCalendar<THolidaysCalendar> : ICustomCalendar
    where THolidaysCalendar : ICustomCalendar<THolidaysCalendar>
{
    IEnumerable<Event> Get(params Func<THolidaysCalendar, Event>[] args);
    IEnumerable<Event> GetAll();
    IEnumerable<Event> Get(params string[] args);
}