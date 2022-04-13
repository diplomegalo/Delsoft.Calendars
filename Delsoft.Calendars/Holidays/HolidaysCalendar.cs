using System.Reflection;
using Delsoft.Calendars.Exceptions;
using Delsoft.Calendars.Models;

namespace Delsoft.Calendars.Holidays;

public abstract class HolidaysCalendar : IHolidaysCalendar
{
    public static class Factory
    {
        public static THolidaysCalendar Create<THolidaysCalendar>(int? year = null)
            where THolidaysCalendar : IHolidaysCalendar
        {
            var type = typeof(THolidaysCalendar);
            if (type.IsInterface)
            {
                type = type.Assembly.GetTypes().Single(t =>
                    typeof(THolidaysCalendar).IsAssignableFrom(t)
                    && !t.IsInterface);
            }

            return year == null
                ? (THolidaysCalendar)Activator.CreateInstance(type)!
                : (THolidaysCalendar)Activator.CreateInstance(type, year)!;
        }
    }

    protected HolidaysCalendar(int? year) => Year = year ?? DateTime.Today.Year;

    public int Year { get; protected init; }

    public abstract string[] GetCultures();
}

public abstract class HolidaysCalendar<THolidaysCalendar> : HolidaysCalendar, IHolidaysCalendar<THolidaysCalendar>
    where THolidaysCalendar: HolidaysCalendar<THolidaysCalendar>
{
    protected HolidaysCalendar(int? year = null) : base(year)
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