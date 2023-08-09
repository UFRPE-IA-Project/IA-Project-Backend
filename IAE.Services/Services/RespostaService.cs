using IAE.Services.Interfaces;
using IAE.Repository.Interfaces;
using IAE.Entidades.Entidades;

namespace IAE.Services.Services
{
    public class RespostaService : IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository; // Repositório para acesso às respostas

        // Construtor para injeção de dependência
        public RespostaService(IRespostaRepository respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        // Obtém uma resposta pelo ID
        public Resposta GetResposta(int id)
        {
            return _respostaRepository.FindById(id);
        }

        // Adiciona uma nova resposta
        public void AdicionarResposta(Resposta resposta)
        {
            _respostaRepository.Add(resposta);
        }

        // Apaga uma resposta pelo ID
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
