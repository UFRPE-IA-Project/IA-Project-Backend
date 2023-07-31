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
		Questao GetQuestao(int id);
		void AdicionarQuestao(Questao questao);
		void ApagarQuestao(int id);
	}
}
