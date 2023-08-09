using IAE.Repositorio.Interfaces; // Para acesso ao repositório
using IAE.Entidades.Entities;     // Para acesso às entidades

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
            return _respostaRepository.GetById(id);
        }

        // Adiciona uma nova resposta
        public void AdicionarResposta(Resposta resposta)
        {
            _respostaRepository.Add(resposta);
        }

        // Apaga uma resposta pelo ID
        public void ApagarResposta(int id)
        {
            var resposta = _respostaRepository.GetById(id);
            if (resposta != null)
            {
                _respostaRepository.Delete(resposta);
            }
        }
    }
}
