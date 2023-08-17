using IAE.Entities.Entities;
using IAE.Entities.Enumarations;

public interface IAvaliacaoService
{
    public Avaliacao GerarSimulado(int turmaId);
    public Avaliacao GerarProva(int turmaId);
}