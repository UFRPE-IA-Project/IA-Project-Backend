using System.Collections.Generic;
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
    }
}