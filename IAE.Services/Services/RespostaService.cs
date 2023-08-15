using IAE.Services.Interfaces;
using IAE.Repositorio.Interfaces;
using IAE.Entidades.Entidades;

namespace IAE.Services.Services
{
    public class RespostaService : IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository;

        public RespostaService(IRespostaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public Resposta GetResposta(int id)
        {
            return _respostaRepository.FindById(id);
        }

        public void AdicionarResposta(Resposta resposta)
        {
            _respostaRepository.Insert(resposta);
        }

        public void ApagarResposta(int id)
        {
            var resposta = _respostaRepository.FindById(id);
            if (resposta != null)
            {
                _respostaRepository.Delete(id);
            }
        }
    }
}
