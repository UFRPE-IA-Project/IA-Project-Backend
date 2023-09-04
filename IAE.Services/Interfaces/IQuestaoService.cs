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
        List<Questao> AdicionarMultiplasQuestoes(List<Questao> questoes);
        void ApagarQuestao(int id);
        Questao AtualizarQuestao(int id, Questao questao);
		List<Questao> ObterQuestoesAleatoriasPorQuantidade(int numeroQuestoes, List<Questao> questoes);
        bool VerificarAlternativaCorreta(int questaoId, int alternativaEscolhida);
        List<Questao> ObterQuestaoPorPlanoEnsino(int idPlanoEnsino);
        List<Questao> EstruturarQuestoes(Questao questoes);
        List<Questao> BuscarQuestoesPorAvaliacao(int idAvaliacao);
    }
}
