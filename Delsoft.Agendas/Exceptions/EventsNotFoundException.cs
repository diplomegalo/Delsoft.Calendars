namespace Delsoft.Agendas.Exceptions;

public class EventsNotFoundException : ApplicationException
{
    public EventsNotFoundException(string holidaysName)
        : base($"Unable to found {holidaysName} holidays.")
    {
    }
}