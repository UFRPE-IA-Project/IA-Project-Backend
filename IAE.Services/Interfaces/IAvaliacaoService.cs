using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Entities.Enumarations;

namespace IAE.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Avaliacao GetAvaliacao(int id);
        List<Avaliacao> ObterTodasAvaliacoes();
        void ExcluirAvaliacao(int idAvaliacao);
        Avaliacao AtualizarAvaliacao(int idAvaliacao, AvaliacaoDTO avaliacaoAtualizada);
        public Avaliacao GerarSimulado(int turmaId);
        public Avaliacao GerarProva(int turmaId);

    }

}