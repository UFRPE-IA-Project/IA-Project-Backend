using System.Collections.Generic;

namespace IAE.Services.Interfaces
{
    public interface ITurmaService
    {
        List<Turma> BuscarTurmasPorUsuario(Usuario usuario);
    }
}
