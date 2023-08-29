using System.Collections.Generic;
using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;

namespace IAE.Services.Services
{
	public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaService(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

		public List<Turma> BuscarTurmasPorUsuario(Usuario usuario)
		{
            return _turmaRepository.BuscarTurmasPorUsuario(usuario);
        }
        public Turma BuscarTurmaPorId(int id)
        {
            return _turmaRepository.FindById(id);
        }
        public void AdicionarTurma(Turma turma)
        {
            _turmaRepository.Insert(turma);
        }
        public Turma? AtualizarTurma(int id, Turma turma)
        {
			var existingTurma = BuscarTurmaPorId(id);
            ArgumentNullException.ThrowIfNull(existingTurma);

			turma.Id = id;

			var turmaAtualizada = _turmaRepository.Update(turma);

            return turmaAtualizada;
        }
        public void ExcluirTurma(int id)
        {
            _turmaRepository.Delete(id);
        }
        public List<Turma> ObterTodasTurmas()
        {
            return _turmaRepository.FindAll().ToList();
        }

        public Turma CriarNovaTurmaPeloDto(TurmaDTO dto)
        {
            var novaTurma = new Turma()
            {
                CodigoTurma = dto.CodigoTurma,
                IdPlanoEnsino = dto.PlanoEnsinoId,
                IdProfessor = dto.ProfessorId

            };

            return novaTurma;
        }

    }
}