namespace Delsoft.Agendas.Exceptions;

public class EventNotFoundException : ApplicationException
{
    public EventNotFoundException(string eventName)
        : base($"Unable to found the {eventName} event.")
    {
    }
}