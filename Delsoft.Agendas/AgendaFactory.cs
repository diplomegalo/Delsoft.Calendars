namespace Delsoft.Agendas;

public class AgendaFactory
{
    public static TCalendar Create<TCalendar>(int? year = null)
        where TCalendar : IAgenda
    {
        var type = typeof(TCalendar).IsInterface
            ? typeof(TCalendar).Assembly.GetTypes().Single(t => typeof(TCalendar).IsAssignableFrom(t) && !t.IsInterface)
            : typeof(TCalendar);

        return (TCalendar)Activator.CreateInstance(type, year)!;
    }
}

public class AgendaFactory<TCalendar> : IAgendaFactory<TCalendar>
    where TCalendar : IAgenda
{
    public TCalendar Create(int? year = null) => AgendaFactory.Create<TCalendar>(year);
}