using System.Reflection;
using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Models;

namespace Delsoft.Agendas;

public static class AgendaExtension
{
    public static IEnumerable<Event> GetAll<TAgenda, TCalendar>(this TAgenda agenda, Func<TAgenda, TCalendar> calendarProperty)
        where TCalendar: ICustomCalendar
        where TAgenda: IAgenda
    {
        var calendar = calendarProperty.Invoke(agenda);
        return typeof(TCalendar).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(info => info.PropertyType == typeof(Event))
            .Select(info => (Event)info.GetValue(calendar)!);
    }
}

public abstract class Agenda : IAgenda
{
    public int Year { get; }
    public abstract string[] GetCultures();
    protected Agenda(int? year = null) => this.Year = year ?? DateTime.Today.Year;
}