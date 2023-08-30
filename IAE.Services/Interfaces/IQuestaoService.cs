using IAE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Interfaces
{
    public interface IQuestaoService
    {
        Questao ObterQuestao(int id);
        Questao AdicionarQuestao(Questao questao);
        void AdicionarMultiplasQuestoes(Questao questoes);
        void ApagarQuestao(int id);
        Questao AtualizarQuestao(int id, Questao questao);
		List<Questao> ObterQuestoesPorQuantidade(int numeroQuestoes);
        bool VerificarAlternativaCorreta(int questaoId, int alternativaEscolhida);
        List<Questao> ObterQuestaoPorPlanoEnsino(int idPlanoEnsino);
    }
}
