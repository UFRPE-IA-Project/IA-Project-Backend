using System.Collections.Generic;
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
			throw new NotImplementedException();
		}
	}
}