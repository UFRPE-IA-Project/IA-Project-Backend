using IAE.Entidades.Entidades;

namespace IAE.Services.Interfaces
{
    public interface IQuestaoService
    {
        Questao ObterQuestao(int id);
        void AdicionarQuestao(Questao questao);
        void AtualizarQuestao(Questao questao);
        void ApagarQuestao(int id);
    }
}