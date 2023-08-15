using IAE.Entidades.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace IAE.Web.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class TurmaController : ControllerBase
	{
		private readonly ITurmaService _turmaService;

		public TurmaController(ITurmaService turmaService)
		{
			_turmaService = turmaService;
		}

		[HttpGet]
		public ActionResult<List<Turma>> BuscarTurmasPorUsuario(Usuario usuario)
		{
			return _turmaService.BuscarTurmasPorUsuario(usuario);
		}

		[HttpPost]
		public ActionResult<Turma> Insert(Turma turma)
		{
			return _turmaService.Insert(turma);
		}

		[HttpPost]
		public ActionResult<int> Insert(IList<Turma> turmas)
		{
			return _turmaService.Insert(turmas);
		}

		[HttpPut]
		public ActionResult<Turma> Update(Turma turma)
		{
			return _turmaService.Update(turma);
		}

		[HttpGet]
		public ActionResult<Turma> GetById(int id)
		{
			return _turmaService.GetById(id);
		}

		[HttpDelete]
		public ActionResult Delete(int id)
		{
			_turmaService.Delete(id);
			return StatusCode((int)HttpStatusCode.NoContent);
		}
	}
}