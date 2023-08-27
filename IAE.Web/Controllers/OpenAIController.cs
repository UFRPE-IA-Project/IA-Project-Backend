using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using IAE.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IAE.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OpenAIController : ControllerBase
	{
		private readonly IOpenAiService _openAiService;
		public OpenAIController(IOpenAiService openAiService)
		{
			_openAiService = openAiService;
		}

		[HttpGet("{id}")]
		public ActionResult<string> GetChave(int id)
		{
			var chave = _openAiService.GetChave(id);
			ArgumentNullException.ThrowIfNull(chave);

			return Ok(chave);
		}

		[HttpGet("ObterUltimaChave")]
		public ActionResult<string> GetLastChave()
		{
			var chave = _openAiService.GetLastChave();
			ArgumentNullException.ThrowIfNull(chave);

			return Ok(chave);
		}

		[HttpPut("{id}")]
		public ActionResult<string> UpdateChave(int id, string chave)
		{
			_openAiService.UpdateChave(id, chave);

			return Ok($"Chave atualizada");
		}

		[HttpPost]
		public ActionResult<string> AddChave(string chave)
		{
			_openAiService.AddChave(chave);

			return Ok("Chave adicionada");
		}

		[HttpDelete("{id}")]
		public ActionResult<string> Deletechave(int id)
		{
			_openAiService.DeleteChave(id);

			return Ok("Chave deletada");
		}
	}
}
