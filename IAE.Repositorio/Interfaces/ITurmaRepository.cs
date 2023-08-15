using IAE.Entidades.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repositorio.Interfaces
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        List<Turma> BuscarTurmasPorUsuario(Usuario usuario);
    }
}
