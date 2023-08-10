﻿using IAE.Entidades.Entidades;
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
		[SwaggerOperation(Summary = "Obter uma uma questão")]
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
	}
}
