using IAE.Entities.Entities;
using System.Collections.Generic;

namespace IAE.Services.Interfaces
{
    public interface ITurmaService
    {
        List<Turma> BuscarTurmasPorUsuario(Usuario usuario);
        Turma BuscarTurmaPorId(int id);
        void AdicionarTurma(Turma turma);
        void AtualizarTurma(Turma turma);
        void ExcluirTurma(int id);
        List<Turma> ObterTodasTurmas();
    }
}
