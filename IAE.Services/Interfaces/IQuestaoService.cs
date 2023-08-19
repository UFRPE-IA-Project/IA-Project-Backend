using IAE.Entidades.Entidades;
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
        void ApagarQuestao(int id);
        Questao AtualizarQuestao(int id, Questao questao);
		List<Questao> ObterQuestoesPorQuantidade(int numeroQuestoes);
	}
}
