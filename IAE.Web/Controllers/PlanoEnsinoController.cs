using IAE.Entities.DTO;
using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IAE.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PlanoEnsinoController : ControllerBase
	{
		private readonly IPlanoEnsinoService _planoEnsinoService;

		public PlanoEnsinoController(IPlanoEnsinoService planoEnsinoService)
		{
			_planoEnsinoService = planoEnsinoService;
		}

		[HttpGet("{id}")]
		public ActionResult<PlanoEnsino> GetPlanoEnsino(int idPlanoEnsino)
		{
			var planoEnsino = _planoEnsinoService.GetPlanoEnsino(idPlanoEnsino);

			ArgumentNullException.ThrowIfNull(planoEnsino);

			return Ok(planoEnsino);
		}

		[HttpGet]
		public ActionResult<List<PlanoEnsino>> ObterTodosPlanoEnsinos()
		{
			var planoEnsinos = _planoEnsinoService.ObterTodosPlanosEnsino();

			ArgumentNullException.ThrowIfNull(planoEnsinos);

			return Ok(planoEnsinos);
		}

		[HttpPut("{id}")]
		public ActionResult<PlanoEnsino> AtualizarPlanoEnsino(int idPlanoEnsino, PlanoEnsinoDTO planoEnsinoAtualizado)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var planoEnsino = _planoEnsinoService.AtualizarPlanoEnsino(idPlanoEnsino, planoEnsinoAtualizado);

			ArgumentNullException.ThrowIfNull(planoEnsino);

			return Ok(planoEnsino);
		}

		[HttpPost]
		public ActionResult<PlanoEnsino> AdicionarPlanoEnsino(PlanoEnsinoDTO planoEnsino)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var planoEnsinoDb = _planoEnsinoService.CriarPlanoEnsino(planoEnsino);

			ArgumentNullException.ThrowIfNull(planoEnsinoDb);

			return Ok(planoEnsinoDb);
		}

		[HttpPost("ObtePorIds")]
		public ActionResult<List<PlanoEnsino>> GetPlanoEnsinos(List<int> idsPlanoEnsinos)
		{
			var planoEnsinos = _planoEnsinoService.GetPlanosEnsino(idsPlanoEnsinos);

			ArgumentNullException.ThrowIfNull(planoEnsinos);

			return Ok(planoEnsinos);
		}

		[HttpDelete("{id}")]
		public ActionResult ExcluirPlanoEnsino(int idPlanoEnsino)
		{
			_planoEnsinoService.ExcluirPlanoEnsino(idPlanoEnsino);
			return Content("Plano de Ensino excluído com sucesso.");
		}
	}
}
