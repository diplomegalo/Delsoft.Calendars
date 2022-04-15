namespace Delsoft.Agendas;

public interface IAgenda
{
    public int Year { get; }
    public abstract string[] GetCultures();


}