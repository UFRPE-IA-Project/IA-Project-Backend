using System.Collections.Generic;
using System.Linq;
using IAE.Repositorio.Interfaces;

namespace IAE.Repositorio.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        public List<Turma> BuscarTurmasPorUsuario(Usuario usuario)
        {
            // Lógica para buscar turmas do usuário no banco de dados
            // Exemplo:
            // return _context.Turmas.Where(t => t.UsuarioId == usuario.Id).ToList();
        }
    }
}
