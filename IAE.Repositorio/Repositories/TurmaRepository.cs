using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace IAE.Repository.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
		public TurmaRepository(IConfiguration config) : base(config)
		{
		}

		public List<Turma> BuscarTurmasPorUsuario(Usuario usuario)
        {
           throw new NotImplementedException();
        }

		public override Turma Insert(Turma item)
		{
			throw new NotImplementedException();
		}

		public override int Insert(IList<Turma> items)
		{
			throw new NotImplementedException();
		}

		public override Turma Update(Turma item)
		{
			throw new NotImplementedException();
		}
	}
}
