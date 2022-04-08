using Delsoft.Calendars.Models;

namespace Delsoft.Calendars
{
    public abstract class HolidaysCalendar : IHolidaysCalendar
    {
        public int Year { get; protected init; }

        public abstract string[] GetCultures();

        public abstract IEnumerable<Holiday> GetAll();

        public static T Create<T>(int? year = null) 
            where T : HolidaysCalendar<T>, new() => HolidaysCalendar<T>.Create(year);
    }

    public abstract class HolidaysCalendar<THolidaysCalendar> : HolidaysCalendar
        where THolidaysCalendar : HolidaysCalendar<THolidaysCalendar>, new()
    {
        public static THolidaysCalendar Create(int? year = null) => year == null
            ? HolidayCalendarFactory.Default
            : HolidayCalendarFactory.ForYear(year.Value);
    
        protected HolidaysCalendar() => Year = DateTime.Today.Year;
    
        private static class HolidayCalendarFactory
        {
            public static THolidaysCalendar Default => new();

            public static THolidaysCalendar ForYear(int year) => new() { Year = year };
        }
    
        public IEnumerable<Holiday> Get(params Func<THolidaysCalendar, Holiday>[] args) => args.Select(func => func.Invoke((THolidaysCalendar)this));
    }
}