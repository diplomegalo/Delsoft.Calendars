using Delsoft.Agendas.Calendars;
using Delsoft.Agendas.Models;

namespace Delsoft.Agendas;

public interface IAgenda
{
    int Year { get; }
    abstract string[] GetCultures();
}