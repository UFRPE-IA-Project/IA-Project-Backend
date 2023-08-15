using IAE.Entidades.Entities;
using IAE.Entidades.Enumarations;

namespace IAE.Services.Interfaces
{
    public interface IAvaliacaoService
    {
      public Avaliacao GerarSimulado(int turmaId);
      public Avaliacao GerarProva(int turmaId);

    }

}