using IAE.Entities.DTO;
using IAE.Entities.Entities;
using System.Collections.Generic;

namespace IAE.Services.Interfaces
{
    public interface ITurmaService
    {
        List<Turma> BuscarTurmasPorUsuario(Usuario usuario);
        Turma BuscarTurmaPorId(int id);
        void AdicionarTurma(Turma turma);
        Turma? AtualizarTurma(int id, Turma turma);
        void ExcluirTurma(int id);
        List<Turma> ObterTodasTurmas();
        Turma CriarNovaTurmaPeloDto(TurmaDTO dto);
    }
}
