using System.Reflection;
using Delsoft.Calendars.Exceptions;
using Delsoft.Calendars.Models;

namespace Delsoft.Calendars.Holidays;

public abstract class HolidaysCalendar : IHolidaysCalendar
{
    public static class Factory
    {
        public static THolidaysCalendar Create<THolidaysCalendar>(BaseCalendar calendar)
            where THolidaysCalendar : IHolidaysCalendar
        {
            var type = typeof(THolidaysCalendar).IsInterface
                ? typeof(THolidaysCalendar).Assembly.GetTypes().Single(t => typeof(THolidaysCalendar).IsAssignableFrom(t) && !t.IsInterface)
                : typeof(THolidaysCalendar);

            return (THolidaysCalendar)Activator.CreateInstance(type, calendar)!;
        }
    }

    protected HolidaysCalendar(BaseCalendar calendar) => Calendar = calendar ?? throw new ArgumentNullException(nameof(calendar));

    protected BaseCalendar Calendar { get; }

    public int Year => Calendar.Year;

    public virtual string[] GetCultures() => Calendar.GetCultures();
}

public abstract class HolidaysCalendar<THolidaysCalendar> : HolidaysCalendar, IHolidaysCalendar<THolidaysCalendar>
    where THolidaysCalendar: HolidaysCalendar<THolidaysCalendar>
{
    protected HolidaysCalendar(BaseCalendar calendar) : base(calendar)
    {
    }

    public IEnumerable<Holiday> Get(params Func<THolidaysCalendar, Holiday>[] args)
         => args.Select(func => func.Invoke((THolidaysCalendar)this));

    public IEnumerable<Holiday> Get(params string[] args)
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
                    throw new HolidaysNotFoundException(key);
                }
            });
    }

    public IEnumerable<Holiday> GetAll() =>
        typeof(THolidaysCalendar).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(info => info.PropertyType == typeof(Holiday))
            .Select(info => (Models.Holiday)info.GetValue(this)!);
}