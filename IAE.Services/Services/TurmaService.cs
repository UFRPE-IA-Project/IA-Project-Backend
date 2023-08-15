using System.Collections.Generic;
using IAE.Entidades.Entities;
using IAE.Repositorio.Interfaces;
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

        public Turma Insert(Turma turma)
        {
            return _turmaRepository.Insert(turma);
        }

        public int Insert(IList<Turma> turmas)
        {
            return _turmaRepository.Insert(turmas);
        }

        public Turma Update(Turma turma)
        {
            return _turmaRepository.Update(turma);
        }

        public Turma GetById(int id)
        {
            return _turmaRepository.GetById(id);
        }

        public void Delete(int id)
        {
            _turmaRepository.Delete(id);
        }
	}
}