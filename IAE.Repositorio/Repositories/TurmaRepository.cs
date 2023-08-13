using IAE.Entities.Entities;
using IAE.Repository.Interfaces;

namespace IAE.Repository.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public List<Turma> BuscarTurmasPorUsuario(Usuario usuario)
        {
           throw new NotImplementedException();
        }
    }
}
