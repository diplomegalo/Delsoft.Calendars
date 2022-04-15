namespace Delsoft.Agendas;

public abstract class Agenda
{
    public int Year { get; }
    public abstract string[] GetCultures();

    protected Agenda(int? year = null) => this.Year = year ?? DateTime.Today.Year;
}