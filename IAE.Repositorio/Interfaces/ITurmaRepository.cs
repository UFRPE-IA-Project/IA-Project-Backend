using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Interfaces
{
    public interface ITurmaRepository
    {
        List<Turma> BuscarTurmasPorUsuario(Usuario usuario);
    }
}
