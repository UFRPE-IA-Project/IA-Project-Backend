using IAE.Entities.Entities;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;

namespace IAE.Services.Services
{
	public interface IAvaliacaoRepository : IBaseRepository<Avaliacao>
	{
		List<Avaliacao> GetAvaliacoesPorIdProfessor(int idProfessor);
		List<Avaliacao> GetAvaliacoesPorIdTurma(int idTurma);
	}
}