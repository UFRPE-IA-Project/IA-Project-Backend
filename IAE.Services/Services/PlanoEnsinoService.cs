using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Repository.Interfaces;
using IAE.Services.Interfaces;

namespace IAE.Services.Services
{
	public class PlanoEnsinoService : IPlanoEnsinoService
	{
		private readonly IPlanoEnsinoRepository _planoEnsinoRepository;

		public PlanoEnsinoService(IPlanoEnsinoRepository planoEnsinoRepository)
		{
			_planoEnsinoRepository = planoEnsinoRepository;

		}

		public PlanoEnsino CriarPlanoEnsino(PlanoEnsinoDTO dto)
		{
			var planoEnsino = CriarNovoPlanoEnsinoPeloDto(dto);

			var planoEnsinoDb = _planoEnsinoRepository.Insert(planoEnsino);

			if (dto.ReferenciasBibliograficas?.Any() == true || dto.TopicosAbordados?.Any() == true)
			{
				AdicionarReferenciasETopicos(dto);

				//Atualizar as listas do plano de ensino
				planoEnsinoDb = _planoEnsinoRepository.FindById(planoEnsinoDb.Id!.Value);
			}

			return planoEnsinoDb;
		}

		public void CriarMultiplosPlanosEnsino(List<PlanoEnsinoDTO> dtos)
		{
			var planosEnsino = new List<PlanoEnsino>();

			dtos.ForEach(d =>
			{
				planosEnsino.Add(CriarNovoPlanoEnsinoPeloDto(d));
			});

			var linhasAfetadas = _planoEnsinoRepository.Insert(planosEnsino);
			if (linhasAfetadas < 1)
			{
				throw new Exception("Houve algum problema com a inserção dos planos de ensino.");
			}
		}

		public PlanoEnsino GetPlanoEnsino(int id)
		{
			var PlanoEnsino = _planoEnsinoRepository.FindById(id);

			return PlanoEnsino;
		}

		public List<PlanoEnsino> GetPlanosEnsino(List<int> ids)
		{
			var PlanosEnsino = _planoEnsinoRepository.FindByIds(ids);

			return PlanosEnsino.ToList();
		}

		public List<PlanoEnsino> ObterTodosPlanosEnsino()
		{
			var PlanosEnsino = _planoEnsinoRepository.FindAll();

			return PlanosEnsino.ToList();
		}

		public PlanoEnsino AtualizarPlanoEnsino(int idPlano, PlanoEnsinoDTO dto)
		{
			var planoEnsino = _planoEnsinoRepository.FindById(idPlano);

			planoEnsino.Nome = dto.Nome;
			planoEnsino.NomeDisciplina = dto.NomeDisciplina;
			planoEnsino.Escolaridade = dto.Escolaridade;
			planoEnsino.CargaHoraria = dto.CargaHoraria;

			var planoEnsinoDb = _planoEnsinoRepository.Update(planoEnsino);

			return planoEnsinoDb;
		}

		public void ExcluirPlanoEnsino(int id)
		{
			var linhasExcluidas = _planoEnsinoRepository.Delete(id);

			if (linhasExcluidas < 1)
			{
				throw new ArgumentException("O plano de ensino não existe no banco de dados.");
			}
		}

		private PlanoEnsino CriarNovoPlanoEnsinoPeloDto(PlanoEnsinoDTO dto)
		{
			return new PlanoEnsino
			{
				Nome = dto.Nome,
				NomeDisciplina = dto.NomeDisciplina,
				Escolaridade = dto.Escolaridade,
				CargaHoraria = dto.CargaHoraria
			};
		}

		private void AdicionarReferenciasETopicos(PlanoEnsinoDTO dto)
		{
			if (dto.ReferenciasBibliograficas?.Any() == true)
			{
				//TODO: Chamar método de adicionar referencias bibliograficas
			}

			if (dto.TopicosAbordados?.Any() == true)
			{
				//TODO: Chamar método de adicionar topicos abordados.
			}
		}
	}
}
