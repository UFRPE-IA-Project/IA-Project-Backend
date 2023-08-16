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
        void AdicionarQuestao(Questao questao);
        void ApagarQuestao(int id);
        void AtualizarQuestao(Questao questao);
        IList<Questao> ObterQuestoes();
    }

}
