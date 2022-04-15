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

public class AgendaFactory<TAgenda> : IAgendaFactory<TAgenda>
    where TAgenda : IAgenda
{
    public TAgenda Create(int? year = null) => AgendaFactory.Create<TAgenda>(year);
}