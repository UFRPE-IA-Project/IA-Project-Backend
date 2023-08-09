using IAE.Entidades.Entities; // Para acesso às entidades

namespace IAE.Services.Interfaces
{
    public interface IRespostaService
    {
        // Obtém uma resposta pelo ID
        Resposta GetResposta(int id);

        // Adiciona uma nova resposta
        void AdicionarResposta(Resposta resposta);

        // Apaga uma resposta pelo ID
        void ApagarResposta(int id);
    }
}
