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
        public Avaliacao GerarAvaliacao(int turmaId, int numeroQuestoes, TipoAvaliacao tipoAvaliacao);
		List<Avaliacao> GetAvaliacoesPorIdTurma(int idTurma);
        List<Avaliacao> GetAvaliacoesPorIdProfessor(int idProfessor);
	}

}