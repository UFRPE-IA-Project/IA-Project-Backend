using IAE.Entidades.Entidades;
using IAE.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repositorio.Repositories
{
    public class TurmaRepository : BaseRepository<Turma>, ITurmaRepository
    {
        public List<Turma> BuscarTurmasPorUsuario(Usuario usuario)
        {
            // Lógica para buscar turmas do usuário no banco de dados
            // Exemplo:
            // return _context.Turmas.Where(t => t.UsuarioId == usuario.Id).ToList();
        }
    }
}
