using IAE.Entities.Entities;
using IAE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace IAE.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestaoController : ControllerBase
    {
        private readonly IQuestaoService _questaoService;

        public QuestaoController(IQuestaoService questaoService)
        {
            _questaoService = questaoService;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obter uma questão")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, "Id fornecido inválido")]
        public ActionResult<Questao> ObterQuestao(int id)
        {
            var questao = _questaoService.ObterQuestao(id);
            return Ok(questao);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adicionar uma questão")]
        [SwaggerResponse(200, "Questão adicionada.", typeof(Questao))]
        [SwaggerResponse(400, "Dado fornecido inválido")]
        public ActionResult<Questao> AdicionarQuestao(Questao questao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _questaoService.AdicionarQuestao(questao);

            return Ok(questao);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualizar uma questão")]
        [SwaggerResponse(200, "Questão atualizada.", typeof(Questao))]
        [SwaggerResponse(400, "Dado fornecido inválido")]
        public ActionResult<Questao> AtualizarQuestao(int id, Questao questao)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var questaoAtualizada = _questaoService.AtualizarQuestao(id, questao);

            return Ok(questaoAtualizada);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Apagar uma questão a partir do id fornecido")]
        [SwaggerResponse(200, "Questão {idQuestao} apagada com sucesso.", typeof(Questao))]
        [SwaggerResponse(400, "Id fornecido inválido")]
        public ActionResult ApagarQuestao(int id)
        {
            var questao = _questaoService.ObterQuestao(id);

            if (questao is null)
            {
                return BadRequest();
            }

            _questaoService.ApagarQuestao(id);
            return Ok($"Questão #{id} apagada com sucesso.");
        }

        [HttpPost("{id}/verificar-alternativa")]
        [SwaggerOperation(Summary = "Verificar se a alternativa escolhida é correta")]
        [SwaggerResponse(200, "Resposta da alternativa", typeof(bool))]
        [SwaggerResponse(400, "Dados fornecidos inválidos")]
        public ActionResult<bool> VerificarAlternativa(int id, [FromBody] int alternativaEscolhida)
        {
            try
            {
                var correta = _questaoService.VerificarAlternativaCorreta(id, alternativaEscolhida);
                return Ok(correta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("obterPorPlanoEnsino/{idPlanoEnsino}")]
        public ActionResult<Questao> ObterQuestaoPorPlanoEnsino(int idPlanoEnsino)
        {
            try
            {
                var questoes = _questaoService.ObterQuestaoPorPlanoEnsino(idPlanoEnsino);
                return Ok(questoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}