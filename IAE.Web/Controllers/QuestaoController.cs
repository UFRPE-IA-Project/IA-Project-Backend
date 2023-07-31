using IAE.Entidades.Entidades;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IAE.Web.Controllers
{
	[ApiController]
	[Route("[controller]/[action]")]
	public class QuestaoController : ControllerBase
	{
		private readonly IQuestaoService _questaoService;

		public QuestaoController(IQuestaoService questaoService)
		{
			_questaoService = questaoService;
		}


		// GET: Questao/GetQuestao/[id]
		[HttpGet(Name = "Questao")]
		public Questao GetQuestao(int id)
		{
			var questao = _questaoService.GetQuestao(id);

			return questao;
		}

		// POST: Questao/AdicionarQuestao
		[HttpPost]
		public ActionResult AdicionarQuestao(Questao questao)
		{
			_questaoService.AdicionarQuestao(questao);

			return Ok(questao);
		}

		// POST: Questao/ApagarQuestao/5
		[HttpPost]
		public ActionResult ApagarQuestao(int id)
		{
			_questaoService.ApagarQuestao(id);

			return Content($"Questão #{id} apagada com sucesso.");
		}
	}
}
