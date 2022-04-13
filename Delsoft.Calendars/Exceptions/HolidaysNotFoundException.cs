namespace Delsoft.Calendars.Exceptions;

public class HolidaysNotFoundException : ApplicationException
{
    public HolidaysNotFoundException(string holidaysName)
        : base($"Unable to found {holidaysName} holidays.")
    {
    }
}