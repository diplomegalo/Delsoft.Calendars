using System.Reflection;
using Delsoft.Agendas.Exceptions;
using Delsoft.Agendas.Models;

namespace Delsoft.Agendas.Calendars;

public abstract class CustomCalendar : ICustomCalendar
{
    public static class Factory
    {
        public static THolidaysCalendar Create<THolidaysCalendar>(Agenda agenda)
            where THolidaysCalendar : CustomCalendar
        {
            var type = typeof(THolidaysCalendar).IsInterface
                ? typeof(THolidaysCalendar).Assembly.GetTypes().Single(t => typeof(THolidaysCalendar).IsAssignableFrom(t) && !t.IsInterface)
                : typeof(THolidaysCalendar);

            return (THolidaysCalendar)Activator.CreateInstance(type, agenda)!;
        }
    }

    protected CustomCalendar(Agenda agenda) => this.Agenda = agenda ?? throw new ArgumentNullException(nameof(agenda));

    protected Agenda Agenda { get; }

    public int Year => this.Agenda.Year;

    public virtual string[] GetCultures() => this.Agenda.GetCultures();
}

public abstract class CustomCalendar<THolidaysCalendar> : CustomCalendar, ICustomCalendar<THolidaysCalendar>
    where THolidaysCalendar: CustomCalendar<THolidaysCalendar>
{
    protected CustomCalendar(Agenda agenda) : base(agenda)
    {
    }

    public IEnumerable<Event> Get(params Func<THolidaysCalendar, Event>[] args)
         => args.Select(func => func.Invoke((THolidaysCalendar)this));

    public IEnumerable<Event> Get(params string[] args)
    {
            var all = this.GetAll().ToDictionary(holiday => holiday.Name.ToLower(), holiday => holiday);
            return args.Select(key =>
            {
                try
                {
                    return all[key.ToLower()];
                }
                catch (KeyNotFoundException)
                {
                    throw new EventsNotFoundException(key);
                }
            });
    }

    public IEnumerable<Event> GetAll() =>
        typeof(THolidaysCalendar).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(info => info.PropertyType == typeof(Event))
            .Select(info => (Event)info.GetValue(this)!);
}