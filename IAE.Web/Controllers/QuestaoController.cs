using IAE.Entidades.Entidades;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
		[SwaggerOperation(Summary = "Obter uma questão")]
		[SwaggerResponse(200)]
		[SwaggerResponse(400, "Id fornecido inválido")]
		public Questao ObterQuestao(int id)
		{
			var questao = _questaoService.ObterQuestao(id);
			return questao;
		}

		// POST: Questao/AdicionarQuestao
		[HttpPost]
		[SwaggerOperation(Summary = "Adicionar uma questão")]
		[SwaggerResponse(200, "Questão adicionada.", typeof(Questao))]
		[SwaggerResponse(400, "Dado fornacido inválido")]
		public ActionResult AdicionarQuestao(Questao questao)
		{
			_questaoService.AdicionarQuestao(questao);
			return Ok(questao);
		}

		// POST: Questao/ApagarQuestao/5
		[HttpPost]
		[SwaggerOperation(Summary = "Apaga uma questão apartir do id fornecido")]
		[SwaggerResponse(200, "Questão {idQuestao} apagada com sucesso.", typeof(Questao))]
		[SwaggerResponse(400, "Id fornecido inválido")]
		public ActionResult ApagarQuestao(int id)
		{
			_questaoService.ApagarQuestao(id);
			return Content($"Questão #{id} apagada com sucesso.");
		}
        // GET: Questao/ListarQuestoes
        [HttpGet(Name = "Questoes")]
        [SwaggerOperation(Summary = "Listar todas as questões")]
        [SwaggerResponse(200, "Lista de questões.", typeof(IEnumerable<Questao>))]
        public ActionResult<IEnumerable<Questao>> ListarQuestoes()
        {
            var questoes = _questaoService.ListarQuestoes();
            return Ok(questoes);
        }

        // PUT: Questao/AtualizarQuestao
        [HttpPut]
        [SwaggerOperation(Summary = "Atualizar uma questão existente")]
        [SwaggerResponse(200, "Questão atualizada.", typeof(Questao))]
        [SwaggerResponse(400, "Dados fornecidos inválidos")]
        public ActionResult AtualizarQuestao(Questao questao)
        {
            _questaoService.AtualizarQuestao(questao);
            return Ok(questao);
        }
    }
}