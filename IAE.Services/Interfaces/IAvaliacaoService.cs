using IAE.Entities.Entities;
using IAE.Entities.Enumarations;

namespace IAE.Services.Interfaces
{
    public interface IAvaliacaoService
    {
      public Avaliacao GerarSimulado(Turma turma, Professor professor);
      public Avaliacao GerarProva(Turma turma, Professor professor);

    }

}