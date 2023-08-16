using IAE.Entities.DTO;
using IAE.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Services.Interfaces
{
	public interface IPlanoEnsinoService
	{
		PlanoEnsino AtualizarPlanoEnsino(int idPlano, PlanoEnsinoDTO dto);
		void CriarMultiplosPlanosEnsino(List<PlanoEnsinoDTO> dtos);
		PlanoEnsino CriarPlanoEnsino(PlanoEnsinoDTO dto);
		void ExcluirPlanoEnsino(int id);
		PlanoEnsino GetPlanoEnsino(int id);
		List<PlanoEnsino> GetPlanosEnsino(List<int> ids);
		List<PlanoEnsino> ObterTodosPlanosEnsino();
	}
}
