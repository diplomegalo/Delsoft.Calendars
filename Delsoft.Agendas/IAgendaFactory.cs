namespace Delsoft.Agendas;

public interface IAgendaFactory<TAgenda>
    where TAgenda : IAgenda
{
    TAgenda Create(int? year = null);
}