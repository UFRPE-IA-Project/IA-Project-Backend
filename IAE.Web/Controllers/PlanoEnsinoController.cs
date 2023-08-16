using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IAE.Web.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class PlanoEnsinoController : ControllerBase
	{
		private readonly IPlanoEnsinoService _planoEnsinoService;

		public PlanoEnsinoController(IPlanoEnsinoService planoEnsinoService)
		{
			_planoEnsinoService = planoEnsinoService;
		}

		[HttpGet(Name = "PlanoEnsino")]
		public PlanoEnsino GetPlanoEnsino(int idPlanoEnsino)
		{
			var planoEnsino = _planoEnsinoService.GetPlanoEnsino(idPlanoEnsino);

			ArgumentNullException.ThrowIfNull(planoEnsino);

			return planoEnsino;
		}

		[HttpGet]
		public List<PlanoEnsino> ObterTodosPlanoEnsinos()
		{
			var planoEnsinos = _planoEnsinoService.ObterTodosPlanosEnsino();

			ArgumentNullException.ThrowIfNull(planoEnsinos);

			return planoEnsinos;
		}

		[HttpGet]
		public List<PlanoEnsino> GetPlanoEnsinos(List<int> idsPlanoEnsinos)
		{
			var planoEnsinos = _planoEnsinoService.GetPlanosEnsino(idsPlanoEnsinos);

			ArgumentNullException.ThrowIfNull(planoEnsinos);

			return planoEnsinos;
		}

		[HttpPost]
		public ActionResult AtualizarPlanoEnsino(int idPlanoEnsino, PlanoEnsinoDTO planoEnsinoAtualizado)
		{
			var planoEnsino = _planoEnsinoService.AtualizarPlanoEnsino(idPlanoEnsino, planoEnsinoAtualizado);

			ArgumentNullException.ThrowIfNull(planoEnsino);

			return Ok(planoEnsino);
		}

		[HttpPost]
		public ActionResult AdicionarPlanoEnsino(PlanoEnsinoDTO planoEnsino)
		{
			var planoEnsinoDb = _planoEnsinoService.CriarPlanoEnsino(planoEnsino);

			ArgumentNullException.ThrowIfNull(planoEnsinoDb);

			return Ok(planoEnsinoDb);
		}

		[HttpDelete]
		public ActionResult ExcluirPlanoEnsino(int idPlanoEnsino)
		{
			_planoEnsinoService.ExcluirPlanoEnsino(idPlanoEnsino);

			return Content("Plano de Ensino excluído com sucesso.");
		}
	}
}
