using IAE.Entities.Entities;
using IAE.Entities.Enumarations;

namespace IAE.Services.Interfaces
{
    public interface IAvaliacaoService
    {
      public Avaliacao GerarSimulado(int turmaId);
      public Avaliacao GerarProva(int turmaId);
      List<Avaliacao> BuscarAvaliacoes();
      Avaliacao InserirAvaliacao(Avaliacao avaliacao);
      int InserirAvaliacoes(List<Avaliacao> avaliacoes);
      Avaliacao AtualizarAvaliacao(Avaliacao avaliacao);
      int ExcluirAvaliacao(int id);

    }

}